using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ASPReactCQRS.Web.Controllers
{
	[ApiController]
	public class AuthenticationSettingController : ControllerBase
	{
		private readonly ILogger<AuthenticationSettingController> _logger;
		private readonly IConfiguration _config;
		private readonly IHttpContextAccessor _contextAccessor;

		public AuthenticationSettingController(ILogger<AuthenticationSettingController> logger, IConfiguration configuration, IHttpContextAccessor contextAccessor)
		{
			_logger = logger;
			_config = configuration;
			_contextAccessor = contextAccessor;
			_logger.LogDebug("AuthenticationSettingController: {event}.", "Constructor");
		}
		/// <summary>
		/// Auth Setting for Keycloak authentication
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("auth-settings.json")]
		public IActionResult Get()
		{
			_logger.LogDebug("AuthenticationSettingController: {event}.", "Get");
			var config = _config.GetSection("AuthenticationSettings").Get<ViewModels.AuthenticationSetting>();

			// Check if config is not null
			if (config != null)
			{
				config.RedirectUri = $"{_contextAccessor.HttpContext?.Request.Scheme}://{_contextAccessor.HttpContext?.Request.Host}{_contextAccessor.HttpContext?.Request.PathBase}";

				var serializeOptions = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
					WriteIndented = true
				};
				return new JsonResult(config, serializeOptions);
			}
			return NoContent();
		}
	}
}
