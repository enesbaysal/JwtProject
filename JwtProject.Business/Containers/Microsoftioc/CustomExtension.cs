using FluentValidation;
using jwtProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using jwtProject.DataAccess.Interfaces;
using jwtProject.Entities.Dtos.AppUserDto;
using jwtProject.Entities.Dtos.ProductDto;
using JwtProject.Business.Concrete;
using JwtProject.Business.Interfaces;
using JwtProject.Business.ValidationRules.FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.Containers.Microsoftioc
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGeneric<>), typeof(EfGenericRepository<>));

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProduct, EfProductRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUser, EfAppUserRepository>();

            services.AddScoped<IAppRoleService, AppRoleManager>();
            services.AddScoped<IAppRole, EfAppRoleRepository>();

            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();
            services.AddScoped<IAppUserRole, EfAppUserRoleRepository>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();
        }
    }
}
