using Microsoft.EntityFrameworkCore;
using SimpsonsApi.Data;
using SimpsonsApi.Models;
using SimpsonsApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables(prefix: "SIMPSONSAPI_");
var connectionString = builder.Configuration["MariaDB:ConnectionString"];
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddTransient<IQueryRepository, CharacterQueryRepository>();
builder.Services.AddTransient<ICommandRepository, CharacterCommandRepository>();
// builder.Services.AddControllers();
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("CorsPolicy", b =>
//         b.AllowAnyOrigin()
//          .AllowAnyMethod()
//          .AllowAnyHeader());
// });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
// app.UseAuthorization();
app.MapControllers();
app.Run();