using System.Reflection;
using MediatR;
using MongoFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

builder.Services.AddScoped<UserDbContext>(
	provider => {
		var connectionString = builder.Configuration.GetConnectionString("MongoDb");
		var userDbContext = new UserDbContext(MongoDbConnection.FromConnectionString(connectionString));
		return userDbContext;
	}
);

builder.Services.AddScoped<WhatsAppService>();

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

await app.RunAsync();