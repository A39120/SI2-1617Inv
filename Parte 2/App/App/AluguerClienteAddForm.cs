using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class AluguerClienteAddForm : Form
    {

        private List<SqlParameter> previous;
        public AluguerClienteAddForm(List<SqlParameter> previous)
        {
            InitializeComponent();
            this.previous = previous;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    SqlParameter clienteNif = new SqlParameter("@cliente_nif", SqlDbType.Int);
                    SqlParameter clienteNome = new SqlParameter("@cliente_nome", SqlDbType.VarChar, 31);
                    SqlParameter clienteMorada = new SqlParameter("@cliente_morada", SqlDbType.VarChar, 100);

                    previous.Add(clienteNif);
                    previous.Add(clienteNome);
                    previous.Add(clienteMorada);

                    previous.ForEach((param)=>cmd.Parameters.Add(param));

                    cmd.CommandText = "InserirAluguerComNovoCliente";
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Aluguer e Cliente adicionados.");

                    }
                    catch
                    {
                        MessageBox.Show("Não se conseguiu adicionar o Aluguer, nem Cliente.");
                    }
                    this.Close();
                }
            }
        }
    }
}
