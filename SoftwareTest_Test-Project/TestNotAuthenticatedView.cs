using Bunit;
using Bunit.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareTest_Test_Project
{
    public class TestNotAuthenticatedView
    {
        [Fact]
        public void NotAuthenticatedTestView()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();

            // Act
            var cut = ctx.RenderComponent<SoftwareTest.Components.Pages.Home>();

            // Assert
            cut.MarkupMatches("<div>Du er IKKE logget ind (from code)</div>");
        }
    }
}
