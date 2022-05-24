// WebApplication is Kestrel
using ScheduleAPI.Adapters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ScheduleAdapter>(); // lazy instantiation, can also create it here explicitly

// ConfigureServices in Startup -- setting up the stuff that happens behinds the scenes before we start
var app = builder.Build();
// all "middleware" - the stuff here sees the incoming requests and outgoing responses

// Configure Method Startup
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run(); // blocking forever while loop
