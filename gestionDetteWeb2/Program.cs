using Cours.Data;
using Cours.Services;
using gestionDetteWeb2.Fixtures;
using gestionDetteWeb2.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure the database connection string
string connectionString = builder.Configuration.GetConnectionString("MysqlConnection")!;

builder.Services.AddDbContext<ApplicationDbContext>(options =>

            options.UseMySql(connectionString,

            new MySqlServerVersion(new Version(5, 7, 36))));


builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();

// Ex�cution du DataSeeder au d�marrage
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    seeder.Seed();
}

// Configure the services for the application.
/* 
    AddTransient => Cr�er � chaque fois
    AddScoped => Cr�er une instance unique pour la dur�e de la requ�te
    AddSingleton => Cr�er une instance unique pour toute la dur�e de l'application
 */
builder.Services.AddScoped<IClientService,ClientService>();




// Add services to the container.
builder.Services.AddControllersWithViews();


//var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Called Before Routing

app.UseRouting();

// Called After Routing

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();