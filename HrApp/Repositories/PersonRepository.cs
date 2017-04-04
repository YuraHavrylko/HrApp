using System.Collections.Generic;
using System.Linq;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Repositories
{
    public class PersonRepository : DbExecuteProvider, IRepository<Person>
    {
        public PersonRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public Person Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@PersonId", id } };

            return CustomExecuteReader<Person>("sp_GetPersonById", parameters).FirstOrDefault();
        }

        public IEnumerable<Person> GetAll()
        {
            return CustomExecuteReader<Person>("sp_GetPersons").ToList();
        }

        public IEnumerable<Person> GetAllWhere(Person person)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@FirstName", person.FirstName},
                {"@LastName", person.LastName},
                {"@City", person.City},
                {"@Salary", person.Salary}
            };

            return CustomExecuteReader<Person>("sp_GetPersonsWhere", parameters).ToList();
        }

        public void Add(Person person)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Person person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Person person)
        {
            throw new System.NotImplementedException();
        }
    }
}