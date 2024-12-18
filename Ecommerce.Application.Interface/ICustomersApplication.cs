using Ecommerce.Application.DTO;
using Ecommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interface
{
    public interface ICustomersApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(CustomersDto customerDto);

        Response<bool> Update(CustomersDto customerDto);

        Response<bool> Delete(string customerId);

        Response<CustomersDto> Get(string customerId);

        Response<IEnumerable<CustomersDto>> GetAll();

        #endregion

        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(CustomersDto customerDto);

        Task<Response<bool>> UpdateAsync(CustomersDto customerDto);

        Task<Response<bool>> DeleteAsync(string customerId);

        Task<Response<CustomersDto>> GetAsync(string customerId);

        Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();

        #endregion
    }
}
