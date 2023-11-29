using Application.Drivens.Identity.Enums;
using Application.Drivings.Commons.Models.Requests;
using Application.Drivings.EndUser.Organization.V1.Dtos;
using MediatR;

namespace Application.Drivings.EndUser.Organization.V1.UseCases;

public record CreateOrgBody(string Name, List<string> MemberUserIds);

public record CreateOrgCommand : AuthorizedCommandRequest<CreateOrgBody, OrgResponse>
{
    public override Role GetAllowedRole()
        => Role.EndUser;
}

public record CreateOrgHandler : IRequestHandler<CreateOrgCommand, OrgResponse>
{
    public async Task<OrgResponse> Handle(CreateOrgCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        return new OrgResponse(
            "ii",
            "name",
            "onwerId",
            DateTime.Now);
    }
}