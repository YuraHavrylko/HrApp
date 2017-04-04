using System.Data;

namespace HrApp.Helpers.Extensions
{
    public static class ExtensionIDbConnection
    {
        public static IDbCommand Procedure(this IDbConnection connection, string storedProcName)
        {
            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcName;

            return command;
        }
    }
}