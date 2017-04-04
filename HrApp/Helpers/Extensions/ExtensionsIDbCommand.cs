using System.Data;

namespace HrApp.Helpers.Extensions
{
    public static class ExtensionsIDbCommand
    {
        public static IDbDataParameter CreateParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;

            return parameter;
        }
    }
}