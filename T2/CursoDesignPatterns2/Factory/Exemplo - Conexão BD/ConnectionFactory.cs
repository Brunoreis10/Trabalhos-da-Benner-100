using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Factory.Exemplo___Conexão_BD
{
    public class ConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            var conexao = new SqlConnection();
            conexao.ConnectionString = "User Id=root;Password=;Server=localhost;Database=meuBanco";
            conexao.Open();
            return conexao;
        }
    }
}
