using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using ResourceServer.BoundedContext.Entities;

namespace ResourceServer.BoundedContext.Data
{
    [ExcludeFromCodeCoverage]
    public class CompanyContext : DbContext
    {
        public CompanyContext()
            : base("CompanyDB")
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}
