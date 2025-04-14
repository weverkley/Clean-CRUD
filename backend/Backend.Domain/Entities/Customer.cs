namespace Backend.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string NomeRazao { get; set; } = string.Empty;
        public string CPFCNPJ { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}