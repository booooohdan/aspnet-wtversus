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
        /// <summary>
        /// Okay second methid
        /// </summary>
        /// <param name="gfgf">this is parametereeeeeers</param>
        /// <returns>ITS my return</returns>
      public string themethod2(int gfgf)
        {
            int a = gfgf;
            return a.ToString();
        }
        public void IndexReturnsAViewResultWithAListOfUsers()
        {
            // Arrange
            var mock = new Mock<AircraftsController>();
    //        var controller = new AircraftsController(/*params*/);

            // Act

            // Assert
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
