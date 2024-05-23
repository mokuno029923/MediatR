using System.Threading.Tasks;

namespace MediatR.Tests.SmartSurgeryTekAssignment.Domains
{
    public interface ICustomerDomainService
    {
        public Task<Customer> CreateAsync(Customer? customer);
    }
}
