using Ecommerce.Domain.Entity;

namespace Ecommerce.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
