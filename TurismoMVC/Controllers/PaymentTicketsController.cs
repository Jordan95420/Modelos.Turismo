using Microsoft.AspNetCore.Mvc;
using Turismo.Modelos;
using TurismoAPI.Consumer;

namespace TurismoMVC.Controllers
{
    public class PaymentTicketsController : Controller
    {
        // GET: PaymentTicketsController
        public ActionResult Index()
        {
            var paymentTickets = Crud<PaymentTicket>.GetAll(); // Obtener todos los pagos de boletos
            return View(paymentTickets);
        }

        // GET: PaymentTicketsController/Details/5
        public ActionResult Details(int id)
        {
            var paymentTicket = Crud<PaymentTicket>.GetById(id); // Obtener pago de boleto por ID
            return View(paymentTicket);
        }

        // GET: PaymentTicketsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentTicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentTicket paymentTicket)
        {
            try
            {
                // Crear el pago de boleto usando CRUD
                Crud<PaymentTicket>.Create(paymentTicket);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(paymentTicket);
            }
        }

        // GET: PaymentTicketsController/Edit/5
        public ActionResult Edit(int id)
        {
            var paymentTicket = Crud<PaymentTicket>.GetById(id); // Obtener pago de boleto para editar
            return View(paymentTicket);
        }

        // POST: PaymentTicketsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PaymentTicket paymentTicket)
        {
            try
            {
                // Actualizar el pago de boleto
                Crud<PaymentTicket>.Update(id, paymentTicket);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(paymentTicket);
            }
        }

        // GET: PaymentTicketsController/Delete/5
        public ActionResult Delete(int id)
        {
            var paymentTicket = Crud<PaymentTicket>.GetById(id); // Obtener pago de boleto para eliminar
            return View(paymentTicket);
        }

        // POST: PaymentTicketsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PaymentTicket paymentTicket)
        {
            try
            {
                // Eliminar el pago de boleto
                Crud<PaymentTicket>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(paymentTicket);
            }
        }
    }
}
