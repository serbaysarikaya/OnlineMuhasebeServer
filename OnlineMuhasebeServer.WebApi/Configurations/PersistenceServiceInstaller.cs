using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Persistance;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class PersistenceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            string connetionString = configuration.GetConnectionString(SectionName);
            services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(connetionString));

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(typeof(AssemblyReference).Assembly);

        }
    }
}
