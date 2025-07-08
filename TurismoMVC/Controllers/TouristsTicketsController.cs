using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatronDiseño;
using System;

namespace TurismoMVC.Controllers
{
    public class TouristsTicketsController : Controller
    {
        // GET: TouristsTicketsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TouristsTicketsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TouristsTicketsController/Create
        public ActionResult Create()
        {
            // Aquí podrías cargar rutas, categorías y asientos desde la base de datos o API
            return View();
        }

        // POST: TouristsTicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int routeId, int categoryId, int seatCategoryId, int userClientId)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TouristsTicketsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TouristsTicketsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TouristsTicketsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TouristsTicketsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
