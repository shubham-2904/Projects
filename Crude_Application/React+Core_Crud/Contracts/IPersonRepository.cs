using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts {
    public interface IPersonRepository {
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        IEnumerable<Person> GetAllPersons(bool trackChanges);
        Person GetPersonById(long personId, bool trackChanges);
    }
}
