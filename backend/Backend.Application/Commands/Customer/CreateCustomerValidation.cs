using Backend.Domain.Interfaces.Repositories;
using FluentValidation;

namespace Backend.Application.Commands.Customer
{
    public sealed class CreateCustomerValidation : AbstractValidator<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerValidation(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            RuleFor(p => p.NomeRazao)
                .NotEmpty().WithMessage("O Nome/Razão social não pode estar vazio")
                .MaximumLength(150).WithMessage("O Nome/Razão social deve conter no máximo 150 caracteres");
            RuleFor(p => p.CPFCNPJ)
                .MustAsync(IsCpfCnpjUnique)
                .WithMessage("O CPF/CNPJ já está em uso")
                .NotEmpty().WithMessage("O CPF/CNPJ não pode estar vazio")
                .MinimumLength(11).WithMessage("O CPF/CNPJ social deve conter no mínimo 11 caracteres")
                .MaximumLength(14).WithMessage("O CPF/CNPJ social deve conter no máximo 14 caracteres");

            When(p => p.CPFCNPJ.Length > 11, () =>
            {
                RuleFor(p => p.CPFCNPJ).IsValidCNPJ();
            }).Otherwise(() =>
            {
                RuleFor(p => p.CPFCNPJ).IsValidCPF();
            });
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O Email não pode estar vazio")
                .EmailAddress().WithMessage("O Email não é válido");
            RuleFor(p => p.Telefone)
                .NotEmpty().WithMessage("O Telefone não pode estar vazio");
            RuleFor(p => p.DataNascimento)
                .NotEmpty().WithMessage("A DataNascimento não pode estar vazia");
        }

        private async Task<bool> IsCpfCnpjUnique(string cpfCnpj, CancellationToken token)
        {
            return await _customerRepository.IsCpfCnpjUnique(cpfCnpj);
        }
    }
}
