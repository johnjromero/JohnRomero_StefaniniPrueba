using Backend.Core.Entities;
using Backend.Core.Interfaces;

namespace Backend.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _unitOfWork.CustomerRepo.GetCustomerById(id);
            return customer;
        }
    }
}
