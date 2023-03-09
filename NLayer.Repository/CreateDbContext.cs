using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NLayer.Repository
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = "Data Source=RECEP;Initial Catalog=NLayerWebAPIDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
