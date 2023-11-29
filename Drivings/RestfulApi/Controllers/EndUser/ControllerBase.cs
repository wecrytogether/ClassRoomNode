using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApi.Controllers.EndUser;

[ApiController]
[Route("end-user/api/[controller]")]
public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
    protected readonly ISender MediatRSender;

    protected ControllerBase(ISender mediatRSender)
    {
        MediatRSender = mediatRSender;
    }
}