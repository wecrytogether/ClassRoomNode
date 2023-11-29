namespace Application.Drivings.Commons.Models.Response;

public record ValidationErrorResponse
{
    public required string FieldName { get; init; }
    
    // this should be the name of the exception or the validation error type
    public required string ErrorType { get; init; }

    public required string Message { get; init; } 
}