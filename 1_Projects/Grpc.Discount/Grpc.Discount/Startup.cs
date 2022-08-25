using Grpc.Discount.Repositories;
using Grpc.Discount.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Grpc.Discount
{
  public class Startup
  {    
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAutoMapper(typeof(Startup));
      services.AddGrpc();
      services.AddScoped<IDiscountRepository, DiscountRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        //Endpoint expostos.
        endpoints.MapGrpcService<DiscountService>();

        endpoints.MapGet("/", async context =>
              {
                await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
              });
      });
    }
  }
}
