using Microsoft.EntityFrameworkCore;
using RecordStore.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MyConn")
    ));
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options => {
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/Login/UserLogin";
    options.AccessDeniedPath = "/Login/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
});
builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminCredentialsRequired",policy => policy.RequireClaim("HR", "Admin"));
});
builder.Services.AddAuthorization(options => {
    options.AddPolicy("ManagerCredentials",
        policy => policy.RequireClaim("UserManager", "Manager"));
});
builder.Services.AddAuthorization(options => {
    options.AddPolicy("AssociateCredentials",
        policy => policy.RequireClaim("UserAssociate", "Associate"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
