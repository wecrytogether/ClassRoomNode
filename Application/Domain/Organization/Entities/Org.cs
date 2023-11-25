using System.Collections.ObjectModel;
using Application.Domain.Commons.Entities;
using Application.Domain.Commons.ValueObjects;
using Application.Domain.Organization.Exceptions;
using Application.Domain.Organization.ValueObjects;

namespace Application.Domain.Organization.Entities;

public sealed class Org : BaseEntity<OrgId>
{
    public OrgName Name { get; }

    #region ForeignKeys

    public UserId OwnerUserId { get; }

    #endregion

    #region Relationships
    
    private readonly List<OrgMember> _orgMembers;
    public ReadOnlyCollection<OrgMember> OrgMembers { get; }
    
    #endregion
    
    public Org(OrgName name, UserId ownerUserId)
    {
        Name = name;
        OwnerUserId = ownerUserId;
        
        _orgMembers = new List<OrgMember>();
        OrgMembers = _orgMembers.AsReadOnly();
    }
    
    public void AddNewMember(OrgMember newMember)
    {
        var isMemberExist = _orgMembers.Find(m => m.Id == newMember.Id || m.UserId == newMember.UserId) == null;
        if (isMemberExist)
            throw new OrgMemberAlreadyInTheOrgExc();
        
        _orgMembers.Add(newMember);
    }
    
    public void AddNewMember(UserId newMemberUserId)
    {
        AddNewMember(new OrgMember(newMemberUserId, this));
    }
    
    public void RemoveMember(OrgMemberId memberId)
    {
        var member = _orgMembers.Find(m => m.Id == memberId);
        if (member is null)
            throw new NotFoundOrgMemberExc();
        
        _orgMembers.Remove(member);
    }
}