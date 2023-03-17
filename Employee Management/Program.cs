using Employee_Management.data;
using Employee_Management.Interface;
using Employee_Management.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection serviceCollection = builder.Services.AddDbContext<DataBase>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultCS")
        );
});

builder.Services.AddControllers();
builder.Services.AddScoped<Ijobdetails, jobdetailService>();
builder.Services.AddScoped<Iemployees, employeeService>();
builder.Services.AddScoped<Ileave, LeaveService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
