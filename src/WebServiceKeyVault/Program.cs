using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using WebServiceKeyVault.Infrastructure;

namespace WebServiceKeyVault
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (builder.Environment.IsDevelopment() == false)
            {
                var secretClient = new SecretClient(new Uri(builder.Configuration["KeyVaultUri"]), new DefaultAzureCredential());
                builder.Configuration.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
            }

            // Add services to the container.

            builder.Services.Configure<BlobSettings>(builder.Configuration.GetSection(nameof(BlobSettings)));
            builder.Services.AddScoped<IBlobRepository, BlobRepository>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebServiceUnsafe", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI(c => c.DisplayRequestDuration());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
