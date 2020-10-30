using CadastroPessoa.DAL;
using CadastroPessoa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.BLL
{
    public class PessoaBLL
    {
        private CadastroPessoaRepository cadastroPessoaRepository;

        public bool InserirPessoa(Pessoa pessoa)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();

            if (pessoa != null)
            {
                cadastroPessoaRepository.InserirPessoa(pessoa);
                return true;
            }
            return false;
        }

        public IEnumerable<Pessoa> ListarPessoa()
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.ListarPessoa();
        }

        public Pessoa ObterPessoa(int id)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.ObterPessoaId(id);
        }

        public bool AlterarPessoa(Pessoa pessoa)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.AlterarPessoa(pessoa);
        }

        public bool ExcluirPessoa(int id)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.ExcluirPessoa(id);
        }

    }
}
