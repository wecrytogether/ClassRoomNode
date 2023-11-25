using Application.Drivens.Identity.Enums;
using Application.Drivings.Commons.Models.Requests;
using MediatR;

namespace Application.Drivings.Organization.V1.UseCases;

public record CreateOrgBody();

public record CreateOrgCommand : AuthorizedCommandRequest<CreateOrgBody, Unit>
{
    public override Role GetAllowedRole()
    {
        // TODO implement
        throw new NotImplementedException();
    }
}

public record CreateOrgHandler : IRequestHandler<CreateOrgCommand, Unit>
{
    public Task<Unit> Handle(CreateOrgCommand request, CancellationToken cancellationToken)
    {
        // TODO implement
        throw new NotImplementedException();
    }
}