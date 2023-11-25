namespace Application.Drivings.Commons.Models.Requests;

public interface ICommandRequest<TBody> where TBody : notnull
{
    public TBody Body { get; init; }
}