using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class PromotionUpdateForm : Form
    {
        public PromotionUpdateForm()
        {
            InitializeComponent();
        }

        private void buttonUpdateTempo_Click(object sender, EventArgs e)
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

        private void buttonUpdateDesconto_Click(object sender, EventArgs e)
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
                    SqlParameter id = new SqlParameter("@promotion_id", SqlDbType.VarChar, 31);

                    id.Value = textBoxId.Text;
                    desc.Value = textBoxDescricao.Text;
                    fim.Value = textBoxFim.Text;
                    inicio.Value = textBoxInicio.Text;

                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(fim);
                    cmd.Parameters.Add(inicio);
                    cmd.Parameters.Add(desc);

                    /* The action will depend on which button was clicked, this action will add a parameter to command, 
                     * and will define what command will be run.
                     */
                    action(cmd);

                    // execute the command
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated successfully.");
                    }
                    catch
                    {
                        MessageBox.Show("Can't update with invalid parameters.");
                    }

                    return 1;
                }
            }
        }
    }
}
