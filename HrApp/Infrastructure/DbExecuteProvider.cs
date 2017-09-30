using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using HrApp.Contract;
using HrApp.Helpers.Extensions;
using HrApp.Models;

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

        protected IEnumerable<Person> CustomExecuteReader(string procedureName, Dictionary<string, object> parameters = null)
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
                List<Person> persons = new List<Person>();
                using (var reader = command.ExecuteReader())
                {

                    

                    while (reader.Read())
                    {
                        persons.Add(Map<Person>(reader));
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        var educationPerson = Map<Education>(reader);;
                        persons
                            .FirstOrDefault(x => x.PersonId == educationPerson.PersonId)?.Educations.Add(educationPerson);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        var interviewPerson = Map<Interview>(reader);
                        persons.FirstOrDefault(x => x.PersonId == interviewPerson.PersonId)?.Interviews.Add(interviewPerson);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        var interviewPerson = Map<Language>(reader);
                        persons.FirstOrDefault(x => x.PersonId == interviewPerson.PersonId)?.Languages.Add(interviewPerson);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        var interviewPerson = Map<Job>(reader);
                        persons.FirstOrDefault(x => x.PersonId == interviewPerson.PersonId)?.Jobs.Add(interviewPerson);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        var interviewPerson = Map<TypeJob>(reader);
                        persons.FirstOrDefault(x => x.PersonId == interviewPerson.PersonId)?.PersonTypeJobs.Add(interviewPerson);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        var interviewPerson = Map<WorkExperience>(reader);
                        persons.FirstOrDefault(x => x.PersonId == interviewPerson.PersonId)?.WorkExperiences.Add(interviewPerson);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        var interviewPerson = Map<ProfessionalSkill>(reader);
                        persons.FirstOrDefault(x => x.PersonId == interviewPerson.PersonId)?.ProfessionalSkills.Add(interviewPerson);
                    }
                    reader.NextResult();

                    reader.Close();
                    return persons;
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

            foreach (var property in typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance))
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