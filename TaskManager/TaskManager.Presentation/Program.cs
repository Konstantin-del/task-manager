
using Microsoft.EntityFrameworkCore;
using TaskManager.Application;
using TaskManager.Persistence;
using TaskManager.Application.Mapping;
using TaskManager.Presentation.Mappings;
using FluentValidation.AspNetCore;
using FluentValidation;
using TaskManager.Presentation.Models.Validators;

ILoggerFactory MyLoggerFactory = LoggerFactory.Create(build =>
{ build.AddConsole(); });

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AddTaskRequestValidator>();

builder.Services.AddDbContext<TaskContext>(
    options => options.UseLoggerFactory(MyLoggerFactory).UseFirebird(
        "User=fred;Password=123456;Database=/var/lib/firebird/data/db.fdb;DataSource=172.17.0.2;Port=3050;Dialect=3;"));

builder.Services.AddAutoMapper(
    typeof(TaskMapperProfile),
    typeof(ControllerTaskMapperProfile)
    );

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
