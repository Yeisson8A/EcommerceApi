using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Ecommerce.Infrastructure.Interface;

namespace Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Users Authenticate(string username, string password)
        {
            return _usersRepository.Authenticate(username, password);
        }
    }
}
