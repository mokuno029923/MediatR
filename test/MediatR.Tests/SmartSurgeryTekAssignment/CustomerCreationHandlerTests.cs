using System;
using System.Threading.Tasks;
using Lamar;
using MediatR.Pipeline;
using MediatR.Tests.SmartSurgeryTekAssignment.Domains;
using MediatR.Tests.SmartSurgeryTekAssignment.Requests;
using Shouldly;
using Xunit;

namespace MediatR.Tests.SmartSurgeryTekAssignment
{
    public class CustomerCreationHandlerTests
    {
        private readonly IMediator _mediator;

        public CustomerCreationHandlerTests()
        {
            var customerRepository = new CustomerRepository();
            var customerDomainService = new CustomerDomainService(customerRepository);
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.Assembly(typeof(CustomerCreationRequest).Assembly);
                    scanner.IncludeNamespaceContainingType<CustomerCreationRequest>();
                    scanner.AddAllTypesOf(typeof(IRequestHandler<,>));
                    scanner.WithDefaultConventions();
                });
                cfg.ForSingletonOf<ICustomerDomainService>().Use(customerDomainService);
                cfg.For<IMediator>().Use<Mediator>();
            });

            _mediator = container.GetInstance<IMediator>();
        }

        [Fact]
        public async Task Handle_CustomerIsNull_ThrowException()
        {
            // Arrange
            var request = new CustomerCreationRequest();

            // Act & Assert
            await Should.ThrowAsync<ArgumentNullException>(async () => await _mediator.Send(request));
        }

        [Fact]
        public async Task Handle_CustomerNameIsEmpty_ThrowException()
        {
            // Arrange
            var customer = new Customer();
            var request = new CustomerCreationRequest()
            {
                Customer = customer,
            };

            // Act & Assert
            await Should.ThrowAsync<ArgumentNullException>(async () => await _mediator.Send(request));
        }

        [Fact]
        public async Task Handle_Perfect_Succeed()
        {
            // Arrange
            var customer = new Customer()
            {
                Name = "Customer Name",
            };
            var request = new CustomerCreationRequest()
            {
                Customer = customer,
            };

            // Act
            var response = await _mediator.Send(request);

            // Assert
            response.Id.ShouldNotBe(Guid.Empty);
            response.Name.ShouldBe(customer.Name);
        }
    }
}
