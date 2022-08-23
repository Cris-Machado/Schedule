using ScheduleSystem.API.Presentation.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddNativeIoC(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseCors(builder =>
{
    builder
    .WithOrigins("http://localhost:8080", "http://localhost:8081")
    .AllowAnyHeader()
    .AllowCredentials()
    .AllowAnyMethod();
});
app.MapControllers();
app.Run();
