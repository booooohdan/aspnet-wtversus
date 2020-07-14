using EntityFrameworkCore.Testing.Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NLog;
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
        public void IndexReturnsAViewResultWithAListOfUsers()
        {
            // Arrange
            var mockedDbContext = Create.MockedDbContextFor<AppDbContext>();
            var mockedLogger = Mock.Of<ILogger<AircraftsController>>();
            AircraftsController aircraftsController = new AircraftsController(mockedDbContext, mockedLogger);

            // Act
            ViewResult result = aircraftsController.Tree() as ViewResult;

            // Assert
            Assert.Equal("Tree", result?.ViewName);
        }

        /// <summary>
        /// Here the a+b method
        /// </summary>
        /// <param name="a">The a parameters</param>
        /// <param name="b">The b parameters</param>
        public int AplusB(int a, int b)
        {
            return a + b;
        }
    }
}
