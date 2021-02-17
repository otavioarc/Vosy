using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Voting.Domain.Repositories;
using Voting.Infrastructure;
using Voting.Infrastructure.Repositories;

namespace Voting.API
{
    public static class Configurations
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<IVotingRepository, VotingRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();

            return services;
        }

        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            string connection = string.Format(
                configuration.GetConnectionString("VotingContext"),
                Environment.GetEnvironmentVariable("POSTGRES_DATABASE_URL"),
                Environment.GetEnvironmentVariable("POSTGRES_DATABASE_PORT"),
                Environment.GetEnvironmentVariable("POSTGRES_DATABASE_POOLING"),
                Environment.GetEnvironmentVariable("POSTGRES_DATABASE"),
                Environment.GetEnvironmentVariable("POSTGRES_USER"),
                Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));

            services.AddDbContext<VotingContext>(
                options => options.UseNpgsql(connection));

            return services;
        }
    }
}
