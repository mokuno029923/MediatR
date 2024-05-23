using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using MediatR.Tests.SmartSurgeryTekAssignment.Domains;

namespace MediatR.Tests.SmartSurgeryTekAssignment.Requests
{
    public class CustomerCreationExceptionHandler : IRequestExceptionHandler<CustomerCreationRequest, Customer, Exception>
    {
        public Task Handle(
            CustomerCreationRequest request,
            Exception exception,
            RequestExceptionHandlerState<Customer> state,
            CancellationToken cancellationToken)
        {
            // Here is an example.
            // TODO: Handle an exception here, e.g.: log errors.
            var message = exception switch
            {
                ArgumentNullException argumentNullException => "Customer properties are invalid.",
                _ => "",
            };

            // Here is an example.
            // TODO: Response real error status, so the rest process could keep going correctly.
            var errorCustomer = new Customer
            {
                Name = message,
            };
            state.SetHandled(errorCustomer);

            return Task.CompletedTask;
        }
    }
}
