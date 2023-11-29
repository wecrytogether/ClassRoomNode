using Application.Drivings.EndUser.Organization.V1.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApi.Controllers.EndUser.V1;

public class OrgsController : ControllerBase
{
    public OrgsController(ISender mediatRSender) : base(mediatRSender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var accessToken = "";
        
        var res = await MediatRSender.Send(new CreateOrgCommand
        {
            Body = new CreateOrgBody("hahha", new List<string>()),
            AccessToken = accessToken
        });
        
        return Ok(res);
    }
}