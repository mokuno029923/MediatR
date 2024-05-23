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
                cfg.For<IRequestExceptionHandler<CustomerCreationRequest, Customer, Exception>>().Use<CustomerCreationExceptionHandler>();
                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestExceptionProcessorBehavior<,>));
                cfg.For<IMediator>().Use<Mediator>();
            });

            _mediator = container.GetInstance<IMediator>();
        }

        [Fact]
        public async Task Handle_CustomerIsNull_CustomerIdIsDefaultGuid()
        {
            // Arrange
            var request = new CustomerCreationRequest();

            // Act
            var response = await _mediator.Send(request);

            // Assert
            response.Id.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task Handle_CustomerNameIsEmpty_CustomerIdIsDefaultGuid()
        {
            // Arrange
            var customer = new Customer();
            var request = new CustomerCreationRequest()
            {
                Customer = customer,
            };

            // Act
            var response = await _mediator.Send(request);

            // Assert
            response.Id.ShouldBe(Guid.Empty);
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
