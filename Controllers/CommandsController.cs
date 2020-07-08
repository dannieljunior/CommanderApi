using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Comander.Dto;
using AutoMapper;
using Comander.Contracts;
using Comander.Models;

namespace Comander.Controllers
{
    [Route("api/command")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepository commanderRepository, IMapper mapper)
        {
            _repository = commanderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandOutDto>>> GetAllCommands()
        {
            var _items = await _repository.GetAppCommandsAsync();
            return Ok(_mapper.Map<IEnumerable<CommandOutDto>>(_items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommandOutDto>> GetCommandById([FromRoute] string id)
        {
            try
            {
                var _id = new Guid(id);
                var command = await _repository.GetCommandByIdAsync(_id);
                if (command != null)
                    return Ok(_mapper.Map<CommandOutDto>(command));
                else
                    return NoContent();
            }
            catch (Exception erro)
            {
                 return StatusCode(StatusCodes.Status500InternalServerError,
                                   new ErrorResponseDto(erro, false));
            }
        }

        [HttpPost]
        public async Task<ActionResult<CommandOutDto>> CreateCommand([FromBody] CommandInDto pCommand)
        {
            try{
                var commandCreated = await _repository.CreateCommandAsync(_mapper.Map<Command>(pCommand));
                return Ok(_mapper.Map<CommandOutDto>(commandCreated));
            }
            catch(Exception erro){
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new ErrorResponseDto(erro, false));
            }
        }
    }
}