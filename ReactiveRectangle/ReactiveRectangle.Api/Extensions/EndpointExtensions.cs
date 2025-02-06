using ReactiveRectangle.Contracts.DTOs;
using ReactiveRectangle.Contracts.Interfaces;

namespace ReactiveRectangle.Api.Extensions;

public static class EndpointExtensions
{
    public static WebApplication MapRectangleEndpoints(this WebApplication app)
    {
        app.MapPost("/api/rectangle/validate",
            async (RectangleDto rect, IRectangleService rectangleService, CancellationToken ct) =>
            {
                var result = await rectangleService.ValidateAndUpdateAsync(
                    rect.Height,
                    rect.Width,
                    ct);

                return Results.Ok(result);
            });

        return app;
    }
}