using Microsoft.EntityFrameworkCore;
using Shopi.Challange.Ordering.Data.EF;

namespace Shopi.Challange.Ordering.API.Core
{
    public static class EfTemplateContextExtensions
    {
        public static IServiceCollection AddEfTemplateContext(this IServiceCollection collection)
        {
            var configuration = collection.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetSection("ConnectionStrings:OrderConnection").Get<string>();
            
            collection.AddDbContext<OrderContext>(options => options.UseSqlServer(connectionString));

            collection.AddHealthChecks().AddDbContextCheck<OrderContext>();


            return collection;
        }
    }

}