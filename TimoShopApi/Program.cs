using AutoMapper;
using TimoShopApi.Configurations;
using TimoShopApi.Mappers;
using TimoShopApi.Services;

var corsPolicyName = "AllowLocalhost";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy(corsPolicyName, builder =>
{
    builder
        .WithOrigins("http://localhost:4200", "https://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.Configure<DatabaseConfiguration>(builder.Configuration.GetSection("Database"));

 IMapper mapper = new MapperConfiguration(mc =>
 {
     mc.AddProfile(new ProductMapperProfile());
 })
    .CreateMapper();

 builder.Services.AddSingleton(mapper);

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
