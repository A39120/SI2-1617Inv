using System;
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
