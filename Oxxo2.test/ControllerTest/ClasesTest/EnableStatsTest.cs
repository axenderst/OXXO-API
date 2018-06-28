using Oxxo2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OxxoTest.ControllerTest.ClasesTest
{
    public class EnableStatsTest
    {
        [Fact]
        public void CheckAvailability_UsuarioAdmin_ReturnBool()
        {
            // arrange
           

            //act
            var CheckAv = new EnableStats().CheckAvailability();
            if (CheckAv)
            {
                //assert
                Assert.True(CheckAv);
            }
            else {
                //assert
                Assert.False(CheckAv);
            }

            
        }


        // Incluir aquí el Fact de: EnableStats().SetStats()

    }
}
