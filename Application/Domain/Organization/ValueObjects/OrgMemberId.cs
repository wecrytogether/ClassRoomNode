using Application.Domain.Commons.ValueObjects;

namespace Application.Domain.Organization.ValueObjects;

public record OrgMemberId(Guid Val) : BaseId(Val);