using System;
using System.Collections.Generic;
using System.Text;
using Backend.Core.Entities;

namespace Backend.Core.Interfaces
{
    public interface ICustomerRepo
    {
        Customer GetCustomerById(int id);
    }
}
