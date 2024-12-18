using System.Data;

namespace Ecommerce.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection {  get; }
    }
}
