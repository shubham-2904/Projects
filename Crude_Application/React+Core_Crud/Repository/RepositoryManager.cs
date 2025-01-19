using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository {
    public class RepositoryManager : IRepositoryManager {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IPersonRepository> _personRepository;
        
        public RepositoryManager(RepositoryContext repositoryContext) {
            _repositoryContext = repositoryContext;
            _personRepository = new Lazy<IPersonRepository>(() => new PersonRepository(_repositoryContext));
        }

        public IPersonRepository PersonRepository => _personRepository.Value;

        public void Save() {
            _repositoryContext.SaveChanges();
        }
    }
}
