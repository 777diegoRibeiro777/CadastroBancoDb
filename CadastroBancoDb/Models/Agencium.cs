using System;
using System.Collections.Generic;

namespace CadastroBancoDb.Models
{
    public partial class Agencium
    {
        public int NumeroAgencia { get; set; }
        public string? Endereco { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? GerenteResponsavel { get; set; }
    }
}
