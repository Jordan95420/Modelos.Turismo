using Microsoft.AspNetCore.Mvc;
using Turismo.Modelos;
using TurismoAPI.Consumer;

namespace TurismoMVC.Controllers
{
    public class CategoryTicketsController : Controller
    {
        // GET: CategoryTicketsController
        public ActionResult Index()
        {
            var categories = Crud<CategoryTicket>.GetAll(); // Obtener todas las categorías de boletos
            return View(categories);
        }

        // GET: CategoryTicketsController/Details/5
        public ActionResult Details(int id)
        {
            var category = Crud<CategoryTicket>.GetById(id); // Obtener categoría de boleto por ID
            return View(category);
        }

        // GET: CategoryTicketsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryTicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryTicket category)
        {
            try
            {
                
                Crud<CategoryTicket>.Create(category);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(category);
            }
        }

        // GET: CategoryTicketsController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = Crud<CategoryTicket>.GetById(id); // Obtener categoría de boleto para editar
            return View(category);
        }

        // POST: CategoryTicketsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryTicket category)
        {
            try
            {
                // Actualizar la categoría de boleto
                Crud<CategoryTicket>.Update(id, category);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(category);
            }
        }

        // GET: CategoryTicketsController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = Crud<CategoryTicket>.GetById(id); // Obtener categoría de boleto para eliminar
            return View(category);
        }

        // POST: CategoryTicketsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoryTicket category)
        {
            try
            {
                // Eliminar la categoría de boleto
                Crud<CategoryTicket>.Delete(id);
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
