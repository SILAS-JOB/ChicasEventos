
using ChicasEventos.Models;
using ChicasEventos.Services;

var builder = WebApplication.CreateBuilder(args);

var senderEmailTeste = builder.Configuration["EmailSettings:SenderEmail"];
Console.WriteLine($"--- [TESTE PROGRAM.CS] SenderEmail: {senderEmailTeste} ---");

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddSingleton<StaticDataService>();


var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
//Deploy main
// app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.Run();
