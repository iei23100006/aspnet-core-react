using ASPReactCQRS.Application;
using ASPReactCQRS.Web.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ASPReactCQRS.Web.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();
builder.Services.AddHttpContextAccessor();

var jwtBearerScheme = new OpenApiSecurityScheme
{
	Name = "Authorization",
	In = ParameterLocation.Header,
	Type = SecuritySchemeType.ApiKey,
	Scheme = "Bearer",
	// BearerFormat = "JWT",
	Description = "Enter the Bearer Authorization string as following: `Bearer {token}`",
};

var jwtBearerRequirement = new OpenApiSecurityRequirement
{
	{
		new OpenApiSecurityScheme
		{
			Name = "Bearer",
			In = ParameterLocation.Header,
			Reference = new OpenApiReference
			{
				Id = "Bearer",
				Type = ReferenceType.SecurityScheme
			}
		},
		new List<string>()
	}
};

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", jwtBearerScheme);
    options.AddSecurityRequirement(jwtBearerRequirement);
    options.CustomSchemaIds(type => type.ToString());
});

builder.Services.AddHealthChecks();
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	//options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
	var config = builder.Configuration.GetSection("AuthenticationSettings").Get<AuthenticationSetting>();
	if (config != null)
	{
		opt.Authority = config.Authority;
		opt.Audience = config.ClientId;
		opt.RequireHttpsMetadata = false;
		opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
		{
			ValidIssuer = config.Authority,
			ValidAudience = config.ClientId,
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = false,
			ValidateIssuerSigningKey = true
		};
	}
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.OAuthClientId("swagger");
        c.OAuthClientSecret("swagger");
        c.OAuthAppName("Swagger UI");
        c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
    });
    app.Use(async (context, next) =>
    {
        if (context.Request.Path.StartsWithSegments("/api-docs"))
        {
            context.Response.Redirect($"/swagger/index.html?url=/swagger/v1/swagger.json");
            return;
        }

        await next.Invoke();
    });
}

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseErrorHandler();
app.UseCors();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapFallbackToFile("index.html");

app.Run();

