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
            using (ICommand cmd = Program.GetCommand())
            {
                dataGridView1.DataSource = cmd.EquipamentosSemAlugueresNaUltimaSemana();
            }
            
        }
    }
}