using AWA.Repository;
using AWA.Services;
using AWA.Services.Interfaces;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("AdventureWorksConnection") ?? "";
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
app.MapGet("/getAdvancedPeople", (HttpContext http, IPersonService personService, [AsParameters] PersonParameters personParameters) =>
{
    if (!personParameters.ValidYearRange)
    {
        return Results.BadRequest("Max year of birth cannot be less than min year of birth");
    }
    var pagedPeople = personService.GetPagedPeople(personParameters);
    var metadata = new
    {
        pagedPeople.TotalCount,
        pagedPeople.PageSize,
        pagedPeople.CurrentPage,
        pagedPeople.TotalPages,
        pagedPeople.HasNext,
        pagedPeople.HasPrevious
    };
    http.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
    return Results.Ok(pagedPeople);
});


app.Run();

