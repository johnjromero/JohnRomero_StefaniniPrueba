using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.Interfaces
{
    public interface IBankService
    {
        Bank GetBankById(int id);
    }
}
