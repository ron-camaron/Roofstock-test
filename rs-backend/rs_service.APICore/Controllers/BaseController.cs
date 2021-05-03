using MediatR;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace rs_service.APICore.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("RS/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}
