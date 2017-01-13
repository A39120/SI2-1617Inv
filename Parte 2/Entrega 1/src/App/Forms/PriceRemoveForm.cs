using App.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class PriceRemoveForm : Form
    {
        public PriceRemoveForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ICommand cmd = Program.GetCommand())
            {
                //TODO: Use result, try & catch
                cmd.RemoverPreco(textBoxTipo.Text,
                    textBoxValor.Text,
                    textBoxDuracao.Text,
                    textBoxDuracao.Text);
            }
        }
    }
}
