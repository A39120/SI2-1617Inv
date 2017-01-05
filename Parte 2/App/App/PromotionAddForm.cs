using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace App
{
    public partial class PromotionAddForm : Form
    {
        public PromotionAddForm()
        {
            InitializeComponent();
        }

        private void buttonAddTempo_Click(object sender, EventArgs e)
        {
            Action<SqlCommand> action = (cmd) =>
            {
                SqlParameter tempoExtra = new SqlParameter("@tempoExtra", SqlDbType.Time);
                tempoExtra.Value = textBoxTempoExtra.Text;
                cmd.Parameters.Add(tempoExtra);

                cmd.CommandText = "InserirPromocaoTemporal";
            };
            addPromotionToDatabase(action);
            this.Close();
        }

        private void buttonAddDesconto_Click(object sender, EventArgs e)
        {
            Action<SqlCommand> action = (cmd) =>
            {
                SqlParameter desconto = new SqlParameter("@desconto", SqlDbType.Float);
                desconto.Value = textBoxDesconto.Text;
                cmd.Parameters.Add(desconto);

                cmd.CommandText = "InserirPromocaoDesconto";
            };
            addPromotionToDatabase(action);
            this.Close();
        }

        private int addPromotionToDatabase(Action<SqlCommand> action)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter inicio = new SqlParameter("@inicio", SqlDbType.DateTime);
                    SqlParameter fim = new SqlParameter("@fim", SqlDbType.DateTime);
                    SqlParameter desc = new SqlParameter("@descricao", SqlDbType.VarChar, 255);
                    SqlParameter tipo = new SqlParameter("@tipo", SqlDbType.VarChar, 31);

                    tipo.Value = textBoxTipo.Text;
                    desc.Value = textBoxDescricao.Text;
                    fim.Value = textBoxFim.Text;
                    inicio.Value = textBoxInicio.Text;

                    //exec InserirPromocaoTemporal '2020-10-20 13:00:00', '2030-10-20 13:00:00', '1', 'Generic', '13:00:00'-- pId = 5
                    //exec InserirPromocaoDesconto '2020-10-20 13:00:00', '2030-10-20 13:00:00', '1', 'Generic', 0.5-- pId = 6
                    //exec InserirPromocaoTemporal @inicio, @fim, @descricao, @tipo, @tempoExtra
                    //exec InserirPromocaoDesconto @inicio, @fim, @descricao, @tipo, @desconto

                    cmd.Parameters.Add(tipo);
                    cmd.Parameters.Add(fim);
                    cmd.Parameters.Add(inicio);
                    cmd.Parameters.Add(desc);

                    /* The action will depend on which button was clicked, this action will add a parameter to command, 
                     * and will define what command will be run.
                     */
                    action(cmd);

                    // execute the command
                    con.Open();
                    try { 
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Added successfully.");
                    }
                    catch
                    {
                        MessageBox.Show("Can't add with invalid parameters.");
                    }

                    return 1;
                }
            }
        }
    }
}
