using TaskManager.Components;
using TaskManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ITaskService, TaskService>();

// Get the configuration for ports
var httpPort = 5235;
var httpsPort = 7286;

// Configure HTTPS
if (builder.Environment.IsDevelopment())
{
    builder.WebHost.UseUrls($"http://localhost:{httpPort}", $"https://localhost:{httpsPort}");
}

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
