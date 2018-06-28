using Oxxo2.Controllers.Clases;
using System;
using Xunit;

namespace OxxoTest.ControllerTest.ClasesTest
{
    public class AutorizacionTest
    {
        [Fact]
        public void Autorizacion_UsuarioAdmin_ReturnTrue()
        {
            // arrange
            string usr = "admin";

            //act
            var UsrIsAdmin = new Autorizacion().ValidaPermisos(usr);

            //assert
            Assert.True(UsrIsAdmin);
        }

        [Fact]
        public void Autorizacion_UsuarioOtro_ReturnFalse()
        {
            // arrange
            string usr = "Otro";

            //act
            var UsrIsAdmin = new Autorizacion().ValidaPermisos(usr);

            //assert
            Assert.False(UsrIsAdmin);
        }
    }
}
