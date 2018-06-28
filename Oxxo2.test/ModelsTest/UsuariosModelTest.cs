using Oxxo2.Models;
using System;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class UsuariosModelTest
    {
        [Fact]
        public void UsuariosMdl_UsuarioIdInt_ReturnTrue()
        {
            //Act
            var prueba = new Usuarios();
            prueba.UsuarioId = 500;

            //Assert
            Assert.IsType<Int32>(prueba.UsuarioId);

        }

        [Fact]
        public void UsuariosMdl_UsuarioString_ReturnTrue()
        {
            //Act
            var prueba = new Usuarios();
            prueba.Usuario = "Usuario de Prueba";

            //Assert
            Assert.IsType<string>(prueba.Usuario);

        }

        [Fact]
        public void UsuariosMdl_contraseniaString_ReturnTrue()
        {
            //Act
            var prueba = new Usuarios();
            prueba.contrasenia = "Contrasenia de prueba";

            //Assert
            Assert.IsType<string>(prueba.contrasenia);

        }

        [Fact]
        public void UsuariosMdl_IdPuestoInt_ReturnTrue()
        {
            //Act
            var prueba = new Usuarios();
            prueba.IdPuesto = 500;

            //Assert
            Assert.IsType<Int32>(prueba.IdPuesto);

        }
    }
}
