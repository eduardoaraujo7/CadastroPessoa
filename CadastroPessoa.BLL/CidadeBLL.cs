using CadastroPessoa.DAL;
using CadastroPessoa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.BLL
{
    public class CidadeBLL
    {
        private CadastroPessoaRepository cadastroPessoaRepository;

        public bool InserirCidade(Cidade cidade)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();

            if (cidade != null)
            {
                cadastroPessoaRepository.InserirCidade(cidade);
                return true;
            }
            return false;
        }

        public IEnumerable<Cidade> ListarCidade()
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.ListarCidade();
        }

        public Cidade ObterCidade(int id)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.ObterCidadeId(id);
        }

        public bool AlterarCidade(Cidade cidade)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.AlterarCidade(cidade);
        }

        public bool ExcluirCidade(int id)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.ExcluirCidade(id);
        }

    }
}
