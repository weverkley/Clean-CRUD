using MediatR;
using AutoMapper;
using Backend.Application.DTO;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.Queries
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IList<CustomerDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _clienteRepository;

        public GetAllCustomersQueryHandler(IMapper mapper, ICustomerRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<IList<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var data = await _clienteRepository.GetAllAsync();
            return _mapper.Map<IList<CustomerDTO>>(data);
        }
    }
}
