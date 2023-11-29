namespace Application.Drivings.Commons.Models.Requests;

public interface IPaginationQuery
{
    public int Size { get; init; }
    
    public int Page { get; init; }
}