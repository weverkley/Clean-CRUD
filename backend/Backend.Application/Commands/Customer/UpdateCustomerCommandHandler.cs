using MediatR;
using Backend.Domain.Interfaces.Repositories;
using AutoMapper;
using Backend.Application.DTO;

namespace Backend.Application.Commands.Customer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.GetByIdAsync(request.Id);
            if (entity is null) throw new Exception("Cliente não encontrato");

            var newEntity = _mapper.Map<Backend.Domain.Entities.Customer>(request);

            await _customerRepository.UpdateAsync(newEntity);

            return _mapper.Map<CustomerDTO>(newEntity);
        }
    }
}
