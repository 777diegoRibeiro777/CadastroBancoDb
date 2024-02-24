using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastroBancoDb.Models
{
    public partial class Funcionario
    {
        [Key]
        public int Idfuncionario { get; set; }
        public string? Nome { get; set; }
        public string? Cargo { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Email { get; set; }
    }
}
