using System.Data;

namespace HrApp.Contract
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}