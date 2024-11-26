/*using Lab4RPBDIS.Controllers;
using Lab4RPBDIS.Data;
using Lab4RPBDIS.Models;
using Lab4RPBDIS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TransportTests
{
    public class RoutesControllerTests
    {
        private readonly Mock<TransportDbContext> _mockContext;
        private readonly Mock<DbSet<Route>> _mockDbSet;

        public RoutesControllerTests()
        {
            _mockDbSet = new Mock<DbSet<Route>>();
            _mockContext = new Mock<TransportDbContext>();

            // Настраиваем контекст для работы с DbSet
            _mockContext.Setup(c => c.Routes).Returns(_mockDbSet.Object);
        }

        [Fact]
        public async Task Details_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var controller = new RoutesController(_mockContext.Object);

            // Act
            var result = await controller.Details(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var route = new Route { Name = "NewRoute" };

            _mockContext.Setup(c => c.Add(It.IsAny<Route>())).Verifiable();
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var controller = new RoutesController(_mockContext.Object);

            // Act
            var result = await controller.Create(route);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(controller.Index), redirectResult.ActionName);
        }

        [Fact]
        public async Task Edit_ReturnsViewWithRoute_WhenIdIsValid()
        {
            // Arrange
            var route = new Route { RouteId = 1, Name = "Route1" };

            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(route);
            _mockContext.Setup(c => c.Routes).Returns(_mockDbSet.Object);

            var controller = new RoutesController(_mockContext.Object);

            // Act
            var result = await controller.Edit(1) as ViewResult;

            // Assert
            var model = Assert.IsType<Route>(result.Model);
            Assert.Equal("Route1", model.Name);
        }

        [Fact]
        public async Task DeleteConfirmed_RemovesRouteAndRedirects()
        {
            // Arrange
            var route = new Route { RouteId = 1, Name = "Route1" };

            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(route);
            _mockContext.Setup(c => c.Routes).Returns(_mockDbSet.Object);
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var controller = new RoutesController(_mockContext.Object);

            // Act
            var result = await controller.DeleteConfirmed(1);

            // Assert
            _mockDbSet.Verify(m => m.Remove(route), Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(controller.Index), redirectResult.ActionName);
        }
    }
}
*/