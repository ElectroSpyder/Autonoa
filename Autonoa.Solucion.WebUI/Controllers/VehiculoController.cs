using System.Collections.Generic;
using Autonoa.Solucion.Data;
using System.Web.Mvc;
using AutoMapper;
using Autonoa.Solucion.ILogica.IGenericRepository;
using Autonoa.Solucion.WebUI.Helper;
using Autonoa.Solucion.Model.ViewModel;
using Autonoa.Solucioon.Logica.VehiculoRepository;

namespace Autonoa.Solucion.WebUI.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly IGenericRepository<Vehiculo> _vehiculoRepository;
        private readonly IMapper _mapper;

        public VehiculoController()
        {
            _vehiculoRepository = new VehiculoRepository();
            _mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Vehiculo
        public ActionResult Index()
        {
            var vehiculo = _vehiculoRepository.GetAll();
            var model = new List<VehiculoModel>();
            if (vehiculo != null)
            {
                model = _mapper.Map<IEnumerable<Vehiculo>, List<VehiculoModel>>(vehiculo);


            }
            return View(model);
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int id)
        {
            var vehiculo = _vehiculoRepository.FindOneBy(x => x.Id == id);
            if (vehiculo == null) return RedirectToAction("Index");

            var model = _mapper.Map<Vehiculo, VehiculoModel>(vehiculo);
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

                var modelToSave = _mapper.Map<VehiculoModel, Vehiculo>(model);
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

            var modelToUpdate = _mapper.Map<Vehiculo, VehiculoModel>(vehiculo);

            return View(modelToUpdate);

        }

        // POST: Vehiculo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehiculoModel model)
        {
            try
            {
                var modelToUpdate = _mapper.Map<VehiculoModel, Vehiculo>(model);

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

            var modelToDelete = _mapper.Map<Vehiculo, VehiculoModel>(vehiculo);
            return View(modelToDelete);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, VehiculoModel model)
        {
            try
            {
                var vehiculo = _mapper.Map<VehiculoModel, Vehiculo>(model);
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
