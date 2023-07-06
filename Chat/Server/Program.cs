using Microsoft.AspNet.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Owin;
using Server;   // пространство имен класса ChatHub
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR(o =>
{
    o.EnableDetailedErrors = true;
    o.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB
});

var configuration = builder.Configuration;

var app = builder.Build();


app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");
app.Run();
