using Backend.Core.Entities;

namespace Backend.Core.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
    }
}
