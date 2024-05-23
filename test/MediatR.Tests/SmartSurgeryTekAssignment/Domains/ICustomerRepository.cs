using System.Threading.Tasks;

namespace MediatR.Tests.SmartSurgeryTekAssignment.Domains
{
    public interface ICustomerRepository
    {
        public Task<Customer> CreateAsync(Customer customer);
    }
}
