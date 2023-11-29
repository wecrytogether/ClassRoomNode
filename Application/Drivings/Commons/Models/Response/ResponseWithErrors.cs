using System.Collections.ObjectModel;

namespace Application.Drivings.Commons.Models.Response;

public record ResponseWithErrors<TError, TExc> : IResponse
    where TError : notnull
    where TExc : Exception
{
    public string ErrorType { get; } = nameof(TExc);

    public Guid? TraceId { get; init; }

    public required ReadOnlyCollection<TError> Errors { get; init; }
}