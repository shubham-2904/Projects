﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Services {
    public interface IServiceManager {
        IPersonService PersonService { get; }
    }
}
