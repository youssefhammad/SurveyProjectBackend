using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurveyProject.Core.Interfaces;
using SurveyProject.Core.Mapping;
using SurveyProject.Infrastructure.Data;
using SurveyProject.Infrastructure.Repositories;
using SurveyProject.Infrastructure.UnitOfWork;
using SurveyProject.Services.Implementations;
using SurveyProject.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
    builder =>
    {
        builder.WithOrigins("http://localhost:3000") 
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials(); 
    });
});

builder.Services.AddDbContext<SurveyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ISurveyService, SurveyService>();

builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddScoped<IQuestionTypeService, QuestionTypeService>();

builder.Services.AddScoped<IRespondentService, RespondentService>();

var mapperConfig = AutoMapperConfig.Configure();
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
