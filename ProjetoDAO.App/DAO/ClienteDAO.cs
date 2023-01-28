using ProjetoDAO.App.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDAO.App.DAO
{
    public class ClienteDAO
    {
        private Contexto contexto;

        private void Incluir(Model.Cliente cliente)
        {
            try
            {
                var query = String.Format("insert into clientes (Nome, Email, DataNascimento) values ('{0}', '{1}','{2}')",
               cliente.Nome, cliente.Email, cliente.DataNascimento);

                using (contexto = new Contexto())
                {
                    contexto.ExecutaComando(query);
                }
            }
            catch
            {
                throw;
            }
        }

        private void Alterar(Model.Cliente cliente)
        {
            try
            {
                var query = String.Format("update clientes set nome = '{0}' where Id={1}", cliente.Nome, cliente.Id);

                using (contexto = new Contexto())
                {
                    contexto.ExecutaComando(query);
                }
            }
            catch
            {
                throw;
            }
           
        }

        public void Salvar(Model.Cliente cliente)
        {
            if (cliente.Id > 0)
            {
                Alterar(cliente);
            }
            else
            {
                Incluir(cliente);
            }
        }

        public IList<Model.Cliente> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var query = String.Format("select * from clientes");
                var retorno = contexto.ExecutaOperacao(query);
                return AtribuirValores(retorno);
            }
        }

        private List<Model.Cliente> AtribuirValores(SqlDataReader sqlDataReader)
        {
            var clientes = new List<Model.Cliente>();
            while (sqlDataReader.Read())
            {
                var data = string.IsNullOrEmpty(sqlDataReader["DataNascimento"].ToString()) ? "2021/01/01" : sqlDataReader["DataNascimento"].ToString();

                var aluno = new Model.Cliente()
                {
                    Id = int.Parse(sqlDataReader["Id"].ToString()),
                    Nome = sqlDataReader["Nome"].ToString(),
                    Email = sqlDataReader["Email"].ToString(),
                    DataNascimento = DateTime.Parse(data)
                };
                clientes.Add(aluno);
            }

            sqlDataReader.Close();
            return clientes;
        }
    }
}
