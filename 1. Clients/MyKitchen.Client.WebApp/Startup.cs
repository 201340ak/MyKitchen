using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyKitchen.Accessors.Contexts;
using MyKitchen_Client_WebApp.Configuration;

namespace MyKitchen_Client_WebApp
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
            // services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            // services.AddDbContext<MyKitchen.Accessors.Contexts.UserDbContext>(options => 
            //     options.UseInMemoryDatabase("UserDb"));            
            // services.AddIdentity<IdentityUser, IdentityRole>()
            //         .AddEntityFrameworkStores<UserDbContext>();           

            // services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //         .AddCookie(o => o.LoginPath = "/account/login")
            //         .AddJwtBearer(options => options = new JwtBearerOptions
            //             {
            //                 TokenValidationParameters = GetJwtTokenValidationParameters()
            //             });

            // services.AddDbContext<MyKitchen.Accessors.Contexts.MyKitchenDbContext>(options => 
            //     options.UseSqlServer(Configuration.GetConnectionString("MyKitchenDb")));
            services.AddDbContext<MyKitchen.Accessors.Contexts.MyKitchenDbContext>(options => 
                options.UseInMemoryDatabase("MyKitchenDb"));
            services.AddScoped<MyKitchen.Managers.IRecipeManager, MyKitchen.Managers.RecipeManager>();
            services.AddScoped<MyKitchen.Accessors.IRecipeAccessor, MyKitchen.Accessors.RecipeAccessor>();
            
            services.AddScoped<MyKitchen.Accessors.IFoodAccessor, MyKitchen.Accessors.FoodAccessor>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MyKitchenDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            MyKitchenDbInitializer.Initialize(context);
        }

        private TokenValidationParameters GetJwtTokenValidationParameters()
        {
            var secretKey = Configuration.GetSection("JWTSettings:SecretKey").Value;
            var issuer = Configuration.GetSection("JWTSettings:Issuer").Value;
            var audience = Configuration.GetSection("JWTSettings:Audience").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = issuer,

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = audience
            };
        }
    }
}
