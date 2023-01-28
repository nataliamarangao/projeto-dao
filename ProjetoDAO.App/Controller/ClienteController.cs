using ProjetoDAO.App.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDAO.App.Controller
{
    public class ClienteController
    {
        ClienteDAO clienteDAO;

        public ClienteController()
        {
            clienteDAO = new ClienteDAO();
        }

        public void SalvarClienteController(Model.Cliente cliente)
        {
            clienteDAO.Salvar(cliente);
        }

        public IList<Model.Cliente> ListarTodos()
        {
            return clienteDAO.ListarTodos();
        }
    }
}
