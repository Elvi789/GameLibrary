using GameLibrary.Data;
using GameLibrary.Repository;
using GameLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


#region
builder.Services.AddScoped<GameRepository, GameRepository>();
builder.Services.AddScoped<CategoryRepository, CategoryRepository>();
#endregion

#region

builder.Services.AddTransient<IGameServices, GameService>();
builder.Services.AddTransient<ICategoryServices, CategoryService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Game}/{action=Index}/{id?}"); 
// Meqe tek layouti i hoqem Home dhe Privacy, defauld route e vendosa tek controlleri Game dhe Actioni Index deri ne nje moment te dyte kur ta vendosim 
// tek login ose nje faqe tjeter.
app.MapRazorPages();

app.Run();
