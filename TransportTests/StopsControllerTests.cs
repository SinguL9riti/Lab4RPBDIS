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
    public class StopsControllerTests
    {
        private readonly Mock<TransportDbContext> _mockContext;
        private readonly Mock<DbSet<Stop>> _mockDbSet;

        public StopsControllerTests()
        {
            _mockDbSet = new Mock<DbSet<Stop>>();
            _mockContext = new Mock<TransportDbContext>();
            _mockContext.Setup(c => c.Stops).Returns(_mockDbSet.Object);
        }

        [Fact]
        public async Task Create_Post_ValidStop_RedirectsToIndex()
        {
            // Arrange
            var stop = new Stop { Name = "New Stop" };

            _mockContext.Setup(c => c.Add(It.IsAny<Stop>())).Verifiable();
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var controller = new StopsController(_mockContext.Object);

            // Act
            var result = await controller.Create(stop);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(controller.Index), redirectResult.ActionName);
        }

        [Fact]
        public async Task Edit_Post_ValidStop_RedirectsToIndex()
        {
            // Arrange
            var stop = new Stop { StopId = 1, Name = "Edited Stop" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(stop);
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var controller = new StopsController(_mockContext.Object);

            // Act
            var result = await controller.Edit(1, stop);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(controller.Index), redirectResult.ActionName);
        }

        [Fact]
        public async Task DeleteConfirmed_ValidId_RemovesStopAndRedirects()
        {
            // Arrange
            var stop = new Stop { StopId = 1, Name = "Stop1" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(stop);
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var controller = new StopsController(_mockContext.Object);

            // Act
            var result = await controller.DeleteConfirmed(1);

            // Assert
            _mockDbSet.Verify(m => m.Remove(stop), Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(controller.Index), redirectResult.ActionName);
        }
    }
}
*/