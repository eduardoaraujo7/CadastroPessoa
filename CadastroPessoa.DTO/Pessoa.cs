using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.DTO
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Bairro { get; set; }
        public List<Estado> Estados { get; set; }
        public List<Cidade> Cidades { get; set; }
        public Estado Estado { get; set; }
        public Cidade Cidade { get; set; }
    }
}
