namespace ReactiveRectangle.Contracts.Models;

public record ValidationResult(bool IsValid, string ErrorMessage = null);