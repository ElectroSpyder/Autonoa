using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Http;
using AutoMapper;
using Autonoa.Solucion.Data;
using Autonoa.Solucion.ILogica;
using Autonoa.Solucion.Model.ViewModel;

namespace Autonoa.Solucion.WebApi.Controllers
{
    [RoutePrefix("api/vehiculo")]
    public class VehiculoController : ApiController
    {
        readonly GenericRepository<Vehiculo> _vehiculoRepository; 
        public VehiculoController(GenericRepository<Vehiculo> vehiculoRepository)
        {
            this._vehiculoRepository = vehiculoRepository;
        }
        public VehiculoController(){}

        [Route("api/AddVehiculo")]
        [HttpPost]
        public int Post(VehiculoModel model)
        {
            var vehiculo = Mapper.Map<VehiculoModel, Vehiculo>(model);
            var result = _vehiculoRepository.Add(vehiculo);
            return result;
        }

        [Route("api/UpdateVehiculo")]
        [HttpPut]
        public int Put(VehiculoModel model)
        {
            var vehiculo = Mapper.Map<VehiculoModel, Vehiculo>(model);
            var result = _vehiculoRepository.Edit(vehiculo);
            return result;
        }

        [Route("api/DeleteVehiculo")]
        [HttpPost]
        public int Delete(VehiculoModel model)
        {
            var vehiculo = Mapper.Map<VehiculoModel, Vehiculo>(model);
            var result = _vehiculoRepository.Delete(vehiculo);
            return result;
        }

        /// <summary>
        /// Retorna todos los Vehiculos
        /// </summary>
        /// <returns>Vehiculos</returns>
        [Route("api/GetVehiculos")]
        public IEnumerable<Vehiculo> Get()
        {
            return _vehiculoRepository.GetAll();
        }

        /// <summary>
        /// Retorna un vehiculo dependiendo del id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vehiculo</returns>
        [Route("api/GetVehiculo")]
        public Vehiculo Get(int id)
        {
            return _vehiculoRepository.FindOneBy(x => x.Id == id);
        }

        /// <summary>
        /// Obtener Vehiculos segun predicado
        /// </summary>
        /// <param name="predicado">x => x.Propiedad</param>
        /// <returns>IEnumerable de vehiculos</returns>
        [Route("api/GetVehiculos")]
        public IEnumerable<Vehiculo> Get(Expression<Func<Vehiculo, bool>> predicado)
        {
            return _vehiculoRepository.FindBy(predicado);
        } 
    }
}
