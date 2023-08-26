using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Shared.DTO;

namespace Services
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponceDto<ToDoDto>> CreateToDo(ToDoCreateDto toDoCreateDto)
        {
            try
            {
                ToDo todo = new ToDo();
                todo = _mapper.Map<ToDo>(toDoCreateDto);

                await _unitOfWork.ToDo.AddAsync(todo);
                _unitOfWork.SaveAsync();

                return new ResponceDto<ToDoDto>()
                {
                    IsSuccess = true,
                    Message = "Successfully Created",
                    Data = _mapper.Map<ToDoDto>(toDoCreateDto)
                };
            }
            catch (Exception ex)
            {
                return new ResponceDto<ToDoDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponceDto<ToDoDto>> GetToDoById(int id)
        {
            try
            {
                var result = await _unitOfWork.ToDo.GetFirstOrDefaultAsync(a => a.Id == id,includeProperties: "ApplicationUser");
                return new ResponceDto<ToDoDto>
                {
                    IsSuccess = true,
                    Data = _mapper.Map<ToDoDto>(result),
                };
            }
            catch (Exception ex)
            {
                return new ResponceDto<ToDoDto>()
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }

        public async Task<ResponceDto<List<ToDoDto>>> GetToDos()
        {
            try
            {
                var results = await _unitOfWork.ToDo.GetAllAsync(includeProperties: "ApplicationUser");
                return new ResponceDto<List<ToDoDto>>
                {
                    Data = _mapper.Map<List<ToDoDto>>(results),
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {

                return new ResponceDto<List<ToDoDto>>()
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }

        public async Task<ResponceDto<ToDoDto>> UpdateToDo(ToDoUpdateDto toDoUpdateDto)
        {
            try
            {
                var result = await _unitOfWork.ToDo.GetFirstOrDefaultAsync(a => a.Id == toDoUpdateDto.Id);
                result.Name = toDoUpdateDto.Name;
                result.Description = toDoUpdateDto.Description;
                result.UserId = toDoUpdateDto.UserId;
                result.ToDoTaskId = toDoUpdateDto.ToDoTaskId;
                _unitOfWork.SaveAsync();

                return new ResponceDto<ToDoDto>()
                {
                    IsSuccess = true,
                    Message = "Successfully Updated",
                    Data = _mapper.Map<ToDoDto>(result),
                };

            }
            catch (Exception ex)
            {
                return new ResponceDto<ToDoDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponceDto<bool>> DeleteToDo(int id)
        {
            try
            {
                await _unitOfWork.ToDo.Remove(id);
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

        public async Task<ResponceDto<List<ToDoDto>>> GetToDosByUserId(Guid userId)
        {
            try
            {
                var result = await _unitOfWork.ToDo.GetAllAsync(a => a.UserId == userId, includeProperties: "ApplicationUser");
                return new ResponceDto<List<ToDoDto>>
                {
                    IsSuccess = true,
                    Data = _mapper.Map<List<ToDoDto>>(result),
                };
            }
            catch (Exception ex)
            {
                return new ResponceDto<List<ToDoDto>>()
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }
    }
}
