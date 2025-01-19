using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository {
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository {
        public PersonRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext) { }

        public void CreatePerson(Person person) {
           Create(person);
        }

        public void DeletePerson(Person person) {
            Delete(person);
        }

        public IEnumerable<Person> GetAllPersons(bool trackChanges) {
            return FindAll(trackChanges);
        }

        public Person GetPersonById(long personId, bool trackChanges) {
            return FindByCondition(p => p.Id.Equals(personId), trackChanges)
                   .SingleOrDefault();
        }

        public void UpdatePerson(Person person) {
            Update(person);
        }
    }
}
