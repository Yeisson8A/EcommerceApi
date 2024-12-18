using Dapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Infrastructure.Interface;
using Ecommerce.Transversal.Common;
using System.Data;

namespace Ecommerce.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Users Authenticate(string username, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(query, parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
