using Business.Abstract;
using Business.Concrete;
using Business.Helper.AutoMapperProfiles;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTest
{
    public class Startup
    {
        public void ConfigureHost(IHostBuilder host) =>
    host.ConfigureHostConfiguration(config => config.AddJsonFile("appsettings.json"));

        public void ConfigureServices(IServiceCollection services, HostBuilderContext context) =>
                    services
            .AddScoped<IProductService, ProductManager>()
            .AddScoped<IProductCategoryService, ProductCategoryManager>()
            .AddAutoMapper(typeof(ProductProfile).Assembly)

            .AddAutoMapper(typeof(ProductCategoryProfile).Assembly)
            .AddAutoMapper(typeof(CustomProductProfile).Assembly)
            .AddScoped<IProductDal, EfProductDal>()
            .AddScoped<IProductCategoryDal, EfProductCategoryDal>();
    }
}
