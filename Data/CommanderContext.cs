using Comander.Models;
using Microsoft.EntityFrameworkCore;

namespace Comander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
        }

        public virtual DbSet<Command> Commands { get; set; }
    }
}