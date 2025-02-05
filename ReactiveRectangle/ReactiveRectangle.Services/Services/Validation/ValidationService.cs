using ReactiveRectangle.Contracts.Interfaces;
using ReactiveRectangle.Contracts.Models;

namespace ReactiveRectangle.Services.Services.Validation;

public class ValidationService : IValidationService
{
    private const int ValidationDelaySeconds = 10;
    
    public async Task<ValidationResult> ValidateRectangleAsync(
        double height, double width, CancellationToken cancellationToken = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(ValidationDelaySeconds), cancellationToken);

        if (width > height)
        {
            return new ValidationResult( false,"Width must be less or equal to Height");
        }

        if (width <= 0 || height <= 0)
        {
            return new ValidationResult(false,"Both height and width dimensions must be greater than 0");
        }

        return new ValidationResult(true);
    }
}