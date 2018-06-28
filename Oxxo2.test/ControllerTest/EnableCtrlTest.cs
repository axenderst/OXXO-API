using Microsoft.AspNetCore.Mvc;
using Oxxo2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OxxoTest.ControllerTest
{
    public class EnableCtrlTest
    {
        [Fact]
        public void CheckStatus_SinParam_ReturnOk()
        {
            // arrange
            IActionResult result = new EnableController().CheckStatus();
            var okObjectResult = result as OkObjectResult;

            //act
            Assert.NotNull(okObjectResult);

        }

    }
}
