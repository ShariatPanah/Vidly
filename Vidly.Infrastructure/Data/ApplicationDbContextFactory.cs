using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Vidly.Infrastructure.Data
{
    internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=VidlyDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False;");
            
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
