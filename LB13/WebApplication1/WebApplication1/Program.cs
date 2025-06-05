var builder = WebApplication.CreateBuilder(args);

// Додаємо підтримку контролерів і представлень (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Налаштування middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Налаштування маршрутів для MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Notes}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "create",
//    pattern: "{controller=Notes}/{action=Create}/{id?}");

//app.MapGet("/", () => "Hello World!");

app.Run();
