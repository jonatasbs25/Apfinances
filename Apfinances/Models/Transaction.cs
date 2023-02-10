using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apfinances.Models
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Empresa")]
        public string Company { get; set; } = string.Empty;

        [Display(Name = "Valor Total")]
        public decimal Amount { get; set; }

        [Display(Name = "Número de Parcelas")]
        public int Installments { get; set; }

        [Display(Name = "Valor das Parcelas")]
        public decimal ValueOfInstallments { get; set; }

        [Display(Name = "Data Inicial")]
        [DataType(DataType.Date)]
        public DateTime StarDate { get; set; }

        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
