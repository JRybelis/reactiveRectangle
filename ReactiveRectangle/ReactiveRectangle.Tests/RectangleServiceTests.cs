using Moq;
using ReactiveRectangle.Contracts.DTOs;
using ReactiveRectangle.Contracts.Exceptions;
using ReactiveRectangle.Contracts.Interfaces;
using ReactiveRectangle.Contracts.Models;
using ReactiveRectangle.Infrastructure.Interfaces;
using ReactiveRectangle.Services.Services;

namespace ReactiveRectangle.Tests;

public class RectangleServiceTests
{
    private readonly Mock<IJsonStorage> _storageMock;
    private readonly Mock<IValidationService> _validationServiceMock;
    private readonly RectangleService _sut;

    public RectangleServiceTests()
    {
        _storageMock = new Mock<IJsonStorage>();
        _validationServiceMock = new Mock<IValidationService>();
        _sut = new RectangleService(_storageMock.Object, _validationServiceMock.Object);
    }
    
    [Fact]
    public async Task ValidateAndUpdateAsync_ValidDimensions_UpdateFileStorageAndReturnPerimeter()
    {
        // Arrange
        const double height = 300;
        const double width = 130;
        const double expectedPerimeter = (height + width) * 2;

        _validationServiceMock.Setup(x => x.ValidateRectangleAsync(
                height, width, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(true));
        
        // Act
        var result = await _sut.ValidateAndUpdateAsync(height, width);
        
        // Assert
        Assert.True(result.IsValid);
        Assert.Equal(expectedPerimeter, result.Perimeter!.Value, 6);
        _storageMock.Verify(x => x.WriteAsync(
            It.Is<RectangleDto>(r => Math.Abs(r.Height - height) < 1e-6 && Math.Abs(r.Width - width) < 1e-6)),
            Times.Once);
    }

    [Fact]
    public async Task ValidateAndUpdateAsync_InvalidDimensions_ThrowValidationException()
    {
        // Arrange
        const string errorMessage = "Invalid dimensions";
        _validationServiceMock.Setup(x => x.ValidateRectangleAsync(
            It.IsAny<double>(), It.IsAny<double>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(false, errorMessage));
        
        // Act & Assert
        var exception =
            await Assert.ThrowsAsync<ValidationException>(() => _sut.ValidateAndUpdateAsync(height: 100, width: 500));
        
        Assert.Equal(errorMessage, exception.Message);
        _storageMock.Verify(x => x.WriteAsync(It.IsAny<RectangleDto>()), Times.Never);
    }
}