using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TurismoMVC.Controllers
{
    public class TouristRoutesController : Controller
    {
        // GET: TouristRoutesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TouristRoutesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TouristRoutesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TouristRoutesController/Create
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

        // GET: TouristRoutesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TouristRoutesController/Edit/5
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

        // GET: TouristRoutesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TouristRoutesController/Delete/5
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
