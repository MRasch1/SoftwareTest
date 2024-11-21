using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SoftwareTest_Test_Project
{
    public class TestNotAuthenticatedCode
    {
        [Fact]
        public void NotAuthenticatedTestCode()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();

            // Act
            var cut = ctx.RenderComponent<SoftwareTest.Components.Pages.Home>();
            var myObject = cut.Instance;

            // Assert
            Assert.False(myObject._isAuthenticated);
        }
    }
}