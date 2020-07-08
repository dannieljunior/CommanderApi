using AutoMapper;
using Comander.Dto;
using Comander.Models;

namespace Comander.MappingProfiles
{
    public class CommandMappingProfile: Profile
    {
        public CommandMappingProfile()
        {
            CreateMap<Command, CommandOutDto>();
            CreateMap<CommandInDto, Command>();
        }
    }
}