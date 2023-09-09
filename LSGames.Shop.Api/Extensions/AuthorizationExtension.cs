using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace LSGames.Shop.Api.Extensions
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection ConfigureAuthorization(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            //ValidateIssuer = true,
                            //ValidateAudience = true,
                            //ValidateLifetime = true,
                            //ValidateIssuerSigningKey = true,
                            //ValidIssuer = Configuration["JwtToken:Issuer"],
                            //ValidAudience = Configuration["JwtToken:Issuer"],
                            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtToken:SecuredKey"]))
                        };
                    });

            serviceCollection.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });

            return serviceCollection;
        }
    }
}
