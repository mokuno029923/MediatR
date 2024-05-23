using MediatR.Tests.SmartSurgeryTekAssignment.Domains;

namespace MediatR.Tests.SmartSurgeryTekAssignment.Requests
{
    public class CustomerCreationRequest : IRequest<Customer>
    {
        public Customer? Customer { get; set; }
    }
}
