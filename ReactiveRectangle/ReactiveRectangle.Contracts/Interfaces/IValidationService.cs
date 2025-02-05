using ReactiveRectangle.Contracts.Models;

namespace ReactiveRectangle.Contracts.Interfaces;

public interface IValidationService
{
    Task<ValidationResult> ValidateRectangleAsync(double height, double width, CancellationToken cancellationToken = default);
}