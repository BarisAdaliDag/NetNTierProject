using FluentValidation;
using FluentValidation.AspNetCore;
using Project.Bll.DependencyResolvers;
using Project.WebApi.MapperResolvers;
using Project.WebApi.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContextService(); //Context class'ının middleware'e eklenmesi
builder.Services.AddRepositoryService(); //Repository servisinin middleware'e eklenmesi
builder.Services.AddManagerService(); //Manager servisinin middleware'e eklenmesi
builder.Services.AddDtoMapperService(); //Dto mapper servisinin middleware'e eklenmesi
builder.Services.AddVmMapperService(); //Vm Mapper servisinin middleware'e eklenmesi
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();
//ÖNEMLİ: Exception middleware EN BAŞTA olmalı!
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
