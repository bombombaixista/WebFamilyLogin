using Microsoft.EntityFrameworkCore;
using WebFamilyLogin.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controllers e views
builder.Services.AddControllersWithViews();

// Configura o DbContext com MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36)) // ajuste conforme versão do MySQL
    )
);

var app = builder.Build();

// Middleware padrão
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Rota padrão MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
