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
            ICommand cmd = App.Program.GetCommand();
            dataGridView1.DataSource = cmd.EquipamentosLivres(inicio, fim);
        }
    }
}
