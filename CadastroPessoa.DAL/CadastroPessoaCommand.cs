using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CadastroPessoa.DAL
{
    public class CadastroPessoaCommand : IDisposable
    {
        public SqlCommand CriarComando(string procedure, List<SqlParameter> parameters = null)
        {
            var command = new SqlCommand();

            if (parameters != null)
                command.Parameters.AddRange(parameters.ToArray());

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = procedure;
            command.Connection = Conexao.CriarConexao();
            command.Connection.Open();

            return command;
        }

        public void Dispose()
        {
            if(Conexao.CriarConexao().State == System.Data.ConnectionState.Open)
            {
                Conexao.CriarConexao().Close();
            }
        }
    }
}
