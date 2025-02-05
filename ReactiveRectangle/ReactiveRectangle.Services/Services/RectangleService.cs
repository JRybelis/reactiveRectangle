using System.ComponentModel.DataAnnotations;
using ReactiveRectangle.Api.DTOs;
using ReactiveRectangle.Core.Models;
using ReactiveRectangle.Infrastructure.Interfaces;
using ReactiveRectangle.Services.Interfaces;

namespace ReactiveRectangle.Services.Services;

public class RectangleService(IJsonStorage storage, IValidationService validationService) : IRectangleService
{
    private static readonly SemaphoreSlim Semaphore = new(1, 1);
    
    public async Task<ValidationResultDto> ValidateAndUpdateAsync(double height, double width,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validationService.ValidateRectangleAsync(height, width, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ErrorMessage ??
                                          "Validation of the rectangle dimensions failed");
        }
        
        var rectangle = new Rectangle(height, width);
        
        await Semaphore.WaitAsync(cancellationToken);
        try
        {
            await storage.WriteAsync(new RectangleDto(
                Height: height,
                Width: width));
        }
        finally
        {
            Semaphore.Release();
        }

        return new ValidationResultDto(
            IsValid: true,
            Perimeter: rectangle.Perimeter);
    }
}