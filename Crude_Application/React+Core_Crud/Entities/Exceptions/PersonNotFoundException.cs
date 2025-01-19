using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions {
    public class PersonNotFoundException : NotFoundException {
        public PersonNotFoundException(string message) : base(message) {

        }
    }
}
