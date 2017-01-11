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
            #region EF
            if (Program.EntityFramework)
            {
                using (EfCommand cmd = new EfCommand())
                {
                    MessageBox.Show(cmd.RemoverPreco(textBoxTipo.Text,
                        textBoxValor.Text,
                        textBoxDuracao.Text,
                        textBoxDuracao.Text));
                }
            }
            #endregion
            #region ADO
            else 
            {
                AdoCommand cmd = new AdoCommand();
                MessageBox.Show(
                    cmd.executeProcedure((command) =>
                    {
                        cmd.priceRemove(command, textBoxTipo.Text, textBoxValor.Text, textBoxDuracao.Text, textBoxValidade.Text);
                    },
                    "Price has been removed successfully.",
                    "Error in removing price.")
                    );
            }
            #endregion
        }
    }
}
