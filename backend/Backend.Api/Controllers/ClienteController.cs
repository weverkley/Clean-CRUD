using MediatR;
using Backend.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Queries;
using Backend.Application.Commands.Customer;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IMediator mediator, ILogger<ClienteController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var query = new GetAllCustomersQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<CustomerDTO> GetById(Guid id)
        {
            var query = new GetCustomerByIdQuery(id);
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<CustomerDTO> Create([FromBody] CustomerDTO entity)
        {
            var command = new CreateCustomerCommand()
            {
                NomeRazao = entity.NomeRazao,
                CPFCNPJ = entity.CPFCNPJ,
                Email = entity.Email,
                Telefone = entity.Telefone,
                DataNascimento = entity.DataNascimento,
                IsActive = entity.IsActive
            };

            return await _mediator.Send(command);
        }
    }
}
