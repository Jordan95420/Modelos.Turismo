using Microsoft.AspNetCore.Mvc;
using Turismo.Modelos;
using TurismoAPI.Consumer;

namespace TurismoMVC.Controllers
{
    public class SeatCategoriesController : Controller
    {
        // GET: SeatCategoriesController
        public ActionResult Index()
        {
            var categories = Crud<SeatCategory>.GetAll(); // Obtener todas las categorías de asiento
            return View(categories);
        }

        // GET: SeatCategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var category = Crud<SeatCategory>.GetById(id); // Obtener categoría por ID
            return View(category);
        }

        // GET: SeatCategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeatCategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeatCategory category)
        {
            try
            {
                // Crear la categoría usando CRUD
                Crud<SeatCategory>.Create(category);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(category);
            }
        }

        // GET: SeatCategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = Crud<SeatCategory>.GetById(id); // Obtener categoría para editar
            return View(category);
        }

        // POST: SeatCategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SeatCategory category)
        {
            try
            {
                // Actualizar la categoría
                Crud<SeatCategory>.Update(id, category);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(category);
            }
        }

        // GET: SeatCategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = Crud<SeatCategory>.GetById(id); // Obtener categoría para eliminar
            return View(category);
        }

        // POST: SeatCategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SeatCategory category)
        {
            try
            {
                // Eliminar la categoría
                Crud<SeatCategory>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(category);
            }
        }
    }
}
