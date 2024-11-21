using Bunit;
using Bunit.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareTest_Test_Project
{
    public class TestAdminView
    {
        [Fact]
        public void AdminTestView()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("User");
            authContext.SetRoles("Admin");

            // Act
            var cut = ctx.RenderComponent<SoftwareTest.Components.Pages.Home>();

            // Assert
            cut.MarkupMatches("<div>Du er logget ind (from code)</div><div>Du er Admin</div>");
        }
    }
}
