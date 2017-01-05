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
    public partial class PromotionRemoveForm : Form
    {
        public PromotionRemoveForm()
        {
            InitializeComponent();
        }

        private void buttonRemoveDesconto_Click(object sender, EventArgs e)
        {
            Remove("RemoverPromocaoDesconto");
        }

        private void buttonRemoveTemporal_Click(object sender, EventArgs e)
        {
            Remove("RemoverPromocaoTemporal");
        }

        private void Remove(String procedure)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter("@pid", SqlDbType.Int);
                    cmd.Parameters.Add(id);
                    cmd.CommandText = procedure;
                    id.Value = textBoxId.Text;

                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Added successfully.");
                    }
                    catch
                    {
                        MessageBox.Show("Can't add with invalid parameters.");
                    }
                    this.Close();
                }
            }
        }
    }
}
