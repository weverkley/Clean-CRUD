using MediatR;
using Backend.Application.DTO;

namespace Backend.Application.Queries
{
    public record GetAllCustomersQuery : IRequest<IList<CustomerDTO>>;
}
