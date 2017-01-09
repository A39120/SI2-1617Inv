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
using App.EF;

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
            if (Program.EntityFramework)
            {
                AEnimaEntities ctx = new AEnimaEntities();
                ctx.InserirPromocaoTemporal(DateTime.Parse(textBoxInicio.Text), 
                    DateTime.Parse(textBoxFim.Text),
                    textBoxDescricao.Text,
                    textBoxTipo.Text,
                    TimeSpan.Parse(textBoxTempoExtra.Text));
                MessageBox.Show("Promoção temporal inserida.");
            }
            else
            {
                AdoCommand command = new AdoCommand();
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
            }
            this.Close();
        }

        private void buttonAddDesconto_Click(object sender, EventArgs e)
        {
            if (Program.EntityFramework)
            {
                AEnimaEntities ctx = new AEnimaEntities();
                ctx.InserirPromocaoDesconto(DateTime.Parse(textBoxInicio.Text),
                    DateTime.Parse(textBoxFim.Text),
                    textBoxDescricao.Text,
                    textBoxTipo.Text,
                    double.Parse(textBoxDesconto.Text));
                MessageBox.Show("Promoção de desconto inserida.");
            }
            else
            {
                AdoCommand command = new AdoCommand();
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
            }
            this.Close();
        }
    }
}
