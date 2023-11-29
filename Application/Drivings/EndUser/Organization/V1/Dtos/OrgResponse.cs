namespace Application.Drivings.EndUser.Organization.V1.Dtos;

public record OrgResponse(
    string Id,
    string Name,
    string OwnerUserId,
    DateTime CreatedAt);