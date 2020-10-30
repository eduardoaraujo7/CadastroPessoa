using CadastroPessoa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.DAL
{
    public class CadastroPessoaRepository
    {
        //CRUD PESSOAS....
        public bool InserirPessoa(Pessoa pessoa)
        {
            var procedure = "sp_incluir_pessoa";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@nome", Value = pessoa.Nome},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@email", Value = pessoa.Email},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@bairro", Value = pessoa.Bairro}
            };

            using(var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var retornoLinhas = command.ExecuteNonQuery();

                if (retornoLinhas > 0)
                    return true;

                return false;
            }
        }

        public List<Pessoa> ListarPessoa()
        {
            var pessoas = new List<Pessoa>();
            var procedure = "sp_listar_pessoa";

            using(var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pessoas.Add(new Pessoa
                    {
                        Nome = reader["nome"].ToString(),
                        Email = reader["email"].ToString(),
                        Bairro = reader["bairro"].ToString()
                    });
                }
                return pessoas;
            }
        }

        public Pessoa ObterPessoaId(int id)
        {
            var pessoa = new Pessoa();
            var procedure = "sp_obter_pessoa_id";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter(){DbType = System.Data.DbType.Int32, ParameterName = "@pessoaId", Value = id}
            };

            using(var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pessoa.PessoaId = Convert.ToInt32(reader["id"]);
                    pessoa.Nome = reader["nome"].ToString();
                    pessoa.Email = reader["email"].ToString();
                    pessoa.Bairro = reader["bairro"].ToString();
                }

                return pessoa;
            }
        }

        public bool AlterarPessoa(Pessoa pessoa)
        {
            var procedure = "sp_alterar_pessoa";
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {SqlDbType = SqlDbType.Int, ParameterName = "@pessoaId", Value = pessoa.PessoaId},
                new SqlParameter() {SqlDbType = SqlDbType.VarChar, ParameterName = "@nome", Value = pessoa.Nome},
                new SqlParameter() {SqlDbType = SqlDbType.VarChar, ParameterName = "@email", Value = pessoa.Email},
                new SqlParameter() {SqlDbType = SqlDbType.VarChar, ParameterName = "@bairro", Value = pessoa.Bairro}
            };

            using(var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var retornoLinhas = command.ExecuteNonQuery();

                if (retornoLinhas > 0)

                    return true;
            }
            return false;
        }

        public bool ExcluirPessoa(int id)
        {
            var procedure = "sp_excluir_pessoa";
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {SqlDbType = SqlDbType.Int, ParameterName = "@pessoaId", Value = id}
            };

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);

                var retornoLinhas = command.ExecuteNonQuery();

                if (retornoLinhas > 0)
                    return true;
            }

            return false;
        }


        // CRUD CIDADES...
        public bool InserirCidade(Cidade cidade)
        {
            var procedure = "sp_incluir_cidade";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@nome", Value = cidade.Nome},
            };

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var retornoLinhas = command.ExecuteNonQuery();

                if (retornoLinhas > 0)
                    return true;

                return false;
            }
        }

        public List<Cidade> ListarCidade()
        {
            var cidade = new List<Cidade>();
            var procedure = "sp_listar_cidade";

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cidade.Add(new Cidade
                    {
                        Nome = reader["nome"].ToString()
                    });
                }
                return cidade;
            }
        }

        public Cidade ObterCidadeId(int id)
        {
            var cidade = new Cidade();
            var procedure = "sp_obter_cidade_id";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter(){DbType = System.Data.DbType.Int32, ParameterName = "@cidadeId", Value = id}
            };

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cidade.cidadeId = Convert.ToInt32(reader["id"]);
                    cidade.Nome = reader["nome"].ToString();
                }

                return cidade;
            }
        }

        public bool AlterarCidade(Cidade cidade)
        {
            var procedure = "sp_alterar_cidade";
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {SqlDbType = SqlDbType.Int, ParameterName = "@cidadeId", Value = cidade.cidadeId},
                new SqlParameter() {SqlDbType = SqlDbType.VarChar, ParameterName = "@nome", Value = cidade.Nome}
            };

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var retornoLinhas = command.ExecuteNonQuery();

                if (retornoLinhas > 0)

                    return true;
            }
            return false;
        }

        public bool ExcluirCidade(int id)
        {
            var procedure = "sp_excluir_cidade";
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {SqlDbType = SqlDbType.Int, ParameterName = "@cidadeId", Value = id}
            };

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);

                var retornoLinhas = command.ExecuteNonQuery();

                if (retornoLinhas > 0)
                    return true;
            }

            return false;
        }


        //CRUD ESTADOS...
        public bool InserirEstado(Estado estado)
        {
            var procedure = "sp_incluir_estado";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@nome", Value = estado.Nome}
            };

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var retornoLinhas = command.ExecuteNonQuery();

                if (retornoLinhas > 0)
                    return true;

                return false;
            }
        }

        public List<Estado> ListarEstado()
        {
            var estado = new List<Estado>();
            var procedure = "sp_listar_estado";

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    estado.Add(new Estado
                    {
                        Nome = reader["nome"].ToString()
                    });
                }
                return estado;
            }
        }

        public Estado ObterEstadoId(int id)
        {
            var estado = new Estado();
            var procedure = "sp_obter_estado_id";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter(){DbType = System.Data.DbType.Int32, ParameterName = "@estadoId", Value = id}
            };

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    estado.estadoId = Convert.ToInt32(reader["id"]);
                    estado.Nome = reader["nome"].ToString();
                }

                return estado;
            }
        }

        public bool AlterarEstado(Estado estado)
        {
            var procedure = "sp_alterar_estado";
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {SqlDbType = SqlDbType.Int, ParameterName = "@estadoId", Value = estado.estadoId},
                new SqlParameter() {SqlDbType = SqlDbType.VarChar, ParameterName = "@nome", Value = estado.Nome}
            };

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var retornoLinhas = command.ExecuteNonQuery();

                if (retornoLinhas > 0)

                    return true;
            }
            return false;
        }

        public bool ExcluirEsatado(int id)
        {
            var procedure = "sp_excluir_estado";
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {SqlDbType = SqlDbType.Int, ParameterName = "@estadoId", Value = id}
            };

            using (var dbHelper = new CadastroPessoaCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);

                var retornoLinhas = command.ExecuteNonQuery();

                if (retornoLinhas > 0)
                    return true;
            }

            return false;
        }
    }
}
