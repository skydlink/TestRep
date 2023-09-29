using AzureTestMVC.Utilities;
using Hangfire;
using Hangfire.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Hangfire
builder.Services.AddHangfire(x => x.UsePostgreSqlStorage("User ID=test_server;Password=redman123$;Host=load-test-server.postgres.database.azure.com;Port=5432;Database=azure_test;Timeout=500;", new PostgreSqlStorageOptions()
{
    PrepareSchemaIfNecessary = true,
    SchemaName = "hangfire",
}));

builder.Services.AddHostedService<HangfireHostedService>();


//builder.Services.AddHangfire().
builder.Services.AddHangfireServer();

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

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    AppPath = "/",
    Authorization = new[] { new HangFireAuthorizationFilter() }
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "TestEndpoint",
    pattern: "test/",
    defaults: new { controller = "Test", action = "PerformTest" });

app.Run();
