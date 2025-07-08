using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TurismoMVC.Controllers
{
    public class CategoryTicketsController : Controller
    {
        // GET: CategoryTicketsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoryTicketsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryTicketsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryTicketsController/Create
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

        // GET: CategoryTicketsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryTicketsController/Edit/5
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

        // GET: CategoryTicketsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryTicketsController/Delete/5
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
