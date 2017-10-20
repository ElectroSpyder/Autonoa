using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autonoa.Solucioon.Logica.VehiculoRepository;

namespace Autonoa.Solucion.Test
{
    [TestClass]
    public class VehiculoTest
    {
        [TestMethod]
        public void GetVehiculo()
        {
            var proxy = new VehiculoRepository();
            var result = proxy.GetAll();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostVehiculo()
        {
            var proxy = new VehiculoRepository();

            var result = proxy.Add(new Data.Vehiculo
            {
                Color = "Azul",
                Descripcion = "Vehiculo con aire",
                Marca = "Renault",
                Modelo = "Esport",
                Motor = "v8",
                Precio = 250000,
                UrlImagen = "http://"
            });

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetByExpression()
        {
            var proxy = new VehiculoRepository();
            var result = proxy.FindBy(x => x.Color == "Azul");

            Assert.IsNotNull(result);
        }
    }
}
