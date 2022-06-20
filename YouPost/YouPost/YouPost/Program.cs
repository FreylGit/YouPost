using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YouPost.Areas.Identity.Data;
using YouPost.Data;
using YouPost.Repositories;
using YouPost.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("user",
         policy => policy.RequireRole(ClaimTypes.Role,"user"));
    options.AddPolicy("admin",
         policy => policy.RequireRole(ClaimTypes.Role, "admin"));
});
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Password.RequireDigit = true;//	Требуется число от 0 до 9 в пароле
    options.Password.RequireLowercase = true;//Требуется символ нижнего регистра в пароле
    options.Password.RequireNonAlphanumeric = false;//Требуется небуквенно-цифровой символ в пароле
    options.Password.RequireUppercase = false; //Требуется прописный символ в пароле
    options.User.RequireUniqueEmail = true;//Требуется, чтобы у каждого пользователя был уникальный адрес электронной почты
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//Внедрение зависимости бд
AddScoped();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
void AddScoped()
{
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}