using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace App
{
    public partial class PromotionAddForm : Form
    {
        public PromotionAddForm()
        {
            InitializeComponent();
        }

        private void buttonAddTempo_Click(object sender, EventArgs e)
        {
            Command command = new Command();
            MessageBox.Show(command.executeProcedure(
                (cmd) =>
                {
                    command.promotionTemporalInsert(cmd,
                        textBoxTipo.Text,
                        textBoxDescricao.Text,
                        textBoxFim.Text,
                        textBoxInicio.Text,
                        textBoxTempoExtra.Text);
                }, "Promotion inserted with success.",
                "Failed in inserting new promotion"
            ));
            this.Close();

        }

        private void buttonAddDesconto_Click(object sender, EventArgs e)
        {
            Command command = new Command();
            MessageBox.Show(command.executeProcedure(
                (cmd) =>
                {
                    command.promotionDescontoInsert(cmd,
                        textBoxTipo.Text,
                        textBoxDescricao.Text,
                        textBoxFim.Text,
                        textBoxInicio.Text,
                        textBoxDesconto.Text);
                }, "Promotion inserted with success.",
                "Failed in inserting new promotion"
            ));
            this.Close();
        }
    }
}
