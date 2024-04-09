using Almoxarifado.Conexao;
using Almoxarifado.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almoxarifado
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Registrar o servi�o InternetService
            services.AddScoped<InternetService>();

            // Adicionar suporte ao acesso ao HttpContext
            services.AddHttpContextAccessor();

            services.AddSession(options =>
            {
                // Definir tempo de expira��o da sess�o
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                // Configurar o cookie da sess�o
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<BaseContext>(options =>
                options.UseSqlServer("Data Source=DESKTOP-2MLSNHE\\SQLEXPRESS;Initial Catalog=DB_ALMOXARIFADO;Integrated Security=True;"));

            // Outros servi�os
            services.AddControllersWithViews();

           /* services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();*/
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /* public void ConfigureServices(IServiceCollection services)
         {
             services.AddControllersWithViews();
         } */

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");

                /*---------------------------------------------------------------*/

                // Caminhos da tela de menu

                // Caminho para fun�oes de Administration
                endpoints.MapControllerRoute(
                    name: "administration",
                 pattern: "Administrator/Administration", // Rota para a p�gina de administra��o
                defaults: new { controller = "Menu", action = "Administration" });


                // Caminho para fun�oes de RH

                endpoints.MapControllerRoute(
                    name: "hr",
                 pattern: "HR/HumanResource", // Rota para a p�gina de RH
                defaults: new { controller = "Menu", action = "HR" });

                // Caminho Para fun�oes de Maquinas

                endpoints.MapControllerRoute(
                    name: "machines",
                 pattern: "Machines/Machines", // Rota para a p�gina de Maquinas
                defaults: new { controller = "Menu", action = "Machines" });

                // Caminho para fun�oes de Veiculos

                endpoints.MapControllerRoute(
                    name: "vehicles",
                 pattern: "Vehicles/Vehicles", // Rota para a p�gina de Veiculos
                defaults: new { controller = "Menu", action = "Vehicles" });

                // Caminho para fun�oes de Ferramentas

                endpoints.MapControllerRoute(
                    name: "tools",
                 pattern: "Tools/Tools", // Rota para a p�gina de Ferramentas
                defaults: new { controller = "Menu", action = "Tools" });

                endpoints.MapControllerRoute(
                    name: "logout",
                 pattern: "Logout/Logout", // Rota para a p�gina de Logout
                defaults: new { controller = "Logout", action = "Logout" });

                /*---------------------------------------------------------------*/

                // Caminhos da tela de Administra��o

                endpoints.MapControllerRoute(
                    name: "register",
                 pattern: "Administrator/UserRegister", // Rota para a p�gina de Cadastro
                defaults: new { controller = "Admin", action = "UserRegister" });

                endpoints.MapControllerRoute(
                    name: "voltar",
                 pattern: "Menu/Menu", // Rota para a p�gina de Logout
                defaults: new { controller = "Login", action = "Index" });
            });
        }
    }
}
