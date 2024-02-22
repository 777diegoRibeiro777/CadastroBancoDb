using System;
using System.Collections.Generic;

namespace CadastroBancoDb.Models
{
    public partial class Transacao
    {
        public int Idtransacao { get; set; }
        public DateTime? DataHoraTransacao { get; set; }
        public string? TipoTransacao { get; set; }
        public int? ContaEnvolvida { get; set; }
        public decimal? ValorTransacao { get; set; }

        public virtual Contum? ContaEnvolvidaNavigation { get; set; }
    }
}
