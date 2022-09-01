using System;
using Api.Basket.ExternalService;
using Basket.API.Repositories;
using Grpc.Discount.Protos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api.Basket
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

      services.AddStackExchangeRedisCache(op =>
      {
        op.Configuration = Configuration.GetValue<string>("CacheSeetings:ConnectionString");

      });


      services.AddScoped<IBasketRepository, BasketRepository>();
      services.AddScoped<DiscountGrpcService>();

      //registrado o serviço GRPC que ela irá consumir.
      services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
          options => options.Address = new Uri(Configuration["GrpcSettings:DiscountUrl"]
          ));

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api.Basket", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api.Basket v1"));
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
