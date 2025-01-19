using Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Services {
    public interface IPersonService {
        DTOPerson CreatePerson(DTOPerson person);
        (bool, long) DeletePerson(long personId);
        bool UpdatePerson(long personId, DTOPerson person);
        IEnumerable<DTOPerson> GetAllPersons(bool trackChanges);
        DTOPerson GetPersonById(long personId, bool trackChanges);
    }
}
