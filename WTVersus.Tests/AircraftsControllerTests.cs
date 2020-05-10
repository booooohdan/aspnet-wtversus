using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WTVersus.Controllers;
using WTVersus.Models;
using Xunit;

namespace WTVersus.Tests
{
    public class AircraftsControllerTests
    {
        [Fact]
        public void CanChangePlaneProperty()
        {
            // Arrange
            var p = new Plane { Name = "Test", Id = 1 };

            // Act
            p.Name = "New Name";

            // Assert
            Assert.Equal("New Name", p.Name);
        }
    }
}
