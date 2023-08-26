using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace API.Controllers
{
    [Authorize]
    public class ToDoTaskController : ApiControllerBase
    {
        private readonly IToDoTaskService _toDoTaskService;

        public ToDoTaskController(IToDoTaskService toDoTaskService) 
        {
            _toDoTaskService = toDoTaskService;
        }

        [HttpPost("createToDoTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponceDto<ToDoTaskDto>>> CreateToDoTaskAsync(ToDoTaskCreateDto toDoTaskCreateDto)
        {
            var result = await _toDoTaskService.CreateToDoTask(toDoTaskCreateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponceDto<ToDoTaskDto>>> UpdateToDoTaskAsync(ToDoTaskUpdateDto toDoTaskUpdateDto)
        {
            var result = await _toDoTaskService.UpdateToDoTask(toDoTaskUpdateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponceDto<ToDoTaskDto>>> DeleteToDoTaskAsync(int id)
        {
            var result = await _toDoTaskService.DeleteToDoTask(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getToDoTaskById/{id:int}", Name = "GetToDoTaskByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponceDto<ToDoTaskDto>>> GetToDoTaskByIdAsync(int id)
        {
            var result = await _toDoTaskService.GetToDoTaskById(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getToDoTasks", Name = "GetToDoTasksAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponceDto<List<ToDoTaskDto>>>> GetToDoTasksAsync()
        {
            var result = await _toDoTaskService.GetToDoTasks();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
