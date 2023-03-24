using UrlShortener.WebApplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var webConfiguration = new WebConfigurations();
webConfiguration.ConfigureServices(builder.Services);

var app = builder.Build();
webConfiguration.ConfigureApplication(app);
app.Run();
