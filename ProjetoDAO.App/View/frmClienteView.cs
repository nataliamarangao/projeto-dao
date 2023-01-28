using ProjetoDAO.App.Controller;
using ProjetoDAO.App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDAO.App.View
{
    public partial class frmClienteView : Form
    {

        public frmClienteView()
        {
            InitializeComponent();
            PreencherGrid(dataGridView1);
        }

        private void PreencherGrid(DataGridView dataGridView)
        {
            ClienteController clienteController = new ClienteController();
            
            try
            {
                dataGridView.DataSource = null;
                dataGridView.Rows.Clear();
                dataGridView.DataSource = clienteController.ListarTodos();
            }
            catch
            {
                throw;
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente() { 
                Nome = textBox1.Text,
                Email = textBox2.Text,
                DataNascimento = dateTimePicker1.Value.Date
            };

            ClienteController clienteController = new ClienteController();
            clienteController.SalvarClienteController(cliente);
            MessageBox.Show("Salvo com sucesso!");    
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Editar"))
                {

                }
                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Excluir"))
                {
                    var usuario = (Cliente)senderGrid.Rows[e.RowIndex].DataBoundItem;
                }
            }
        }
    }
}
