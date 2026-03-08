using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceServices.ServicesInterfaces;

public interface IServiceManager
{
    IUserService UserService { get; }
}
