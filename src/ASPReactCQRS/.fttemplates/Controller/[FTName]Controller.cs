using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using ASPReactCQRS.Application.Features.[FTName]Features.Create[FTName];
using ASPReactCQRS.Application.Features.[FTName]Features.Delete[FTName];
using ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName];
using ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]s;
using ASPReactCQRS.Application.Features.[FTName]Features.Undelete[FTName];
using ASPReactCQRS.Application.Features.[FTName]Features.Update[FTName];

namespace ASPReactCQRS.Web.Controllers.WebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class [FTName]Controller : ControllerBase
    {
        private readonly ILogger<[FTName]Controller> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public [FTName]Controller(ILogger<[FTName]Controller> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger.LogDebug("[FTName]Controller: {event}.", "Constructor");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Get[FTName]Response>> Get[FTName](long id, CancellationToken token)
        {
            try
            {
                _logger.LogDebug("[FTName]Controller: {event}.", "GetAsync");
                var response = await _mediator.Send(new Get[FTName]Request(id), token);
                _logger.LogInformation("[FTName]Controller: {event}. Response: {@[FTName]}", "GetAsync", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Get[FTName]");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Get[FTName]Response>>> Get[FTName]s(int pageIndex, int pageSize, bool isActive, CancellationToken token)
        {
            try
            {
                _logger.LogDebug("[FTName]Controller: {event}.", "GetAllAsync");
                var response = await _mediator.Send(new Get[FTName]sRequest(pageIndex, pageSize, isActive), token);
                _logger.LogInformation("[FTName]Controller: {event}. Response: {@[FTName]s}", "GetAllAsync", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Get[FTName]s");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Get[FTName]Response>> Create[FTName]([FromBody] Create[FTName]Body request, CancellationToken token)
        {
            try
            {
                // Get CreatedById from Claims
                var createdById = User.FindFirstValue("preferred_username")!;
                if (string.IsNullOrEmpty(createdById))
                {
                    return Unauthorized("CreatedById not found.");
                }

                var response = await _mediator.Send(new Create[FTName]Request
                (
                    request.[FTName]Name,
                    createdById
                ), token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Create[FTName]");
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Authorize]
        public async Task<ActionResult<Get[FTName]Response>> Update[FTName]([FromBody] Update[FTName]Body request, CancellationToken token)
        {
            try
            {
                // Get UpdatedById from Claims
                var updatedById = User.FindFirstValue("preferred_username")!;
                if (string.IsNullOrEmpty(updatedById))
                {
                    return Unauthorized("UpdatedById not found.");
                }

                var response = await _mediator.Send(new Update[FTName]Request
                (
                    request,
                    updatedById
                )
                , token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Update[FTName]");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Get[FTName]Response>> Delete[FTName](long id, CancellationToken token)
        {
            try
            {
                // Get DeletedById from Claims
                var deletedById = User.FindFirstValue("preferred_username")!;
                if (string.IsNullOrEmpty(deletedById))
                {
                    return Unauthorized("DeletedById not found.");
                }

                var response = await _mediator.Send(new Delete[FTName]Request
                (
                    id,
                    deletedById
                ), token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Delete [FTName]");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Get[FTName]Response>> Undelete[FTName](long id, CancellationToken token)
        {
            try
            {
                // Get UpdatedById from Claims
                var updatedById = User.FindFirstValue("preferred_username")!;
                if (string.IsNullOrEmpty(updatedById))
                {
                    return Unauthorized("UpdatedById not found.");
                }

                var response = await _mediator.Send(new Undelete[FTName]Request
                (
                    id,
                    updatedById
                ), token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Update[FTName]");
                return BadRequest(ex.Message);
            }
        }
    }
}