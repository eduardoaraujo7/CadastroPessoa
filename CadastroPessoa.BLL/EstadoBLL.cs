using CadastroPessoa.DAL;
using CadastroPessoa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.BLL
{
    public class EstadoBLL
    {
        private CadastroPessoaRepository cadastroPessoaRepository;

        public bool InserirEstado(Estado estado)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();

            if (estado != null)
            {
                cadastroPessoaRepository.InserirEstado(estado);
                return true;
            }
            return false;
        }

        public IEnumerable<Estado> ListarEstado()
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.ListarEstado();
        }

        public Estado ObterEstado(int id)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.ObterEstadoId(id);
        }

        public bool AlterarEstado(Estado estado)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.AlterarEstado(estado);
        }

        public bool ExcluirEstado(int id)
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
            return cadastroPessoaRepository.ExcluirEsatado(id);
        }

    }
}
