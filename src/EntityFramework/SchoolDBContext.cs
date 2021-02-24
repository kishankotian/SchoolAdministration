using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Model.EntityModel;
using System.IO;

namespace EntityFramework
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
    }

    public class DesignTimeSchoolDbContextFactory : IDesignTimeDbContextFactory<SchoolDBContext>
    {
        public SchoolDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory
                        .GetCurrentDirectory())
                        .AddJsonFile(Directory.GetParent(Directory.GetCurrentDirectory()) + @"\SchoolAdministration\appsettings.json")
                        .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var builder = new DbContextOptionsBuilder<SchoolDBContext>();
            builder.UseSqlServer(connectionString);

            return new SchoolDBContext(builder.Options);
        }
    }
}
