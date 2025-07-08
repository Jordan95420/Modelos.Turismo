using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TurismoMVC.Controllers
{
    public class UserAdminsController : Controller
    {
        // GET: UserAdminsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserAdminsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserAdminsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAdminsController/Create
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

        // GET: UserAdminsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserAdminsController/Edit/5
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

        // GET: UserAdminsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserAdminsController/Delete/5
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
