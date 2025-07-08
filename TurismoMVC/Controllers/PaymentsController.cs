using Microsoft.AspNetCore.Mvc;
using Turismo.Modelos;
using TurismoAPI.Consumer;

namespace TurismoMVC.Controllers
{
    public class PaymentsController : Controller
    {
        // GET: PaymentsController
        public ActionResult Index()
        {
            var payments = Crud<Payment>.GetAll(); // Obtener todos los pagos
            return View(payments);
        }

        // GET: PaymentsController/Details/5
        public ActionResult Details(int id)
        {
            var payment = Crud<Payment>.GetById(id); // Obtener pago por ID
            return View(payment);
        }

        // GET: PaymentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment payment)
        {
            try
            {
                // Crear el pago usando CRUD
                Crud<Payment>.Create(payment);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(payment);
            }
        }

        // GET: PaymentsController/Edit/5
        public ActionResult Edit(int id)
        {
            var payment = Crud<Payment>.GetById(id); // Obtener pago para editar
            return View(payment);
        }

        // POST: PaymentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Payment payment)
        {
            try
            {
                // Actualizar el pago
                Crud<Payment>.Update(id, payment);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(payment);
            }
        }

        // GET: PaymentsController/Delete/5
        public ActionResult Delete(int id)
        {
            var payment = Crud<Payment>.GetById(id); // Obtener pago para eliminar
            return View(payment);
        }

        // POST: PaymentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Payment payment)
        {
            try
            {
                // Eliminar el pago
                Crud<Payment>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(payment);
            }
        }
    }
}
