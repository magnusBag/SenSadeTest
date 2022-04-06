using DataAccessLayer;
using EntityModels;
using Enviroment;
using sensade_project;

var builder = WebApplication.CreateBuilder(args);


IDataContext dataContext = new PgDataContext(ENV.connectionString);

// Add services to the container.
builder.Services.AddScoped(s => DaoFactory.Create<ParkingSpaceEntity>(dataContext));
builder.Services.AddScoped(s => DaoFactory.Create<ParkingLotEntity>(dataContext));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
