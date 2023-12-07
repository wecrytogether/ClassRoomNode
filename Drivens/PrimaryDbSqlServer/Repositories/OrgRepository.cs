﻿using Application.Domain.Organization.Entities;
using Application.Domain.Organization.ValueObjects;
using Application.Drivens.PrimaryDb.Repositories;

namespace PrimaryDbSqlServer.Repositories;

internal sealed record OrgRepository : BaseRepository<Org, OrgId>, IOrgRepository
{
    public OrgRepository(PrimaryDbSqlServerCtx dbCtx) : base(dbCtx)
    {
    }
}