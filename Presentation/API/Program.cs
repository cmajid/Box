using Box.API.Middleware;
using Box.Application.Services;
using Box.Contract.Interfaces.Services;
using Box.Data.EntityFramework;
using Box.Data.Repository.EFRepository;
using Box.Data.Repository.Interfaces;
using Box.Infrastructure.Security;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<UserRepository, EFUserRepository>();
builder.Services.AddScoped<UserService, CustomerService>();
builder.Services.AddScoped<DataFileRepository, EFDataFileRepository>();
builder.Services.AddScoped<DataFileService, BoundedDataFileService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    ValidateAudience = false,
    ValidateIssuer = false,
    IssuerSigningKey = CredentialHelper.GetSecurityKey(
        builder.Configuration.GetSection("AppSettings:SecureKey").Value!)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicyBuilder =>
   corsPolicyBuilder.WithOrigins("http://localhost:3000")
  .AllowAnyMethod()
  .AllowAnyHeader()
);

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

