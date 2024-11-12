using Lab4RPBDIS.Data;
using Lab4RPBDIS.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab4RPBDIS.Middleware;

namespace Lab4RPBDIS
{
    public class Program
    {
            public static void Main(string[] args)
            {
                WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
                IServiceCollection services = builder.Services;

                // ��������� ����������� ��� ������� � �� � �������������� EF
                string connectionString = builder.Configuration.GetConnectionString("MsSqlConnection");
                services.AddDbContext<TransportDbContext>(options => options.UseSqlServer(connectionString));
                builder.Services.AddDatabaseDeveloperPageExceptionFilter();

                builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<TransportDbContext>();

            // ���������� �����������
            services.AddMemoryCache();
                services.AddResponseCaching();
                services.AddControllers(options =>
                {
                    options.CacheProfiles.Add("Default",
                        new CacheProfile()
                        {
                            Duration = 2 * 16 + 240
                        });
                });
                // ���������� ��������� ������
                services.AddDistributedMemoryCache();
                services.AddSession();

                // ����������� ��������
                services.AddTransient<IViewModelService, HomeModelService>();

                // ������������� MVC
                services.AddControllersWithViews();

                WebApplication app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }

                // ��������� ��������� ����������� ������
                app.UseStaticFiles();

                // ��������� ��������� ������
                app.UseSession();

                // ������������� ���� ������
                app.UseDbInitializer();

                // �����������
                app.UseOperatinCache("Inspections 10");

                // ��������� �������������
                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();

                app.UseResponseCaching(); // ��������� ResponseCaching Middleware

                // ������������� ������������� ��������� � �������������
                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
        }
}
