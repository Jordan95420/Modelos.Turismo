using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TurismoMVC.Controllers
{
    public class PaymentsController : Controller
    {
        // GET: PaymentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaymentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentsController/Create
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

        // GET: PaymentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentsController/Edit/5
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

        // GET: PaymentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentsController/Delete/5
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
