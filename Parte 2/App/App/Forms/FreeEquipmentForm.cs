using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class FreeEquipmentForm : Form
    {
        public FreeEquipmentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EquipamentosLivresTabelaForm eltf = new EquipamentosLivresTabelaForm(textBox1.Text, textBox2.Text);
            eltf.Show();
        }
    }
}
