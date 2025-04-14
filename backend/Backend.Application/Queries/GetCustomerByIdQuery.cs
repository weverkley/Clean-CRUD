using MediatR;
using Backend.Application.DTO;

namespace Backend.Application.Queries
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<CustomerDTO>;
}
