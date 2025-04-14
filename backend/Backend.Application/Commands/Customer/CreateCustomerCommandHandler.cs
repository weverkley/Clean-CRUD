using MediatR;
using Backend.Domain.Interfaces.Repositories;
using AutoMapper;
using Backend.Application.DTO;

namespace Backend.Application.Commands.Customer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDTO> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Backend.Domain.Entities.Customer
            {
                NomeRazao = request.NomeRazao,
                CPFCNPJ = request.CPFCNPJ,
                Email = request.Email,
                Telefone = request.Telefone,
                DataNascimento = request.DataNascimento,
                IsActive = request.IsActive,
            };

            await _customerRepository.AddAsync(entity);

            return _mapper.Map<CustomerDTO>(entity);
        }
    }
}
