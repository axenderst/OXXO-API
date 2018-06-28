using Oxxo2.Models;
using System;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class MonitoreoModelTest
    {
        [Fact]
        public void MonitoreoMdl_MonitorIdInt_ReturnTrue()
        {
            //Act
            var prueba = new Monitoreo();
            prueba.MonitorId = 5852;

            //Assert
            Assert.IsType<Int32>(prueba.MonitorId);

        }

        [Fact]
        public void MonitoreoMdl_UsuarioString_ReturnTrue()
        {
            //Act
            var prueba = new Monitoreo();
            prueba.Usuario = "Usuario de Prueba";

            //Assert
            Assert.IsType<string>(prueba.Usuario);

        }

        [Fact]
        public void MonitoreoMdl_ActividadString_ReturnTrue()
        {
            //Act
            var prueba = new Monitoreo();
            prueba.Actividad = "Actividad de Prueba";

            //Assert
            Assert.IsType<string>(prueba.Actividad);

        }
    }
}
