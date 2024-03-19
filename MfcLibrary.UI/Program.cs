using FluentValidation.AspNetCore;
using MfcLibrary.BLL.Abstract;
using MfcLibrary.BLL.Concrete;
using MfcLibrary.BLL.Validators;
using MfcLibrary.Core.MfcLibraryConnections;
using MfcLibrary.DAL.Abstract;
using MfcLibrary.DAL.Concrete;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("loggerOfLibrary.txt") // loglarý 'log.txt' dosyasýna yaz
    .CreateLogger();


// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddBookValidator>());

builder.Services.AddScoped<DapperConnection>();
builder.Services.AddScoped<MfcLibrary.Core.Mapper.AutoMapper>();

builder.Services.AddTransient<IBookDal, BookDal>();
builder.Services.AddTransient<IBookService, BookService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");

app.Run();
