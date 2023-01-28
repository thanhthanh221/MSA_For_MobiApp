using Notification.Hubs;
using Notification.Installers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallerServiceInAssembly(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(buider => {
        buider.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();

    });
}

app.UseAuthorization();
app.UseAuthorization();

app.MapHub<NotificationHub>("/notificationHub");

app.MapControllers();

app.Run();
