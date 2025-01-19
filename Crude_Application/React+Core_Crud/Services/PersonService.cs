using AutoMapper;
using Contract.Services;
using Contracts;
using Entities;
using Entities.Exceptions;
using Shared.DTOs;

namespace Services {
    public class PersonService : IPersonService {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public PersonService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper) {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public DTOPerson CreatePerson(DTOPerson person) {
            Person personEntity = _mapper.Map<Person>(person);

            _repositoryManager.PersonRepository.CreatePerson(personEntity);
            _repositoryManager.Save();

            DTOPerson dtoPerson = _mapper.Map<DTOPerson>(personEntity);
            return dtoPerson;
        }

        public (bool, long) DeletePerson(long personId) {
            Person personEntity = _repositoryManager.PersonRepository.GetPersonById(personId, false);

            if (personEntity is null) {
               throw new PersonNotFoundException($"Person not found with {personId}");
            }

            _repositoryManager.PersonRepository.DeletePerson(personEntity);
            _repositoryManager.Save();

            return (true, personId);
        }

        public IEnumerable<DTOPerson> GetAllPersons(bool trackChanges) {
            IEnumerable<Person> personEntities = _repositoryManager.PersonRepository.GetAllPersons(trackChanges);

            IEnumerable<DTOPerson> dtoPersons = _mapper.Map<IEnumerable<DTOPerson>>(personEntities);
            return dtoPersons;
        }

        public DTOPerson GetPersonById(long personId, bool trackChanges) {
            Person personEntity = _repositoryManager.PersonRepository.GetPersonById(personId, trackChanges);

            if (personEntity is null) {
               throw new PersonNotFoundException($"Person not found with {personId}");
            }

            DTOPerson dtoPerson = _mapper.Map<DTOPerson>(personEntity);
            return dtoPerson;
        }

        public bool UpdatePerson(long personId, DTOPerson person) {
            Person personEntity = _repositoryManager.PersonRepository.GetPersonById(personId, trackChanges: true);

            if (person is null) {
                throw new PersonNotFoundException($"Person not found with {personId}");
            }

            _mapper.Map(person, personEntity);
            personEntity.Id = personId;
            _repositoryManager.Save();

            return true;
        }
    }
}
