using ClassLibrary.Models;

namespace Big_Bang__Assessment_1.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> UpdateCustomer(int id, Customer customer);
        Task<bool> DeleteCustomer(int id);
        bool CustomerExists(int id);
    }
}
