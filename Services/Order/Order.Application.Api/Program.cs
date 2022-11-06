using Order.Application.Api.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Service DI/IOC
builder.Services.InstallerServiceInAssembly(builder.Configuration);

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
