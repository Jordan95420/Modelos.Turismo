using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TurismoMVC.Controllers
{
    public class PaymentTicketsController : Controller
    {
        // GET: PaymentTicketsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaymentTicketsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentTicketsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentTicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PaymentTicketsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentTicketsController/Edit/5
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

        // GET: PaymentTicketsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentTicketsController/Delete/5
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
