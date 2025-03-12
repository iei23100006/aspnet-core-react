using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using ASPReactCQRS.Application.Features.ActivityFeatures.CreateActivity;
using ASPReactCQRS.Application.Features.ActivityFeatures.DeleteActivity;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivities;
using ASPReactCQRS.Application.Features.ActivityFeatures.UndeleteActivity;
using ASPReactCQRS.Application.Features.ActivityFeatures.UpdateActivity;

namespace ASPReactCQRS.Web.Controllers.WebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ActivityController(ILogger<ActivityController> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger.LogDebug("ActivityController: {event}.", "Constructor");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetActivityResponse>> GetActivity(long id, CancellationToken token)
        {
            try
            {
                _logger.LogDebug("ActivityController: {event}.", "GetAsync");
                var response = await _mediator.Send(new GetActivityRequest(id), token);
                _logger.LogInformation("ActivityController: {event}. Response: {@Activity}", "GetAsync", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on GetActivity");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetActivityResponse>>> GetActivities(int pageIndex, int pageSize, bool isActive, CancellationToken token)
        {
            try
            {
                _logger.LogDebug("ActivityController: {event}.", "GetAllAsync");
                var response = await _mediator.Send(new GetActivitiesRequest(pageIndex, pageSize, isActive), token);
                _logger.LogInformation("ActivityController: {event}. Response: {@Activities}", "GetAllAsync", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on GetActivities");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetActivityResponse>> CreateActivity([FromBody] CreateActivityBody request, CancellationToken token)
        {
            try
            {
                // Get CreatedById from Claims
                var createdById = User.FindFirstValue("preferred_username")!;
                var claim = User;
                if (string.IsNullOrEmpty(createdById))
                {
                    return Unauthorized("CreatedById not found.");
                }

                var response = await _mediator.Send(new CreateActivityRequest
                (
                    request.ActivityName,
                    createdById
                ), token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on CreateActivity");
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<GetActivityResponse>> UpdateActivity([FromBody] UpdateActivityBody request, CancellationToken token)
        {
            try
            {
                // Get UpdatedById from Claims
                var updatedById = User.FindFirstValue("preferred_username")!;
                if (string.IsNullOrEmpty(updatedById))
                {
                    return Unauthorized("UpdatedById not found.");
                }

                var response = await _mediator.Send(new UpdateActivityRequest
                (
                    request,
                    updatedById
                )
                , token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on UpdateActivity");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GetActivityResponse>> DeleteActivity(long id, CancellationToken token)
        {
            try
            {
                // Get DeletedById from Claims
                var deletedById = User.FindFirstValue("preferred_username")!;
                if (string.IsNullOrEmpty(deletedById))
                {
                    return Unauthorized("DeletedById not found.");
                }

                var response = await _mediator.Send(new DeleteActivityRequest
                (
                    id,
                    deletedById
                ), token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Delete Activity");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetActivityResponse>> UndeleteActivity(long id, CancellationToken token)
        {
            try
            {
                // Get UpdatedById from Claims
                var updatedById = User.FindFirstValue("preferred_username")!;
                if (string.IsNullOrEmpty(updatedById))
                {
                    return Unauthorized("UpdatedById not found.");
                }

                var response = await _mediator.Send(new UndeleteActivityRequest
                (
                    id,
                    updatedById
                ), token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on UpdateActivity");
                return BadRequest(ex.Message);
            }
        }
    }
}