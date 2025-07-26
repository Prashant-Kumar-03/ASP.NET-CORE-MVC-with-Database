using Microsoft.EntityFrameworkCore;
using ProjectMVCwithDatabase.Data;

var builder = WebApplication.CreateBuilder(args);

//step 5 
//adding servies manually for my databsase
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("PkProj")));
//above was added manually

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
