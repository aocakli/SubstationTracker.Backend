using System.Globalization;
using System.Text;
using SubstationTracker.Application;
using SubstationTracker.Application.Utilities.Middlewares;
using SubstationTracker.Infrastructure;
using SubstationTracker.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SubstationTracker.Infrastructure.Loggers.SeriLog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());

// Add services to the container.
builder.Services.AddResponseCompression();

builder.Services.AddControllers().AddMvcLocalization();

builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new("en-US"),
        new("tr-TR")
    };

    opt.DefaultRequestCulture = new RequestCulture("tr-TR");

    opt.SupportedCultures = supportedCultures;
    opt.SupportedUICultures = supportedCultures;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "http://188.132.128.139:4200").AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddInfrastructureDependencies();
builder.Services.AddApplicationDependencies();
builder.Services.AddPersistenceDependencies(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<KestrelServerOptions>(_opt => _opt.Limits.MaxRequestBodySize = long.MaxValue);

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;

    options.MultipartBodyLengthLimit = long.MaxValue;

    options.MultipartHeadersLengthLimit = int.MaxValue;
});

builder.Services.AddSerilogDependencies();

builder.IncludeLogger();

var app = builder.Build();

app.UseCors();

// Localization
var options = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCompression();

app.UseStaticFiles();

//app.UseDirectoryBrowser();

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();