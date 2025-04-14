namespace Backend.Application.DTO
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string NomeRazao { get; set; }
        public string CPFCNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<AddressDTO> Enderecos { get; set; } = new List<AddressDTO>();
    }
}
