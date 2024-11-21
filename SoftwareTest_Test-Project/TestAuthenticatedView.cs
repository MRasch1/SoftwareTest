using Bunit;
using Bunit.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareTest_Test_Project
{
    public class TestAuthenticatedView
    {
        [Fact]
        public void AuthenticatedTestView()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("User");

            // Act
            var cut = ctx.RenderComponent<SoftwareTest.Components.Pages.Home>();

            // Assert
            cut.MarkupMatches("<div>Du er logget ind (from code)</div>");
        }
    }
}
