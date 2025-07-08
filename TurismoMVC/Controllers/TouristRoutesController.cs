using Microsoft.AspNetCore.Mvc;
using Turismo.Modelos;
using TurismoAPI.Consumer;

namespace TurismoMVC.Controllers
{
    public class TouristRoutesController : Controller
    {
        // GET: TouristRoutesController
        public ActionResult Index()
        {
            var routes = Crud<TouristRoute>.GetAll(); // Obtener todas las rutas
            return View(routes);
        }

        // GET: TouristRoutesController/Details/5
        public ActionResult Details(int id)
        {
            var route = Crud<TouristRoute>.GetById(id); // Obtener ruta por ID
            return View(route);
        }

        // GET: TouristRoutesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TouristRoutesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TouristRoute route)
        {
            try
            {
                // Crear la ruta usando CRUD
                Crud<TouristRoute>.Create(route);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(route);
            }
        }

        // GET: TouristRoutesController/Edit/5
        public ActionResult Edit(int id)
        {
            var route = Crud<TouristRoute>.GetById(id); // Obtener ruta para editar
            return View(route);
        }

        // POST: TouristRoutesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TouristRoute route)
        {
            try
            {
                // Actualizar la ruta
                Crud<TouristRoute>.Update(id, route);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(route);
            }
        }

        // GET: TouristRoutesController/Delete/5
        public ActionResult Delete(int id)
        {
            var route = Crud<TouristRoute>.GetById(id); // Obtener ruta para eliminar
            return View(route);
        }

        // POST: TouristRoutesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TouristRoute route)
        {
            try
            {
                // Eliminar la ruta
                Crud<TouristRoute>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(route);
            }
        }
    }
}
