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
    public partial class PrecoAddForm : Form
    {
        public PrecoAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Command cmd = new Command();
            MessageBox.Show(
                cmd.executeProcedure((command) => {
                    cmd.priceInsert(command, textBoxTipo.Text, textBoxValor.Text, textBoxDuracao.Text, textBoxValidade.Text);
                },
                "Price has been inserted successfully.",
                "Error in inserting price.")
                );
            this.Close();
        }
    }
}
