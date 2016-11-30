using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Autonoa.Solucion.Data;
using Autonoa.Solucion.ILogica.IGenericRepository;

namespace Autonoa.Solucioon.Logica.VehiculoRepository
{
    public class VehiculoRepository : IGenericRepository<Vehiculo>
    {
        readonly AutonoaEntities _context;

        public VehiculoRepository()
        {
            this._context = new AutonoaEntities();
        }
       
        public int Add(Vehiculo entity)
        {
            _context.Set<Vehiculo>().Add(entity);
            return Save();
        }

        public int Delete(Vehiculo entity)
        {
            _context.Set<Vehiculo>().Remove(entity);
            return Save();
        }

        #region IDisposable Support

        private bool _disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposedValue) return;
            if (disposing)
            {
                _context.Dispose();
            }
            this._disposedValue = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public int Edit(Vehiculo entity)
        {
            _context.Set<Vehiculo>().AddOrUpdate(entity);
            return Save();
        }

        public IEnumerable<Vehiculo> FindBy(Expression<Func<Vehiculo, bool>> predicado)
        {
            return _context.Set<Vehiculo>().Where(predicado).ToList();
        }

        public Vehiculo FindOneBy(Expression<Func<Vehiculo, bool>> predicado)
        {
            var result = _context.Set<Vehiculo>().Where(predicado).FirstOrDefault();
            return result;
        }

        public IEnumerable<Vehiculo> GetAll()
        {
            return _context.Set<Vehiculo>().ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}


#region  Codigo que no se usa
//public Vehiculo GetVehiculo(int id)
//{
//    return FindOneBy(x => x.Id == id);
//}

//public IEnumerable<Vehiculo> GetAllVehiculos()
//{
//    return GetAll();
//}

//public bool AddVehiculo(Vehiculo newVehiculo)
//{
//    return Add(newVehiculo) > 0;
//}

//public bool DeleteVehiculo(Vehiculo deleteVehiculo)
//{
//    if (FindOneBy(x => x.Id == deleteVehiculo.Id) != null)
//    {
//        return Delete(deleteVehiculo)>0;
//    }
//    return false;
//}

//public bool UpdateVehiculo(Vehiculo updateVehiculo)
//{
//    if (FindOneBy(x => x.Id == updateVehiculo.Id) != null)
//    {
//        return Edit(updateVehiculo) > 0;
//    }
//    return false;
//}
#endregion
