using System;
using System.Collections.Generic;

namespace CadastroBancoDb.Models
{
    public partial class Contum
    {
        public Contum()
        {
            Transacaos = new HashSet<Transacao>();
        }

        public int NumeroConta { get; set; }
        public string? TipoConta { get; set; }
        public decimal? Saldo { get; set; }
        public int? ClienteTitular { get; set; }

        public virtual Cliente? ClienteTitularNavigation { get; set; }
        public virtual ICollection<Transacao> Transacaos { get; set; }
    }
}
