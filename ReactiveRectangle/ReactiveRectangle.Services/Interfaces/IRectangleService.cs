using ReactiveRectangle.Api.DTOs;

namespace ReactiveRectangle.Services.Interfaces;

public interface IRectangleService
{
    Task<ValidationResultDto> ValidateAndUpdateAsync(double height, double width,
        CancellationToken cancellationToken = default);
}