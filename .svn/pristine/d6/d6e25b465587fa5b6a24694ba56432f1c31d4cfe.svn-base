using Oxxo2.Models;
using System;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class SchedulerJsonModelTest
    {
        [Fact]
        public void SchdlJsonMdl_HoraInicioString_ReturnTrue()
        {
            //Act
            var prueba = new SchedulerJson();
            prueba.HoraInicio = "05:00:00";

            //Assert
            Assert.IsType<string>(prueba.HoraInicio);

        }

        [Fact]
        public void SchdlJsonMdl_HoraFinString_ReturnTrue()
        {
            //Act
            var prueba = new SchedulerJson();
            prueba.HoraFin = "23:00:59";

            //Assert
            Assert.IsType<string>(prueba.HoraFin);

        }

        [Fact]
        public void SchdlJsonMdl_usrString_ReturnTrue()
        {
            //Act
            var prueba = new SchedulerJson();
            prueba.usr = "Usuario de prueba";

            //Assert
            Assert.IsType<string>(prueba.usr);

        }

    }
}
