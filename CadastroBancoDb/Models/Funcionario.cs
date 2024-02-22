using System;
using System.Collections.Generic;

namespace CadastroBancoDb.Models
{
    public partial class Funcionario
    {
        public int Idfuncionario { get; set; }
        public string? Nome { get; set; }
        public string? Cargo { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Email { get; set; }
    }
}
