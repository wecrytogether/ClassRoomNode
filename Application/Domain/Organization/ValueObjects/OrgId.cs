using Application.Domain.Commons.ValueObjects;

namespace Application.Domain.Organization.ValueObjects;

public sealed record OrgId(Guid Val) : BaseId(Val);