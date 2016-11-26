using Autonoa.Solucion.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Autonoa.Solucion.Servicio
{
    public class Servicio
    {
        private const string Uri = "http://localhost:53407/api/vehiculo";

        public async Task<List<Vehiculo>> GetVehiculosAsync()
        {
            using (var httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<Vehiculo>>(await httpClient.GetStringAsync(Uri));
            }
        }
    }
}
