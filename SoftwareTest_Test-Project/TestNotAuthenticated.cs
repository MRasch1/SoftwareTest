using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SoftwareTest_Test_Project
{
    public class TestNotAuthenticated
    {
        [Fact]
        public void NotAuthenticatedTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetRoles("Admin");

            // Act
            var cut = ctx.RenderComponent<SoftwareTest.Components.Pages.Home>();
            var myObject = cut.Instance;

            // Assert
            //cut.MarkupMatches("<div>Du er IKKE logget ind (from code)</div>");
            Assert.Equal(true, myObject._isAdmin);
        }
    }
}