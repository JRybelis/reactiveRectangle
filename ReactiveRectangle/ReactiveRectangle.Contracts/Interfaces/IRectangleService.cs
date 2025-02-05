using ReactiveRectangle.Contracts.DTOs;

namespace ReactiveRectangle.Contracts.Interfaces;

public interface IRectangleService
{
    Task<ValidationResultDto> ValidateAndUpdateAsync(double height, double width,
        CancellationToken cancellationToken = default);
}