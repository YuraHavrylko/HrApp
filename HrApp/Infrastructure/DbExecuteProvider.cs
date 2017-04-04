using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using HrApp.Contract;
using HrApp.Helpers.Extensions;

namespace HrApp.Infrastructure
{
    public abstract class DbExecuteProvider
    {
        private readonly IConnectionFactory _connectionFactory;

        public DbExecuteProvider(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected IEnumerable<TEntity> CustomExecuteReader<TEntity>(string procedureName, Dictionary<string, object> parameters = null)
            where TEntity : new()
        {
            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(command.CreateParameter(parameter.Key, parameter.Value));
                    }
                }

                using (var reader = command.ExecuteReader())
                {
                    List<TEntity> items = new List<TEntity>();
                    while (reader.Read())
                    {
                        items.Add(Map<TEntity>(reader));
                    }

                    reader.Close();
                    return items;
                }
            }
        }

        protected int CustomExecuteNonQuery(string procedureName, Dictionary<string, object> parameters = null)
        {
            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(command.CreateParameter(parameter.Key, parameter.Value));
                    }
                }

                return command.ExecuteNonQuery();
            }
        }

        protected object CustomExecuteScalar(string procedureName, Dictionary<string, object> parameters = null)
        {
            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(command.CreateParameter(parameter.Key, parameter.Value));
                    }
                }

                return command.ExecuteScalar();
            }
        }

        protected TEntity Map<TEntity>(IDataRecord record) where TEntity : new()
        {
            TEntity objT = Activator.CreateInstance<TEntity>();

            foreach (var property in typeof(TEntity).GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                {
                    if (typeof(TEntity).IsValueType)
                    {
                        object boxed = objT;
                        property.SetValue(boxed, record[property.Name]);
                        objT = (TEntity)boxed;
                    }
                    else
                    {
                        property.SetValue(objT, record[property.Name]);
                    }
                }
            }
            return objT;
        }
    }
}