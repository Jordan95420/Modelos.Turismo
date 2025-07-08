using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatronDiseño;
using System;
using System.Collections.Generic;
using Turismo.Modelos;
using TurismoAPI.Consumer;
using TurismoMVC.Models;

namespace TurismoMVC.Controllers
{
    public class TouristTicketsController : Controller
    {
        private readonly TicketFactory _ticketFactory;
        private readonly List<IObserver> _observers;

        // Configuración de licencia de QuestPDF en el constructor estático
        static TouristTicketsController()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public TouristTicketsController()
        {
            _ticketFactory = new TicketFactoryGeneral();
            _observers = new List<IObserver>();
        }

        private void AttachObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        private void NotifyObservers(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        // GET: TouristTickets/Create
        public IActionResult Create()
        {
            ViewBag.SeatCategories = new SelectList(Crud<SeatCategory>.GetAll(), "Id", "Type");
            ViewBag.CategoryTickets = new SelectList(Crud<CategoryTicket>.GetAll(), "Id", "Type");
            ViewBag.TouristRoutes = new SelectList(Crud<TouristRoute>.GetAll(), "Id", "Name");
            ViewBag.UserClients = new SelectList(Crud<UserClient>.GetAll(), "Id", "Name");
            ViewBag.TouristRoutesList = Crud<TouristRoute>.GetAll();
            ViewBag.CategoryTicketsList = Crud<CategoryTicket>.GetAll();
            ViewBag.SeatCategoriesList = Crud<SeatCategory>.GetAll();
            return View();
        }

        // POST: TouristTickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoletoCompraViewModel model)
        {
            try
            {
                var boletosCreados = new List<TouristTicket>();

                foreach (var item in model.Boletos)
                {
                    var route = Crud<TouristRoute>.GetById(item.TouristRouteId);
                    var seat = Crud<SeatCategory>.GetById(item.SeatCategoryId);
                    var category = Crud<CategoryTicket>.GetById(item.CategoryTicketId);

                    IPriceCalculation strategy = category.Type switch
                    {
                        "Niño" => new ChildPriceCalculation(),
                        "TerceraEdad" => new SeniorPriceCalculation(),
                        "Adulto" => new AdultPriceCalculation(),
                        _ => throw new InvalidOperationException($"Categoría de ticket no soportada: {category.Type}")
                    };

                    double finalPrice = strategy.CalculatePrice(route.BasePrice, seat.Price, category.Price);

                    for (int i = 0; i < item.Cantidad; i++)
                    {
                        var newTicket = new TouristTicket
                        {
                            TouristRouteId = item.TouristRouteId,
                            CategoryTicketId = item.CategoryTicketId,
                            SeatCategoryId = item.SeatCategoryId,
                            UserClientId = item.UserClientId,
                            FinallyPrice = finalPrice,
                            PurchaseDate = DateTime.Now
                        };

                        Crud<TouristTicket>.Create(newTicket);

                        // Cargar datos relacionados para el PDF
                        newTicket.Route = route;
                        newTicket.Category = category;
                        newTicket.Seat = seat;
                        newTicket.Client = Crud<UserClient>.GetById(item.UserClientId);

                        boletosCreados.Add(newTicket);

                        var clientObserver = new ClientObserver("Cliente" + item.UserClientId);
                        AttachObserver(clientObserver);
                        NotifyObservers($"Estimado {clientObserver.ClientName}, su asiento ha sido reservado correctamente.");
                    }
                }

                // Asegurar que todos los datos relacionados están cargados antes de generar el PDF
                foreach (var b in boletosCreados)
                {
                    b.Route ??= Crud<TouristRoute>.GetById(b.TouristRouteId);
                    b.Category ??= Crud<CategoryTicket>.GetById(b.CategoryTicketId);
                    b.Seat ??= Crud<SeatCategory>.GetById(b.SeatCategoryId);
                    b.Client ??= Crud<UserClient>.GetById(b.UserClientId);
                }

                // Generar un solo PDF con todos los boletos de la compra
                if (boletosCreados.Any())
                {
                    var pdfBytes = GenerarPdfBoletos(boletosCreados);
                    return File(pdfBytes, "application/pdf", "Boletos.pdf");
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Recargar combos si hay error
                ViewBag.SeatCategories = new SelectList(Crud<SeatCategory>.GetAll(), "Id", "Type");
                ViewBag.CategoryTickets = new SelectList(Crud<CategoryTicket>.GetAll(), "Id", "Type");
                ViewBag.TouristRoutes = new SelectList(Crud<TouristRoute>.GetAll(), "Id", "Name");
                ViewBag.UserClients = new SelectList(Crud<UserClient>.GetAll(), "Id", "Name");
                ViewBag.TouristRoutesList = Crud<TouristRoute>.GetAll();
                ViewBag.CategoryTicketsList = Crud<CategoryTicket>.GetAll();
                ViewBag.SeatCategoriesList = Crud<SeatCategory>.GetAll();

                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // Agrupa las compras por cliente y fecha/hora de compra
        public ActionResult Index()
        {
            var tickets = Crud<TouristTicket>.GetAll();

            // Cargar datos relacionados
            foreach (var ticket in tickets)
            {
                ticket.Route = Crud<TouristRoute>.GetById(ticket.TouristRouteId);
                ticket.Category = Crud<CategoryTicket>.GetById(ticket.CategoryTicketId);
                ticket.Seat = Crud<SeatCategory>.GetById(ticket.SeatCategoryId);
                ticket.Client = Crud<UserClient>.GetById(ticket.UserClientId);
            }

            // Agrupar por cliente y fecha/hora de compra (ajusta la precisión si lo necesitas)
            var compras = tickets
                .GroupBy(t => new { t.UserClientId, t.PurchaseDate.Date, t.PurchaseDate.Hour, t.PurchaseDate.Minute, t.PurchaseDate.Second })
                .Select((g, idx) => new CompraViewModel
                {
                    CompraId = idx + 1,
                    Cliente = g.First().Client?.Name,
                    FechaCompra = g.First().PurchaseDate,
                    Boletos = g.ToList()
                })
                .ToList();

            return View(compras);
        }

        // Acción para descargar el PDF de una compra agrupada
        [HttpPost]
        public IActionResult DescargarPdf(int compraId)
        {
            var tickets = Crud<TouristTicket>.GetAll();
            foreach (var ticket in tickets)
            {
                ticket.Route = Crud<TouristRoute>.GetById(ticket.TouristRouteId);
                ticket.Category = Crud<CategoryTicket>.GetById(ticket.CategoryTicketId);
                ticket.Seat = Crud<SeatCategory>.GetById(ticket.SeatCategoryId);
                ticket.Client = Crud<UserClient>.GetById(ticket.UserClientId);
            }
            var compras = tickets
                .GroupBy(t => new { t.UserClientId, t.PurchaseDate.Date, t.PurchaseDate.Hour, t.PurchaseDate.Minute, t.PurchaseDate.Second })
                .Select((g, idx) => new { Id = idx + 1, Boletos = g.ToList() })
                .ToList();

            var compra = compras.FirstOrDefault(c => c.Id == compraId);
            if (compra == null)
                return NotFound();

            // Asegurar que todos los datos relacionados están cargados antes de generar el PDF
            foreach (var b in compra.Boletos)
            {
                b.Route ??= Crud<TouristRoute>.GetById(b.TouristRouteId);
                b.Category ??= Crud<CategoryTicket>.GetById(b.CategoryTicketId);
                b.Seat ??= Crud<SeatCategory>.GetById(b.SeatCategoryId);
                b.Client ??= Crud<UserClient>.GetById(b.UserClientId);
            }

            var pdfBytes = GenerarPdfBoletos(compra.Boletos);
            return File(pdfBytes, "application/pdf", $"Compra_{compraId}_Boletos.pdf");
        }

        private byte[] GenerarPdfBoletos(List<TouristTicket> boletos)
        {
            var boletosList = boletos.ToList();
            var fechaEmision = DateTime.Now.ToString("g");

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.Grey.Lighten3);

                    page.Content().Column(col =>
                    {
                        col.Item().PaddingBottom(10).Text("Boletos Turísticos")
                            .Style(TextStyle.Default.FontSize(18).FontColor(Colors.Blue.Darken2))
                            .SemiBold();

                        col.Item().PaddingBottom(10).Text($"Fecha de emisión: {fechaEmision}")
                            .Style(TextStyle.Default.FontSize(10).FontColor(Colors.Grey.Darken2))
                            .AlignRight();

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(30); // #
                                columns.RelativeColumn(2);  // Ruta
                                columns.RelativeColumn(1.5f); // Categoría
                                columns.RelativeColumn(1.5f); // Asiento
                                columns.RelativeColumn(2);  // Cliente
                                columns.RelativeColumn(1);  // Precio
                                columns.RelativeColumn(1.5f); // Fecha
                            });

                            // Encabezado
                            table.Header(header =>
                            {
                                header.Cell().Element(CellHeaderStyle).Text("#").Style(TextStyle.Default.FontColor(Colors.White).Bold());
                                header.Cell().Element(CellHeaderStyle).Text("Ruta").Style(TextStyle.Default.FontColor(Colors.White).Bold());
                                header.Cell().Element(CellHeaderStyle).Text("Categoría").Style(TextStyle.Default.FontColor(Colors.White).Bold());
                                header.Cell().Element(CellHeaderStyle).Text("Asiento").Style(TextStyle.Default.FontColor(Colors.White).Bold());
                                header.Cell().Element(CellHeaderStyle).Text("Cliente").Style(TextStyle.Default.FontColor(Colors.White).Bold());
                                header.Cell().Element(CellHeaderStyle).Text("Precio").Style(TextStyle.Default.FontColor(Colors.White).Bold());
                                header.Cell().Element(CellHeaderStyle).Text("Fecha").Style(TextStyle.Default.FontColor(Colors.White).Bold());
                            });

                            // Filas
                            for (int i = 0; i < boletosList.Count; i++)
                            {
                                var b = boletosList[i];
                                bool esPar = i % 2 == 0;
                                table.Cell().Element(c => CellBodyStyle(c, esPar)).Text((i + 1).ToString()).Style(TextStyle.Default.FontSize(10));
                                table.Cell().Element(c => CellBodyStyle(c, esPar)).Text(b.Route?.Name ?? "").Style(TextStyle.Default.FontSize(10));
                                table.Cell().Element(c => CellBodyStyle(c, esPar)).Text(b.Category?.Type ?? "").Style(TextStyle.Default.FontSize(10));
                                table.Cell().Element(c => CellBodyStyle(c, esPar)).Text(b.Seat?.Type ?? "").Style(TextStyle.Default.FontSize(10));
                                table.Cell().Element(c => CellBodyStyle(c, esPar)).Text(b.Client?.Name ?? "").Style(TextStyle.Default.FontSize(10));
                                table.Cell().Element(c => CellBodyStyle(c, esPar)).Text(b.FinallyPrice.ToString("F2")).Style(TextStyle.Default.FontSize(10));
                                table.Cell().Element(c => CellBodyStyle(c, esPar)).Text(b.PurchaseDate.ToString("g")).Style(TextStyle.Default.FontSize(10));
                            }
                        });
                    });

                    page.Footer().AlignCenter().Text(txt =>
                    {
                        txt.Span("¡Gracias por su compra! ").Style(TextStyle.Default.FontColor(Colors.Blue.Darken2).Bold());
                        txt.Span("Sistema Turismo - ").Style(TextStyle.Default.FontColor(Colors.Grey.Darken2));
                        txt.Span(DateTime.Now.ToString("dd/MM/yyyy HH:mm")).Style(TextStyle.Default.FontColor(Colors.Grey.Darken2));
                    });
                });
            });

            using var ms = new MemoryStream();
            pdf.GeneratePdf(ms);
            return ms.ToArray();

            // Las funciones locales deben ir aquí, al final del método, no dentro del bucle
            static IContainer CellHeaderStyle(IContainer container)
            {
                return container
                    .Background(Colors.Blue.Lighten2)
                    .PaddingVertical(4)
                    .PaddingHorizontal(6)
                    .BorderBottom(1)
                    .BorderColor(Colors.Blue.Darken2);
            }

            static IContainer CellBodyStyle(IContainer container, bool esPar)
            {
                return container
                    .Background(esPar ? Colors.White : Colors.Grey.Lighten4)
                    .PaddingVertical(3)
                    .PaddingHorizontal(6);
            }
        }
    }
}