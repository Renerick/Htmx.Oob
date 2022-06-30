var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.MapRazorPages();
app.MapControllers();

app.Run();
