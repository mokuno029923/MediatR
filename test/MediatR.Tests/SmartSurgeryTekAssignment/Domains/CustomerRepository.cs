using System.Threading.Tasks;

namespace MediatR.Tests.SmartSurgeryTekAssignment.Domains
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<Customer> CreateAsync(Customer customer)
        {
            // Here is an example.
            // TODO: Create new customer to database.
            return Task.FromResult(customer);
        }
    }
}
