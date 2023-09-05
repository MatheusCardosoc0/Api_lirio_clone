using Api.Models.PersonModel;
using Api.Services.Person;
using Api.Models.GroupModel;
using Api.Services.Group;
using Api.Models.CityModel;
using Api.Services.CityService;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // For Person
            builder.Services.Configure<PersonStoreDatbaseSettings>(
                builder.Configuration.GetSection(nameof(PersonStoreDatbaseSettings)));

            builder.Services.AddSingleton<IPersonStoreDatbaseSettings>(sp =>
              sp.GetRequiredService<IOptions<PersonStoreDatbaseSettings>>().Value);

            // For City
            builder.Services.Configure<CityStoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(CityStoreDatabaseSettings)));

            builder.Services.AddSingleton<ICityStoreDatabaseSettings>(sp =>
              sp.GetRequiredService<IOptions<CityStoreDatabaseSettings>>().Value);

            // For Group
            builder.Services.Configure<GroupStoreDatbaseSettings>(
                builder.Configuration.GetSection(nameof(GroupStoreDatbaseSettings)));

            builder.Services.AddSingleton<IGroupStoreDatbaseSettings>(sp =>
              sp.GetRequiredService<IOptions<GroupStoreDatbaseSettings>>().Value);

            // Mongo Client for Person
            builder.Services.AddSingleton<IMongoClient>(sp =>
              new MongoClient(builder.Configuration.GetValue<string>(
                  "PersonStoreDatbaseSettings:ConnectionString")));

            // Mongo Client for Group
            builder.Services.AddSingleton<IMongoClient>(sp =>
              new MongoClient(builder.Configuration.GetValue<string>(
                  "GroupStoreDatbaseSettings:ConnectionString")));

            // Mongo Client for City
            builder.Services.AddSingleton<IMongoClient>(sp =>
              new MongoClient(builder.Configuration.GetValue<string>(
                  "CityStoreDatabaseSettings:ConnectionString")));

            //------------------------------

            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<ICityService, CityService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

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
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}