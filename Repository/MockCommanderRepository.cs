using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Comander.Contracts;
using Comander.Models;

namespace Comander.Repository
{
    public class MockCommanderRepository : ICommanderRepository
    {
        private readonly List<Command> _commands;

        public MockCommanderRepository()
        {
            _commands = new List<Command>(){
                new Command{ Id = new Guid("7dea634e-4672-47bb-8e29-6225d79ca824"), HowTo = "Do anything 1", Line = "Command Line", Plataform = "Windows" },
                new Command{ Id = new Guid("6dcd94a0-ebde-4636-a583-a3cd9a102854"), HowTo = "Do anything 2", Line = "Command Line", Plataform = "Windows" },
                new Command{ Id = new Guid("ba10ec28-66d3-49e1-8ae8-38c64183c995"), HowTo = "Do anything 3", Line = "Command Line", Plataform = "Windows" },
            };
        }

        public Task CreateCommandAsync(Command pCommand)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Command>> GetAppCommandsAsync()
        {
            return await Task.FromResult( _commands);
        }

        public async Task<Command> GetCommandByIdAsync(Guid pId)
        {
            return await Task.FromResult(_commands.FirstOrDefault(x => x.Id == pId));
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCommandAsync(Command pCommand)
        {
            throw new NotImplementedException();
        }
    }
}