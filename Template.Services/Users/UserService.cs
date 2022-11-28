using AutoMapper;
using Template.Domain.Users;
using Template.Domain.Interfaces;
using Template.Models;
using Template.Utility.Resources;
using Template.Models.DTO.API;
using System.Net;

namespace Template.Services.Users
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork
            , IUserRepository userRepository
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TemplateAPIResponse<UserDTO>> AddUser(UserDTO user)
        {

            TemplateAPIResponse<UserDTO> templateAPIResponse = new TemplateAPIResponse<UserDTO>();

            try
            {
                var userData = _mapper.Map<User>(user);

                _userRepository.Add(userData);

                if (await _unitOfWork.CommitAsync() > 0)
                {
                    templateAPIResponse.Success = true;
                    templateAPIResponse.Data = user;
                    templateAPIResponse.Message = UserResource.AddSuccess;
                    templateAPIResponse.Status = HttpStatusCode.OK;
                }
                else
                {
                    templateAPIResponse.Success = false;
                    templateAPIResponse.Message = UserResource.AddFailed;
                    templateAPIResponse.Status = HttpStatusCode.InternalServerError;
                }
            }
            catch (Exception ex)
            {
                templateAPIResponse.Success = false;
                templateAPIResponse.Error = new TemplateException(ex.Message, ex.InnerException);
                templateAPIResponse.Message = UserResource.AddFailed;
                templateAPIResponse.Status = HttpStatusCode.InternalServerError;

                throw;
            }


            return templateAPIResponse;
        }

        public async Task<TemplateAPIResponse<IEnumerable<UserDTO>>> GetUsers()
        {
            TemplateAPIResponse<IEnumerable<UserDTO>> templateAPIResponse = new TemplateAPIResponse<IEnumerable<UserDTO>>();

            try
            {
                var users = await _userRepository.GetUsers();

                if (users != null)
                {
                    templateAPIResponse.Success = true;
                    templateAPIResponse.Data = _mapper.Map<IEnumerable<UserDTO>>(users);
                    templateAPIResponse.Message = UserResource.FetchSuccess;
                    templateAPIResponse.Status = HttpStatusCode.OK;
                }
                else
                {
                    templateAPIResponse.Success = false;
                    templateAPIResponse.Message = UserResource.FetchFailed;
                    templateAPIResponse.Status = HttpStatusCode.InternalServerError;
                }
            }
            catch (Exception ex)
            {
                templateAPIResponse.Success = false;
                templateAPIResponse.Error = new TemplateException(ex.Message, ex.InnerException);
                templateAPIResponse.Message = UserResource.FetchFailed;
                templateAPIResponse.Status = HttpStatusCode.InternalServerError;

                throw;
            }


            return templateAPIResponse;
        }

        public async Task<TemplateAPIResponse<IEnumerable<UserDTO>>> GetByUsername(string username)
        {
            TemplateAPIResponse<IEnumerable<UserDTO>> templateAPIResponse = new TemplateAPIResponse<IEnumerable<UserDTO>>();

            try
            {
                var result = await _userRepository.GetByUsername(username);

                if (result != null)
                {
                    templateAPIResponse.Success = true;
                    templateAPIResponse.Data = _mapper.Map<IEnumerable<UserDTO>>(result);
                    templateAPIResponse.Message = UserResource.FetchSuccess;
                    templateAPIResponse.Status = HttpStatusCode.OK;
                }
                else
                {
                    templateAPIResponse.Success = false;
                    templateAPIResponse.Message = UserResource.FetchFailed;
                    templateAPIResponse.Status = HttpStatusCode.InternalServerError;
                }
            }
            catch (Exception ex)
            {
                templateAPIResponse.Success = false;
                templateAPIResponse.Error = new TemplateException(ex.Message, ex.InnerException);
                templateAPIResponse.Message = UserResource.FetchFailed;
                templateAPIResponse.Status = HttpStatusCode.InternalServerError;

                throw;
            }

            return templateAPIResponse;
        }
    }

}