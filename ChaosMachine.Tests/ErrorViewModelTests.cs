using ChaosMachine.Models;

namespace ChaosMachine.Tests;

public class ErrorViewModelTests
{
    [Fact]
    public void ShowRequestId_WhenRequestIdIsNull_ReturnsFalse()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel { RequestId = null };

        // Act
        var result = errorViewModel.ShowRequestId;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ShowRequestId_WhenRequestIdIsEmpty_ReturnsFalse()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel { RequestId = string.Empty };

        // Act
        var result = errorViewModel.ShowRequestId;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ShowRequestId_WhenRequestIdHasValue_ReturnsTrue()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel { RequestId = "test-request-id" };

        // Act
        var result = errorViewModel.ShowRequestId;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void RequestId_CanBeSetAndRetrieved()
    {
        // Arrange
        var expectedRequestId = "test-request-id-123";
        var errorViewModel = new ErrorViewModel();

        // Act
        errorViewModel.RequestId = expectedRequestId;

        // Assert
        Assert.Equal(expectedRequestId, errorViewModel.RequestId);
    }
}