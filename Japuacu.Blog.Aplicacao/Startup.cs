using Japuacu.Blog.Aplicacao.Models;
using Japuacu.Blog.Negocio.Interfaces.Notificacoes;
using Japuacu.Blog.Negocio.Interfaces.Repositorios;
using Japuacu.Blog.Negocio.Interfaces.Servicos;
using Japuacu.Blog.Negocio.Notificacoes;
using Japuacu.Blog.Negocio.Servicos;
using Japuacu.Blog.Persistencia.Contexto;
using Japuacu.Blog.Persistencia.Repositorios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Japuacu.Blog.Aplicacao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Login/LoginUsuario/";

                    });

            services.AddDbContext<BlogContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IAutenticacao, Autenticacao>();

            services.AddScoped<BlogContext>();
            services.AddScoped<IAutorRepositorio, AutorRepositorio>();
            services.AddScoped<IComentarioRepositorio, ComentarioRepositorio>();
            services.AddScoped<IParagrafoRepositorio, ParagrafoRepositorio>();
            services.AddScoped<IPostRepositorio, PostRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            //Servi?os e Notificador
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IAutorServico, AutorServico>();
            services.AddScoped<IComentarioServico, ComentarioServico>();
            services.AddScoped<IParagrafoServico, ParagrafoServico>();
            services.AddScoped<IPostServico, PostServico>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();

        }

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
            }
            
            
            app.UseStaticFiles();

            app.UseRouting();



            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
