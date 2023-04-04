using GeekBurger.Orders.Extensions;
using GeekBurger.Orders.Repository;
using GeekBurger.Orders.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace GeekBurger.Orders
{
    public class Startup
    {
        public static IConfiguration Configuration;
        public IHostingEnvironment HostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Orders",
                    Version = "v1"
                });
            });

            services.AddDbContext<OrdersContext>(
                x =>
                {
                    x.UseInMemoryDatabase("geekburger-orders");
                    x.EnableSensitiveDataLogging(true);
                }
                    );
            
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IOrderChangedEventRepository, OrderChangedEventRepository>();
            services.AddSingleton<ICreditCardService, CreditCardService>();

            services.AddSingleton<IOrderChangedService, OrderChangedService>();
            services.AddSingleton<ILogService, LogService>();

            services.AddAutoMapper(typeof(OrdersContext));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, OrdersContext ordersContext)
        {
            if (HostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Orders");
            });

            using (var serviceScope = app
                       .ApplicationServices
                       .GetService<IServiceScopeFactory>()
                       .CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<OrdersContext>();
                context.Database.EnsureCreated();
            }

            ordersContext.Seed();
        }
    }
}