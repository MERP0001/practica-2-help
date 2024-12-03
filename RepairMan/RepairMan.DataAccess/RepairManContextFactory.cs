using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace RepairMan.DataAccess
{
    public class RepairManContextFactory : IDesignTimeDbContextFactory<RepairManContext>
    {
        public RepairManContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepairManContext>();
            var connectionString = "Server=server3.ferreirapablo.com;Database=repairman_db;Uid=repairman_db;Pwd=_9SJKDv4bfwvWSYG9snLS6Nd7nLjV;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.UseMicrosoftJson());
            optionsBuilder.EnableSensitiveDataLogging();
            return new RepairManContext(optionsBuilder.Options);
        }
    }
}
