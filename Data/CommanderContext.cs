using Comander.Models;
using Microsoft.EntityFrameworkCore;

namespace Comander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>()
                .Property(p => p.DataCriacao)
                .HasDefaultValueSql("getdate()");
        }

        public virtual DbSet<Command> Commands { get; set; }
    }
}