using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using ChaosMachine.Controllers;
using ChaosMachine.Models;
using System.Diagnostics;

namespace ChaosMachine.Tests;

public class HomeControllerTests
{
    private readonly Mock<ILogger<HomeController>> _mockLogger;
    private readonly HomeController _controller;

    public HomeControllerTests()
    {
        _mockLogger = new Mock<ILogger<HomeController>>();
        _controller = new HomeController(_mockLogger.Object);
        
        // Set up HttpContext for the controller
        var httpContext = new DefaultHttpContext();
        httpContext.TraceIdentifier = "test-trace-id";
        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = httpContext
        };
    }

    [Fact]
    public void Index_ReturnsViewResult()
    {
        // Act
        var result = _controller.Index();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Privacy_ReturnsViewResult()
    {
        // Act
        var result = _controller.Privacy();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Error_ReturnsViewResultWithErrorViewModel()
    {
        // Act
        var result = _controller.Error();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
        Assert.Equal("test-trace-id", model.RequestId);
    }

    [Fact]
    public void Error_HasNoCacheHeaders()
    {
        // Act
        var result = _controller.Error();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        
        // Check that the action has ResponseCache attribute with no-store
        var method = typeof(HomeController).GetMethod(nameof(HomeController.Error));
        var attribute = method?.GetCustomAttributes(typeof(ResponseCacheAttribute), false).FirstOrDefault() as ResponseCacheAttribute;
        
        Assert.NotNull(attribute);
        Assert.Equal(0, attribute.Duration);
        Assert.Equal(ResponseCacheLocation.None, attribute.Location);
        Assert.True(attribute.NoStore);
    }
}