using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;

namespace ProjetoDAO.App.Repositorio
{
    public class Contexto : IDisposable
    {
        private readonly SqlConnection connection;

        public Contexto()
        {
            //Abrir a conexão sempre que instanciar
            //conexão está no App.config
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoProjetoDAO"].ConnectionString);
            connection.Open();
        }

        /// <summary>
        /// Método que executa um comando, insert, update ou delete
        /// </summary>
        /// <param name="strQuery">Query a ser executada</param>
        public void ExecutaComando(string strQuery)
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = connection
            };

            sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Método que executa um select
        /// </summary>
        /// <param name="strQuery">Query a ser executada</param>
        /// <returns>Retorna os dados do select</returns>
        public SqlDataReader ExecutaOperacao(string strQuery)
        {
            var sqlCommand = new SqlCommand(strQuery, connection);
            return sqlCommand.ExecuteReader();
        }

        public void Dispose()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}
