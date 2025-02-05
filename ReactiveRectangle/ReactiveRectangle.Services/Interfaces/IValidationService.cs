using ReactiveRectangle.Services.Models;

namespace ReactiveRectangle.Services.Interfaces;

public interface IValidationService
{
    Task<ValidationResult> ValidateRectangleAsync(double height, double width, CancellationToken cancellationToken = default);
}