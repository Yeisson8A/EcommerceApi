﻿using AutoMapper;
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

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
        }

        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Los parámetros no pueden ser vacíos";
                return response;
            }

            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "La autenticación ha sido exitosa";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "El usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}