namespace ReactiveRectangle.Api.DTOs;

public record ValidationResultDto(bool IsValid, string ErrorMessage = null, double? Perimeter = null);
