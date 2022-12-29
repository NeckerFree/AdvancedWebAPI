using AWA.Repository;
using AWA.Services;
using AWA.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("AdventureWorksConnection")?? "";
builder.Services.AddDIServices(connectionString);
builder.Services.AddScoped<IPersonService, PersonService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getAllPeople", async (IPersonService personService) =>
{
  return await personService.GetAllPeople();
}); 



app.Run();

