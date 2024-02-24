using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastroBancoDb.Models
{
    public partial class Emprestimo
    {
        [Key]
        public int Idemprestimo { get; set; }
        public decimal? ValorEmprestimo { get; set; }
        public decimal? TaxaJuros { get; set; }
        public int? Prazo { get; set; }
        public int? ClienteBeneficiario { get; set; }
        public string? Status { get; set; }

        public virtual Cliente? ClienteBeneficiarioNavigation { get; set; }
    }
}
