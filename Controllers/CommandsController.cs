using System.Linq;
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
            if (_items.Count() > 0)
                return Ok(_mapper.Map<IEnumerable<CommandOutDto>>(_items));
            else
                return NoContent();
        }

        [HttpGet("{id}", Name = "GetCommandById")]
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new ErrorResponseDto(ex, false));
            }
        }

        [HttpPost]
        public async Task<ActionResult<CommandOutDto>> CreateCommand([FromBody] CommandInDto pCommand)
        {
            var commandToCreate = _mapper.Map<Command>(pCommand);
            await _repository.CreateCommandAsync(commandToCreate);
            await _repository.SaveChangesAsync();
            //neste caso como estamos criando um novo recurso, nós temos que retorná-lo. Uma maneira de fazê-lo:
            //o código do retorno é 201, e o corpo é o objeto criado no método
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandToCreate.Id }, _mapper.Map<CommandOutDto>(commandToCreate));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand([FromRoute] string id, [FromBody] CommandInDto pCommand)
        {
            var commandToUpdate = await _repository.GetCommandByIdAsync(new Guid(id));
            
            if(commandToUpdate == null)
                return NotFound();
            
            _mapper.Map(pCommand, commandToUpdate);

            await _repository.UpdateCommandAsync(commandToUpdate);
            await _repository.SaveChangesAsync();

            return NoContent();

        }
    }
}