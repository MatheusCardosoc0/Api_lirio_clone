using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Api.Utilities;
using Api.Services.Financeiro.CoinsService;
using Api.Services.Financeiro.PaymentTermsService.PaymentTermsService;
using Api.Services.Financeiro.PaymentTermsServices;
using Api.Services.Materiais.GrouProductService;
using Api.Services.Materiais.ProductService;
using Api.Services.Pessoal.CityService;
using Api.Services.Pessoal.GroupService;
using Api.Services.Pessoal.PersonService;
using Api.Services.Utilitarios.UserSystemService;
using Api.Services.Utilitarios;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(token =>
            {
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "https://localhost:7221/",
                    ValidAudience = "https://localhost:7221/",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true
                };
            });
       
            builder.Services.Configure<SystemDBConfiguration>(
               builder.Configuration.GetSection(nameof(SystemDBConfiguration)));
            builder.Services.AddSingleton<ISystemDBConfiguration>(sp =>
              sp.GetRequiredService<IOptions<SystemDBConfiguration>>().Value);
            builder.Services.AddSingleton<IMongoClient>(sp =>
              new MongoClient(builder.Configuration.GetValue<string>(
                  "SystemDBConfiguration:ConnectionString")));
            //------------------------------

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // PESSOAL
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<ICityService, CityService>();

            // MATERIAIS
            builder.Services.AddScoped<IGroupProductService, GroupProductService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            // FINANCEIRO
            builder.Services.AddScoped<IPaymentTermsService, PaymentTermsService>();
            builder.Services.AddScoped<ICoinsService, CoinsService>();

            // UTILITÁRIOS
            builder.Services.AddScoped<IUserSystemService, UserSystemService>();

            builder.Services.AddScoped<TokenService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyCorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}