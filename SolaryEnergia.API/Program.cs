using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using SolaryEnergia.API.Config;
using SolaryEnergia.DI.Ioc;
using SolaryEnergia.Domain.Security;
using SolaryEnergia.Infra.DataBase;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.RegistreReposotories();
builder.Services.RegistreServices();


builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes(Settings.ChaveSecreta);

builder.Services.RegisterAuthentication();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "SolaryEnergia.Api",
            Version = "v1",
            Description = "Api desenvolvida em C# Solary Energia!",
            Contact = new OpenApiContact
            {
                Name = "Eliane de Lima Henriqueta",
                Url = new Uri("https://github.com/Elianehenri"),
                Email = "elianehenriqueta@gmail.com",
            }
        }
    );
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                            Escreva 'Bearer' [espaço] e o token gerado no login na caixa abaixo.
                            Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
                {
                Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                    },
                },
            new List<string>()
        }
    });
});

///

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:7048")
            .AllowAnyMethod()
            .AllowAnyHeader();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ErrorMiddleware>();

app.Run();
