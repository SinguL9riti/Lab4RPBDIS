using Lab4RPBDIS.Controllers;
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
    public class SchedulesControllerTests
    {
        private readonly Mock<TransportDbContext> _mockContext;
        private readonly Mock<DbSet<Schedule>> _mockDbSet;

        public SchedulesControllerTests()
        {
            _mockDbSet = new Mock<DbSet<Schedule>>();
            _mockContext = new Mock<TransportDbContext>();

            _mockContext.Setup(c => c.Schedules).Returns(_mockDbSet.Object);
        }
        [Fact]
        public async Task Details_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var controller = new SchedulesController(_mockContext.Object);

            // Act
            var result = await controller.Details(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var scheduleViewModel = new ScheduleViewModel
            {
                RouteId = 1,
                Weekday = "Monday",
                ArrivalTime = TimeSpan.Parse("10:00"),
                Year = 2024
            };

            _mockContext.Setup(c => c.Add(It.IsAny<Schedule>())).Verifiable();
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var controller = new SchedulesController(_mockContext.Object);

            // Act
            var result = await controller.Create(scheduleViewModel);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(controller.Index), redirectResult.ActionName);
        }
        [Fact]
        public async Task DeleteConfirmed_RemovesScheduleAndRedirects()
        {
            // Arrange
            var schedule = new Schedule { ScheduleId = 1, RouteId = 1 };

            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(schedule);
            _mockContext.Setup(c => c.Schedules).Returns(_mockDbSet.Object);
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var controller = new SchedulesController(_mockContext.Object);

            // Act
            var result = await controller.DeleteConfirmed(1);

            // Assert
            _mockDbSet.Verify(m => m.Remove(schedule), Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(controller.Index), redirectResult.ActionName);
        }
    }
}
