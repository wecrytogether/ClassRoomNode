namespace Application.Drivings.Commons.Models.Requests;

public interface ISortableQuery
{
    public string SortBy { get; init; }
    
    public string SortOrder { get; init; }
}