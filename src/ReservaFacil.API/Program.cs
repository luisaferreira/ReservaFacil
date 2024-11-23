using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        var chaveSeguranca = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("ReservaFacil_JwtSettings_Secret"));
        var issuer = Environment.GetEnvironmentVariable("ReservaFacil_JwtSettings_Issuer");
        var audience = Environment.GetEnvironmentVariable("ReservaFacil_JwtSettings_Audience");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer, 
            ValidateAudience = true,
            ValidAudience = audience, 
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(chaveSeguranca)
        };
    });

builder.Services.AddScoped<TokenHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
