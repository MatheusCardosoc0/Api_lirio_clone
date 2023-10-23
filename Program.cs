using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Api.Services.Pessoal.CityService;
using Api.Services.Pessoal.PersonService;
using Api.Services.Pessoal.GroupService;
using Api.Services.Materiais.ProductService;
using Api.Models.PersonModel;
using Api.Models.CityModel;
using Api.Models.GroupModel;
using Api.Models.Materiais.ProductModel;
using Api.Models.Materiais.GroupProductModel;
using Api.Services.Materiais.GrouProductService;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // PESSOAL ===============================================

            // For Person
            builder.Services.Configure<PersonStoreDatbaseSettings>(
                builder.Configuration.GetSection(nameof(PersonStoreDatbaseSettings)));
            builder.Services.AddSingleton<IPersonStoreDatbaseSettings>(sp =>
              sp.GetRequiredService<IOptions<PersonStoreDatbaseSettings>>().Value);
            builder.Services.AddSingleton<IMongoClient>(sp =>
              new MongoClient(builder.Configuration.GetValue<string>(
                  "PersonStoreDatbaseSettings:ConnectionString")));

            // For City
            builder.Services.Configure<CityStoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(CityStoreDatabaseSettings)));
            builder.Services.AddSingleton<ICityStoreDatabaseSettings>(sp =>
              sp.GetRequiredService<IOptions<CityStoreDatabaseSettings>>().Value);
            builder.Services.AddSingleton<IMongoClient>(sp =>
              new MongoClient(builder.Configuration.GetValue<string>(
                  "CityStoreDatabaseSettings:ConnectionString")));

            // For Group
            builder.Services.Configure<GroupStoreDatbaseSettings>(
                builder.Configuration.GetSection(nameof(GroupStoreDatbaseSettings)));
            builder.Services.AddSingleton<IGroupStoreDatbaseSettings>(sp =>
              sp.GetRequiredService<IOptions<GroupStoreDatbaseSettings>>().Value);
            builder.Services.AddSingleton<IMongoClient>(sp =>
             new MongoClient(builder.Configuration.GetValue<string>(
                 "GroupStoreDatbaseSettings:ConnectionString")));

            // MATERIAIS =============================================

            // For Product
            builder.Services.Configure<ProductStoreDatabaseSettings>(
               builder.Configuration.GetSection(nameof(ProductStoreDatabaseSettings)));
            builder.Services.AddSingleton<IProductStoreDatabaseSettings>(sp =>
              sp.GetRequiredService<IOptions<ProductStoreDatabaseSettings>>().Value);
            builder.Services.AddSingleton<IMongoClient>(sp =>
              new MongoClient(builder.Configuration.GetValue<string>(
                  "ProductStoreDatabaseSettings:ConnectionString")));

            // For GroupProduct
            builder.Services.Configure<GroupProductStoreDatabaseSettings>(
               builder.Configuration.GetSection(nameof(GroupProductStoreDatabaseSettings)));
            builder.Services.AddSingleton<IGroupProductStoreDatabaseSettings>(sp =>
              sp.GetRequiredService<IOptions<GroupProductStoreDatabaseSettings>>().Value);
            builder.Services.AddSingleton<IMongoClient>(sp =>
              new MongoClient(builder.Configuration.GetValue<string>(
                  "GroupProductStoreDatabaseSettings:ConnectionString")));

            //------------------------------

            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<ICityService, CityService>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IGroupProductService, GroupProductService>();

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