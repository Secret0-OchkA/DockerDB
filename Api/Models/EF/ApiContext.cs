using DockerTestBD.Api.Models.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api.Models.EF
{
    /// <summary>
    /// ApiContext
    /// </summary>
    public class ApiContext : DbContext
    {
        /// <summary>
        /// Persons
        /// </summary>
        public DbSet<Person> Persons { get; set; } = null!;
        /// <summary>
        /// Companies
        /// </summary>
        public DbSet<Company> Companies { get; set; } = null!;
        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="options"></param>
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    }
}
