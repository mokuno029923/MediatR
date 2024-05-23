using System;
using System.Threading.Tasks;

namespace MediatR.Tests.SmartSurgeryTekAssignment.Domains
{
    public class CustomerDomainService : ICustomerDomainService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDomainService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer> CreateAsync(Customer? customer)
        {
            Validate(customer);

            customer!.Id = Guid.NewGuid();

            return _customerRepository.CreateAsync(customer!);
        }

        /// <summary>
        /// Validate a customer properties.
        /// </summary>
        private void Validate(Customer? customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            if (string.IsNullOrEmpty(customer.Name))
            {
                throw new ArgumentNullException(nameof(customer.Name));
            }
        }
    }
}
