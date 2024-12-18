using Ecommerce.Application.DTO;
using Ecommerce.Transversal.Common;

namespace Ecommerce.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);
    }
}
