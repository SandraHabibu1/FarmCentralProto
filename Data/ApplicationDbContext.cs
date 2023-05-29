using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FarmCentralProto.Models;

namespace FarmCentralProto.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FarmCentralProto.Models.Farmer> Farmer { get; set; } = default!;
        public DbSet<FarmCentralProto.Models.Product> Product { get; set; } = default!;
        public DbSet<FarmCentralProto.Models.Employee> Employee { get; set; } = default!;
        public DbSet<FarmCentralProto.Models.BetterProduct> BetterProduct { get; set; } = default!;
    }
}