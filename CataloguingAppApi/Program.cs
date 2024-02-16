using CataloguingAppApi.Data;
using CataloguingAppApi.Model;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var corsPolicyName = "allowLocalhost";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
                      policy =>
                      {
                          policy.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Add services to the container.

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<CataloguingAppApi.Model.Collectable>("Collectables").EntityType.HasKey(e => e.Id);
    builder.EntitySet<CataloguingAppApi.Model.Image>("Images");
    builder.EntitySet<CataloguingAppApi.Data.Directory>("Directories").EntityType.HasKey(e => e.Hierarchynodeid);
    return builder.GetEdmModel();
}

builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("v1", GetEdmModel()).EnableQueryFeatures().EnableNoDollarQueryOptions = false);

builder.Services.AddDbContext<appContext>(opt =>
{
    opt.UseMySql(builder.Configuration.GetConnectionString("AppDb"),new MySqlServerVersion(new Version(8,0,28)));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Configuration.AddJsonFile();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
