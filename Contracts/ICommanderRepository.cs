using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Comander.Models;

namespace Comander.Contracts
{
    public interface ICommanderRepository
    {
        Task<IEnumerable<Command>> GetAppCommandsAsync();
        Task<Command> GetCommandByIdAsync(Guid pId);
        Task<Command> CreateCommandAsync(Command pCommand);
        Task<bool> SaveChangesAsync();
    }
}