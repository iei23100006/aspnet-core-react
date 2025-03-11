using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ASPReactCQRS.Web.Extensions;
using ASPReactCQRS.Application.Features.UserFeatures.GetUser;
using Newtonsoft.Json;
using ASPReactCQRS.Web;
using ASPReactCQRS.Domain.Entities;
using ASPReactCQRS.Application.Features.UserFeatures.CreateUser;

namespace ASPReactCQRS.Web.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        public UserController(ILogger<UserController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
            _logger.LogDebug("UserController: {event}.", "Constructor");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<GetUserResponse>> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("UserController: {event}.", "GetAsync");
            // Find "ldap_id" Attribute on user profile first if any "ldap_id" attribute
            var userId = User.FindFirstValue("preferred_username");
            if(userId != null)
            {
                var existingUser = await _mediator.Send(new GetUserRequest(userId), cancellationToken);
                if (existingUser == null)
                {
                    var userInfo = new User()
                    {
                        Id = userId,
                        Name = User.FindFirstValue(ClaimTypes.Name) ?? User.FindFirstValue("name")!,
                        Email = User.FindFirstValue(ClaimTypes.Email),
                        VendorCode = User.FindFirstValue("vendorcode"),
                        Company = User.FindFirstValue("company"),
                    };
                    var newUser = await _mediator.Send(new CreateUserRequest(userId, userInfo.Name, userInfo.Email, userInfo.VendorCode, userInfo.Company));
                    return Ok(newUser);
                }
                return Ok(existingUser);
            }
            return BadRequest("User ID not found");
        }
    }
}
