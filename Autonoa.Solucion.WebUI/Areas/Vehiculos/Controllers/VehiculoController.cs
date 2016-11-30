using System.Web.Mvc;

namespace Autonoa.Solucion.WebUI.Areas.Vehiculos.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculos/Vehiculo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vehiculos/Vehiculo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vehiculos/Vehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculos/Vehiculo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiculos/Vehiculo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vehiculos/Vehiculo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiculos/Vehiculo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vehiculos/Vehiculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
