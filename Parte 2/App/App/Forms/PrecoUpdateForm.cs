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
    public partial class PrecoUpdateForm : Form
    {
        public PrecoUpdateForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.EntityFramework)
            {
                AEnimaEntities ctx = new AEnimaEntities();
                ctx.ActualizarPreco(textBoxTipo.Text,
                    double.Parse(textBoxValor.Text),
                    TimeSpan.Parse(textBoxDuracao.Text),
                    DateTime.Parse(textBoxDuracao.Text),
                    double.Parse(textBoxNovoValor.Text),
                    TimeSpan.Parse(textBoxNovaDuracao.Text),
                    DateTime.Parse(textBoxNovaValidade.Text));
                MessageBox.Show("Preço actualizado.");
            }
            else { 
                AdoCommand command = new AdoCommand();
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
}
