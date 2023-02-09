using System.ComponentModel.DataAnnotations;

namespace Apfinances.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int Installments { get; set; }
        public decimal ValueOfInstallments { get; set; }
        [DataType(DataType.Date)]
        public DateTime StarDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
