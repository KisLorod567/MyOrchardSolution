using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ���������� �������� Orchard Core CMS
builder.Services.AddOrchardCms();

// ���������� Razor Pages ��������, ���� ��� ��� ��� ��� �����
builder.Services.AddRazorPages();

var app = builder.Build();

// ��������� ��������� HTTP ��������.
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

// ����������� OrchardCore ��� ����� ��������� ��������.
app.UseOrchardCore();

app.UseAuthorization();

// ���� �� ������ ������������ Razor Pages ������ � Orchard Core,
// ���������������� ��������� ������:
// app.MapRazorPages();

app.Run();
