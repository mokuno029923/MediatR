using System.Threading;
using System.Threading.Tasks;
using MediatR.Tests.SmartSurgeryTekAssignment.Domains;

namespace MediatR.Tests.SmartSurgeryTekAssignment.Requests
{
    public class CustomerCreationRequestHandler : IRequestHandler<CustomerCreationRequest, Customer>
    {
        private readonly ICustomerDomainService _customerDomainService;

        public CustomerCreationRequestHandler(ICustomerDomainService customerDomainService)
        {
            _customerDomainService = customerDomainService;
        }

        public Task<Customer> Handle(CustomerCreationRequest request, CancellationToken cancellationToken)
        {
            return _customerDomainService.CreateAsync(request.Customer);
        }
    }
}
