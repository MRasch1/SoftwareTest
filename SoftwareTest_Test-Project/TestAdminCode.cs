using Bunit;
using Bunit.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareTest_Test_Project
{
    public class TestAdminCode
    {
        [Fact]
        public void AdminTestCode()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("User");
            authContext.SetRoles("Admin");

            // Act
            var cut = ctx.RenderComponent<SoftwareTest.Components.Pages.Home>();
            var myObject = cut.Instance;

            // Assert
            Assert.True(myObject._isAuthenticated);
            Assert.True(myObject._isAdmin);
        }
    }
}
