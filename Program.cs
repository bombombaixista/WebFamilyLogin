using Microsoft.EntityFrameworkCore;
using WebFamilyLogin.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔗 Configuração do DbContext com MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36)) // ajuste conforme versão do seu MySQL
    ));

// Adiciona suporte a Controllers + Views (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔧 Configuração do pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error"); // redireciona erros para Login
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();   // habilita arquivos estáticos (css, js, imagens)
app.UseRouting();

app.UseAuthorization();

// 🔗 Rotas MVC (Login como página inicial)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
