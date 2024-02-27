using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов Orchard Core CMS
builder.Services.AddOrchardCms();

// Добавление Razor Pages сервисов, если они вам все еще нужны
builder.Services.AddRazorPages();

var app = builder.Build();

// Настройка конвейера HTTP запросов.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Используйте OrchardCore как часть конвейера запросов.
app.UseOrchardCore();

app.UseAuthorization();

// Если вы хотите использовать Razor Pages вместе с Orchard Core,
// раскомментируйте следующие строки:
// app.MapRazorPages();

app.Run();
