using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastroBancoDb.Models
{
    public partial class Agencium
    {
        [Key]
        public int Idagencia { get; set; }
        public string? Endereco { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? GerenteResponsavel { get; set; }
    }
}
