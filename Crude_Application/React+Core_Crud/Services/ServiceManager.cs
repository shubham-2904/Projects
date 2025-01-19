using AutoMapper;
using Contract.Services;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services {
    public class ServiceManager : IServiceManager {
        private readonly Lazy<IPersonService> _personService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper) {
            _personService = new Lazy<IPersonService>(() => new PersonService(repositoryManager, loggerManager, mapper));
        }

        public IPersonService PersonService => _personService.Value;
    }
}
