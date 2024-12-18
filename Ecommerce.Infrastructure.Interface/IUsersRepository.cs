using Ecommerce.Domain.Entity;

namespace Ecommerce.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);
    }
}
