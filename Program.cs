using Microsoft.EntityFrameworkCore;
using Inventory.Data;
using Inventory.Components;
using MudBlazor.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Interactive render mode Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Provide layout, components, forms, etc.
builder.Services.AddMudServices();

// Register DbContext with SQLite
builder.Services.AddDbContext<InventoryDbContext>(options =>
		options.UseSqlite("Data Source=inventory.db"));

// Use one db for authentication
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=auth.db"));

// Add Identity with Cookie Authentication
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure authentication using cookies
builder.Services.ConfigureApplicationCookie(options => 
{
    options.LoginPath="/login";
    options.AccessDeniedPath="/access-denied";
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
