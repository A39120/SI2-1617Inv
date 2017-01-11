using App.EF;
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

namespace App.Forms
{
    public partial class EquipamentosLivresTabelaForm : Form
    {
        public EquipamentosLivresTabelaForm(String inicio, String fim)
        {
            InitializeComponent();
            #region EF
            if (Program.EntityFramework) 
            {
                using (EfCommand cmd = new EfCommand())
                {
                    var equip = cmd.EquipamentosLivres(inicio, fim);
                    dataGridView1.DataSource = equip;
                }
            }
            #endregion
            #region ADO
            else
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        AdoCommand command = new AdoCommand();
                        command.getUnusedEquipmentsFor(cmd, inicio, fim);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dataGridView1.DataSource = dt;
                        }
                        reader.Close();
                    }
                }
            #endregion
            }
        }
    }
}
