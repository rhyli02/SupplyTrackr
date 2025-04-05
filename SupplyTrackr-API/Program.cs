using SupplyTrackr_API.Models;
using Microsoft.EntityFrameworkCore;
using SupplyTrackr_API.Repository.Interface;
using SupplyTrackr_API.Services.Implementation;
using SupplyTrackr_API.Services.Interface;



var builder = WebApplication.CreateBuilder(args);

//CORS Policy

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy",
        builder => builder
                    .WithOrigins("https://localhost:5173")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
});

// Add services to the container.

builder.Services.AddControllers();

// Configure SQLite and DbContext
builder.Services.AddDbContext<SupplyTrackrDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(typeof(Program));

// Register the generic repository for DI
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// Register the ProductService and its interface
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
builder.Services.AddScoped<ISalesOrderService, SalesOrderService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => {
                          policy.WithOrigins("http://localhost:5173") // Change this to your React app's URL
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}"); // Default controller is ProductController

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
