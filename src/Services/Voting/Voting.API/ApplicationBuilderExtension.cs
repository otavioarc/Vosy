using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Voting.Infrastructure;

namespace Voting.API
{
    public static class ApplicationBuilderExtension
    {
        public static void UseMigration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetService<IServiceScopeFactory>()
                .CreateScope();

            using var context = serviceScope.ServiceProvider
                .GetService<VotingContext>();

            context.Database.Migrate();
        }
    }
}
