namespace ReactiveRectangle.Services.Models;

public record ValidationResult(bool IsValid, string ErrorMessage = null);