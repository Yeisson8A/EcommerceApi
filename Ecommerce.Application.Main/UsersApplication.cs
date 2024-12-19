using AutoMapper;
using Ecommerce.Application.DTO;
using Ecommerce.Application.Interface;
using Ecommerce.Domain.Interface;
using Ecommerce.Transversal.Common;
using System;

namespace Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UsersApplication> _logger;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, IAppLogger<UsersApplication> logger)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Los parámetros no pueden ser vacíos";
                _logger.LogWarning("Los parámetros no pueden ser vacíos");
                return response;
            }

            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "La autenticación ha sido exitosa";
                _logger.LogInformation("La autenticación ha sido exitosa");
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "El usuario no existe";
                _logger.LogWarning("El usuario no existe");
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }
    }
}
