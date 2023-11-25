using System.Diagnostics.CodeAnalysis;
using Application.Domain.Commons.Entities;
using Application.Domain.Commons.ValueObjects;
using Application.Domain.Organization.ValueObjects;

namespace Application.Domain.Organization.Entities;

public sealed class OrgMember : BaseEntity<OrgMemberId>
{
    #region ForeignKeys

    public UserId UserId { get; }
    
    #endregion
    
    #region ForeignRelationships
    
    public required Org Org { get; init; }
    
    #endregion

    public OrgMember(UserId userId)
    {
        UserId = userId;
    }
    
    [SetsRequiredMembers]
    public OrgMember(UserId userId, Org org)
    {
        UserId = userId;
        Org = org;
    }
}