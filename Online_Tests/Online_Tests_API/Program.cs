using Online_Tests_API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.SetupCors();
builder.Services.SetupServices(builder.Environment, builder.Configuration);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("CorsPolicy");

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
