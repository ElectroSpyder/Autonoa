using System.Collections.Generic;
using System.Linq;
using Autonoa.Solucion.Data;
using Autonoa.Solucion.ILogica;
using System.Web.Mvc;
using AutoMapper;
using Autonoa.Solucion.Model.ViewModel;

namespace Autonoa.Solucion.WebUI.Controllers
{
    public class VehiculoController : Controller
    {
        readonly GenericRepository<Vehiculo> _vehiculoRepository;
        public VehiculoController(GenericRepository<Vehiculo> vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        // GET: Vehiculo
        public ActionResult Index()
        {
            var vehiculo = _vehiculoRepository.GetAll();
            var model = Mapper.Map<IEnumerable<Vehiculo>, List<VehiculoModel>>(vehiculo);

            return View(model);
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int id)
        {
            var vehiculo = _vehiculoRepository.FindOneBy(x => x.Id == id);
            if (vehiculo == null) return RedirectToAction("Index");

            var model = Mapper.Map<Vehiculo, VehiculoModel>(vehiculo);
            return View(model);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            var model = new VehiculoModel();
            return View(model);
        }

        // POST: Vehiculo/Create
        [HttpPost]
        public ActionResult Create(VehiculoModel model)
        {
            try
            {
                var result =
                    _vehiculoRepository.FindBy(
                        x => x.Marca == model.Marca && x.Modelo == model.Modelo && x.Motor == model.Motor);
                var enumerable = result as Vehiculo[] ?? result.ToArray();
                if (enumerable.Any())
                {
                    return RedirectToAction("Index", Mapper.Map<IEnumerable<Vehiculo>, List<VehiculoModel>>(enumerable));
                }

                var modelToSave = Mapper.Map<VehiculoModel, Vehiculo>(model);
                var saved = _vehiculoRepository.Add(modelToSave);
                return saved > 0 ? RedirectToAction("Details", modelToSave) : RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int id)
        {
            var vehiculo = _vehiculoRepository.FindOneBy(x => x.Id == id);
            if (vehiculo == null) return RedirectToAction("Index");

            var modelToUpdate = Mapper.Map<Vehiculo, VehiculoModel>(vehiculo);

            return View(modelToUpdate);

        }

        // POST: Vehiculo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehiculoModel model)
        {
            try
            {
                var modelToUpdate = Mapper.Map<VehiculoModel, Vehiculo>(model);

                var result = _vehiculoRepository.Edit(modelToUpdate);
                return result > 0 ? RedirectToAction("Index") : RedirectToAction("Edit", model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int id)
        {
            var vehiculo = _vehiculoRepository.FindOneBy(x => x.Id == id);
            if (vehiculo == null) return RedirectToAction("Index");

            var modelToDelete = Mapper.Map<Vehiculo, VehiculoModel>(vehiculo);
            return View(modelToDelete);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, VehiculoModel model)
        {
            try
            {
                var vehiculo = Mapper.Map<VehiculoModel, Vehiculo>(model);
                var result = _vehiculoRepository.Delete(vehiculo);

                return result > 0 ? RedirectToAction("Index") : RedirectToAction("Delete", model.Id);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
