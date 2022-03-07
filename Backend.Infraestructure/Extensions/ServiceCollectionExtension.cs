using Backend.Core.Interfaces;
using Backend.Core.Services;
using Backend.Infraestructure.Data;
using Backend.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Backend.Infraestructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(nameof(AppDbContext))));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuditReportService, AuditReportService>();
            services.AddTransient<IBankAccountService, BankAccountService>();
            services.AddTransient<IBankingTransactionService, BankingTransactionService>();
            services.AddTransient<IBankService, BankService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ITransactionTypeService, TransactionTypeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "API Sociedad Bancaria", Version = "v1" });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });
            return services;
        }
    }
}
