﻿using AutoMapper;
using Ecommerce.Application.DTO;
using Ecommerce.Application.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.Main
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;

        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper, IAppLogger<CustomersApplication> logger)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = _customersDomain.Insert(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "El registro ha sido exitoso";
                    _logger.LogInformation("El registro ha sido exitoso");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public Response<bool> Update(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = _customersDomain.Update(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "La actualización ha sido exitosa";
                    _logger.LogInformation("La actualización ha sido exitosa");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();

            try
            {
                response.Data = _customersDomain.Delete(customerId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "La eliminación ha sido exitosa";
                    _logger.LogInformation("La eliminación ha sido exitosa");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public Response<CustomersDto> Get(string customerId)
        {
            var response = new Response<CustomersDto>();

            try
            {
                var customer = _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDto>(customer);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "La consulta ha sido exitosa";
                    _logger.LogInformation("La consulta ha sido exitosa");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public Response<IEnumerable<CustomersDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDto>>();

            try
            {
                var customers = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "La consulta ha sido exitosa";
                    _logger.LogInformation("La consulta ha sido exitosa");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<Response<bool>> InsertAsync(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customersDomain.InsertAsync(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "El registro ha sido exitoso";
                    _logger.LogInformation("El registro ha sido exitoso");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customersDomain.UpdateAsync(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "La actualización ha sido exitosa";
                    _logger.LogInformation("La actualización ha sido exitosa");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();

            try
            {
                response.Data = await _customersDomain.DeleteAsync(customerId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "La eliminación ha sido exitosa";
                    _logger.LogInformation("La eliminación ha sido exitosa");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<CustomersDto>> GetAsync(string customerId)
        {
            var response = new Response<CustomersDto>();

            try
            {
                var customer = await _customersDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDto>(customer);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "La consulta ha sido exitosa";
                    _logger.LogInformation("La consulta ha sido exitosa");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomersDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDto>>();

            try
            {
                var customers = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "La consulta ha sido exitosa";
                    _logger.LogInformation("La consulta ha sido exitosa");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        #endregion
    }
}
