using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RKNBtest.Controllers;
using System.Threading.Tasks;

namespace TestRKNBtest
{
    public class CurrenciesControllerTests
    {
        
        public async Task GetTest()
        {
            // Arrange
            CurrenciesController controller= new CurrenciesController();
            // Act
            ViewResult result = (ViewResult)await controller.Get().ConfigureAwait(false);
            // Assert
            Assert.IsNotNull(result);
        }
      
    }
}
