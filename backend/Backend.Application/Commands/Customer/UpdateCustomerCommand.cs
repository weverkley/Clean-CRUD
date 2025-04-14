using MediatR;
using Backend.Application.DTO;

namespace Backend.Application.Commands.Customer
{
    public class UpdateCustomerCommand : IRequest<CustomerDTO>
    {
        public Guid Id { get; set; }
        public string NomeRazao { get; set; }
        public string CPFCNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsActive { get; set; }

        public UpdateCustomerCommand() { }
        public UpdateCustomerCommand(Guid id, string nomeRazao, string cpfCnpj, string email, string telefone, DateTime dataNascimento, bool isActive)
        {
            Id = id;
            NomeRazao = nomeRazao;
            CPFCNPJ = cpfCnpj;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            IsActive = isActive;
        }
    }
}
