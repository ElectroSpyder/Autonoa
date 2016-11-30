using System.Collections.Generic;
using Autonoa.Solucion.Data;
using Autonoa.Solucion.ILogica;

namespace Autonoa.Solucioon.Logica.VehiculoRepository
{
    public class VehiculoRepository : GenericRepository<Vehiculo>
    {
        public Vehiculo GetVehiculo(int id)
        {
            return FindOneBy(x => x.Id == id);
        }

        public IEnumerable<Vehiculo> GetAllVehiculos()
        {
            return GetAll();
        }

        public bool AddVehiculo(Vehiculo newVehiculo)
        {
            return Add(newVehiculo) > 0;
        }

        public bool DeleteVehiculo(Vehiculo deleteVehiculo)
        {
            if (FindOneBy(x => x.Id == deleteVehiculo.Id) != null)
            {
                return Delete(deleteVehiculo)>0;
            }
            return false;
        }

        public bool UpdateVehiculo(Vehiculo updateVehiculo)
        {
            if (FindOneBy(x => x.Id == updateVehiculo.Id) != null)
            {
                return Edit(updateVehiculo) > 0;
            }
            return false;
        }
    }
}
