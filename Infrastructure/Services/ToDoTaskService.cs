using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Shared.DTO;

namespace Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToDoTaskService( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponceDto<List<ToDoTaskDto>>> GetToDoTasks()
        {
            try
            {
                var results = await _unitOfWork.ToDoTask.GetAllAsync();
                return new ResponceDto<List<ToDoTaskDto>>
                {
                    IsSuccess = true,
                    Data = _mapper.Map<List<ToDoTaskDto>>(results),
                };
            }
            catch (Exception ex)
            {
                return new ResponceDto<List<ToDoTaskDto>>()
                {
                    Message = ex.Message,
                    IsSuccess = false
                }; 
            }
        }

        public async Task<ResponceDto<ToDoTaskDto>> GetToDoTaskById(int id)
        {
            try
            {
                var result = await _unitOfWork.ToDoTask.GetFirstOrDefaultAsync(a => a.Id == id);
                return new ResponceDto<ToDoTaskDto>
                {
                    IsSuccess = true,
                    Data = _mapper.Map<ToDoTaskDto>(result),
                };
            }
            catch (Exception ex)
            {
                return new ResponceDto<ToDoTaskDto>()
                {
                    Message = ex.Message,
                    IsSuccess = false
                }; 
            }
        }
       
        public async Task<ResponceDto<ToDoTaskDto>> CreateToDoTask(ToDoTaskCreateDto toDoTaskCreateDto)
        {
            try
            {
                ToDoTask toDoTask = new();
                toDoTask = _mapper.Map<ToDoTask>(toDoTaskCreateDto);
                await _unitOfWork.ToDoTask.AddAsync(toDoTask);
                _unitOfWork.SaveAsync();

                return new ResponceDto<ToDoTaskDto>()
                {
                    IsSuccess = true,
                    Message = "Successfully Created",
                    Data = _mapper.Map<ToDoTaskDto>(toDoTask)
                };
            }
            catch (Exception ex)
            {
                return new ResponceDto<ToDoTaskDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponceDto<ToDoTaskDto>> UpdateToDoTask(ToDoTaskUpdateDto toDoTaskUpdateDto)
        {
            try
            {
                var result = await _unitOfWork.ToDoTask.GetFirstOrDefaultAsync(a => a.Id == toDoTaskUpdateDto.Id);
                result.Name = toDoTaskUpdateDto.Name;
                result.Description = toDoTaskUpdateDto.Description;
                result.StartDate = toDoTaskUpdateDto.StartDate;
                result.EndDate = toDoTaskUpdateDto.EndDate;
                result.Status = toDoTaskUpdateDto.Status;
                _unitOfWork.SaveAsync();

                return new ResponceDto<ToDoTaskDto>()
                {
                    IsSuccess = true,
                    Message = "Successfully Updated",
                    Data = _mapper.Map<ToDoTaskDto>(result),
                };

            }
            catch (Exception ex)
            {
                return new ResponceDto<ToDoTaskDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
       
        public async Task<ResponceDto<bool>> DeleteToDoTask(int id)
        {
            try
            {
                await _unitOfWork.ToDoTask.Remove(id);
                _unitOfWork.SaveAsync();
                return new ResponceDto<bool>
                {
                    IsSuccess = true,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new ResponceDto<bool>()
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }

    }
}
