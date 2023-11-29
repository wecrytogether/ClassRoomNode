namespace Application.Drivings.Commons.Models.Response;

public record ResponseWithPayLoad<TPayload> : IResponse
    where TPayload : notnull
{
    public required TPayload Payload { get; init; }
}

public record ResponseWithPayLoad<TPayload, TMetadata> 
    : ResponseWithPayLoad<TPayload>
    where TPayload : notnull
{
    public required TMetadata Metadata { get; init; }
}
