using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.DbContexts
{
    public static class DbContextSetupExtensions
    {
        /// <summary>
        /// Adds the library DbContext to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="connectionString">The connection string for the database.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddLibraryDbContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.CommandTimeout(300);
                    sqlServerOptionsAction.EnableRetryOnFailure(5);
                    sqlServerOptionsAction.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
            });
            return services;
        }
    }
}
