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
    public partial class PrecoUpdateForm : Form
    {
        public PrecoUpdateForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Command command = new Command();
            MessageBox.Show(command.executeProcedure(
                (cmd) =>
                {
                    command.priceUpdate(cmd, textBoxTipo.Text, textBoxValor.Text, textBoxDuracao.Text, textBoxValidade.Text,
                        textBoxNovoValor.Text, textBoxNovaDuracao.Text, textBoxNovaValidade.Text);
                },
                "Price updated.",
                "Price update failed."));
        }
    }
}
