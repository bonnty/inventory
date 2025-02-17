using Microsoft.EntityFrameworkCore;
using Inventory.Data;
using Inventory.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Interactive render mode Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Provide layout, components, forms, etc.
builder.Services.AddMudServices();

// Register DbContext with SQLite
builder.Services.AddDbContext<InventoryDbContext>(options =>
		options.UseSqlite("Data Source=inventory.db"));

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapStaticAssets();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
