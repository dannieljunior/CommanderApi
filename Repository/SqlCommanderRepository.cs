using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Comander.Contracts;
using Comander.Models;
using Microsoft.EntityFrameworkCore;
using Comander.Data;

namespace Comander.Repository
{
    public class SqlCommanderRepository : ICommanderRepository
    {
        private readonly CommanderContext _context;
        public SqlCommanderRepository(CommanderContext pContext)
        {
            _context = pContext;
        }

        public async Task<Command> CreateCommandAsync(Command pCommand)
        {
            if(pCommand == null)
                throw new ArgumentNullException(nameof(pCommand));
            _context.Commands.Add(pCommand);
            await SaveChangesAsync();
            return await Task.FromResult(pCommand);
        }

        public async Task<IEnumerable<Command>> GetAppCommandsAsync()
        {
            return await _context.Commands.ToListAsync();
        }

        public async Task<Command> GetCommandByIdAsync(Guid pId)
        {
            return await _context.Commands.FirstOrDefaultAsync(x => x.Id == pId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}