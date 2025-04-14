using MediatR;
using AutoMapper;
using Backend.Domain.Interfaces.Repositories;
using Backend.Application.DTO;

namespace Backend.Application.Queries
{
    public class GetClienteByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _clienteRepository;

        public GetClienteByIdQueryHandler(IMapper mapper, ICustomerRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _clienteRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CustomerDTO>(data);
        }
    }
}
