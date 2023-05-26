using Hellang.Middleware.ProblemDetails ;
using MarsRoverProject.Domain.Exceptions;
using MarsRoverProject.Infrastructure;
using MarsRoverProject.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddProblemDetails(setup =>
{
    setup.IncludeExceptionDetails = (ctx, exc) => builder.Environment.IsDevelopment() || builder.Environment.IsStaging();

    setup.Map<RoverException>(e => new RoverProblemDetails()
    {
        Title = e.Title,
        Detail = e.Detail,
        Status = StatusCodes.Status400BadRequest,
        Type = e.Type,
        Instance = e.Instance,
        ErrorCode = e.ErrorCode,
    });
});

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();
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

app.UseProblemDetails();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();