using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastroBancoDb.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Conta = new HashSet<Contum>();
            Emprestimos = new HashSet<Emprestimo>();
        }

        [Key]
        public int Idconta { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Email { get; set; }
        public string? HistoricoTransacoes { get; set; }

        public virtual ICollection<Contum> Conta { get; set; }
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
