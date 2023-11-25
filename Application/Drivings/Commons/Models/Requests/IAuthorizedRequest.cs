using Application.Drivens.Identity.Dtos;
using Application.Drivens.Identity.Enums;

namespace Application.Drivings.Commons.Models.Requests;

public interface IAuthorizedRequest
{
    public string AccessToken { get; init; }
    
    public AuthorInfo AuthorInfo { get; set; }
    
    public Role GetAllowedRole();
}