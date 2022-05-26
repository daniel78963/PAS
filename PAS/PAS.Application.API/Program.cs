using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PAS.Application.Interfaces;
using PAS.Application.Mapper;
using PAS.Application.Services;
using PAS.Domain.Core;
using PAS.Domain.Entities;
using PAS.Domain.Interfaces;
using PAS.Infrastructure.Data;
using PAS.Infrastructure.Data.Helpers;
using PAS.Infrastructure.Interfaces;
using PAS.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(cfg =>
{
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductCategoryDomain, ProductCategoryDomain>();
//builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<ISortHelper<ProductCategory>, SortHelper<ProductCategory>>();
//builder.Services.AddScoped<IDataContext, DataContext>();

#region Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<IGenericRepository<ProductCategory>, GenericRepository<ProductCategory>>();
//builder.Services.AddScoped<IProductCategoryRepository, IProductCategoryRepository>();
//builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API PAS", Version = "v1" });
});

//builder.AddSingleton<IConfiguration>(Configuration);
//builder.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
builder.Services.AddAutoMapper(typeof(MappingsProfile));

//builder.Services.AddTransient<DataContext>(new DataContext());
//builder.Services.AddScoped<IDataContext, DataContext>();
//builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
//builder.Services.AddTransient<ProductCategoryService>(new ProductCategoryService());
//builder.Services.AddScoped<IProductCategoryDomain, ProductCategoryDomain>();
//builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

//builder.Services.AddScoped<IMyDependency, MyDependency>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
