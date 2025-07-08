using Microsoft.AspNetCore.Mvc;
using Turismo.Modelos;
using TurismoAPI.Consumer;

namespace TurismoMVC.Controllers
{
    public class UserClientsController : Controller
    {
        // GET: UserClientsController
        public ActionResult Index()
        {
            var users = Crud<UserClient>.GetAll(); // Obtener todos los usuarios clientes
            return View(users);
        }

        // GET: UserClientsController/Details/5
        public ActionResult Details(int id)
        {
            var user = Crud<UserClient>.GetById(id); // Obtener usuario cliente por ID
            return View(user);
        }

        // GET: UserClientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserClient user)
        {
            try
            {
                // Crear el usuario cliente usando CRUD
                Crud<UserClient>.Create(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }

        // GET: UserClientsController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = Crud<UserClient>.GetById(id); // Obtener usuario cliente para editar
            return View(user);
        }

        // POST: UserClientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserClient user)
        {
            try
            {
                // Actualizar el usuario cliente
                Crud<UserClient>.Update(id, user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }

        // GET: UserClientsController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = Crud<UserClient>.GetById(id); // Obtener usuario cliente para eliminar
            return View(user);
        }

        // POST: UserClientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserClient user)
        {
            try
            {
                // Eliminar el usuario cliente
                Crud<UserClient>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }
    }
}
