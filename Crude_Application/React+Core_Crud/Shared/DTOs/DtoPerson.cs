﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs {
    public record DTOPerson(long id, string First_Name, string Last_Name, int age);
}
