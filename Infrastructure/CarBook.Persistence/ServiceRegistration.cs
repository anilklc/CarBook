using CarBook.Application.Interfaces.Repositories;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarBookDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
            services.AddScoped<IAboutReadRepository, AboutReadRepository>();
            services.AddScoped<IAboutWriteRepository, AboutWriteRepository>();
            services.AddScoped<IBannerReadRepository, BannerReadRepository>();
            services.AddScoped<IBannerWriteRepository, BannerWriteRepository>();
            services.AddScoped<ICarReadRepository, CarReadRepository>();
            services.AddScoped<ICarWriteRepository, CarWriteRepository>();
            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<IContactReadRepository, ContactReadRepository>();
            services.AddScoped<IContactWriteRepository, ContactWriteRepository>();
            services.AddScoped<IFeatureReadRepository, FeatureReadRepository>();
            services.AddScoped<IFeatureWriteRepository, FeatureWriteRepository>();
            services.AddScoped<IFooterAddressReadRepository, FooterAddressReadRepository>();
            services.AddScoped<IFooterAddressWriteRepository, FooterAddressWriteRepository>();
            services.AddScoped<ILocationReadRepository, LocationReadRepository>();
            services.AddScoped<ILocationWriteRepository, LocationWriteRepository>();
            services.AddScoped<IPricingReadRepository, PricingReadRepository>();
            services.AddScoped<IPricingWriteRepository, PricingWriteRepository>();
            services.AddScoped<IServiceReadRepository, ServiceReadRepository>();
            services.AddScoped<IServiceWriteRepository, ServiceWriteRepository>();
            services.AddScoped<ISocialMediaReadRepository, SocialMediaReadRepository>();
            services.AddScoped<ISocialMediaWriteRepository, SocialMediaWriteRepository>();
            services.AddScoped<ITestimonialReadRepository, TestimonialReadRepository>();
            services.AddScoped<ITestimonialWriteRepository, TestimonialWriteRepository>();
            services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();
            services.AddScoped<IBlogReadRepository, BlogReadRepository>();
            services.AddScoped<IBlogWriteRepository, BlogWriteRepository>();
        }
    }
}
