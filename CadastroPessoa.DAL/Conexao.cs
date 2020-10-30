using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.DAL
{
   public class Conexao
    {
        public static SqlConnection CriarConexao()
        {
            var connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=CadastroPessoa;Integrated Security=True";
            return connection;
        }
    }
}
