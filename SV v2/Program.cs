var builder = WebApplication.CreateBuilder(args);

// Lägg till tjänster för MVC (Model-View-Controller)
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "flashcards",
    pattern: "Flashcards",
    defaults: new { controller = "Flashcard", action = "Index" });

app.Run();
