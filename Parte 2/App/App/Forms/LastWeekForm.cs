using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using App.EF;

namespace App.Forms
{
    public partial class LastWeekForm : Form
    {
        public LastWeekForm()
        {
            InitializeComponent();
            if (Program.EntityFramework)
            {
                using (EfCommand cmd = new EfCommand())
                {
                    dataGridView1.DataSource = cmd.EquipamentosSemAlugueresNaUltimaSemana();
                }
            }
            else
            {

                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        AdoCommand command = new AdoCommand();
                        //command.GetLastWeekUnusedEquipments(cmd);
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
            }
        }
    }
}