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
            #region EF
            if (Program.EntityFramework)
            {
                using (EfCommand cmd = new EfCommand())
                {
                    MessageBox.Show(
                        cmd.InserirPromocaoTemporal(textBoxInicio.Text, 
                            textBoxFim.Text,
                            textBoxDescricao.Text,
                            textBoxTipo.Text,
                            textBoxTempoExtra.Text)
                        );
                }
            }
            #endregion
            #region ADO
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
            #endregion
        }

        private void buttonAddDesconto_Click(object sender, EventArgs e)
        {
            if (Program.EntityFramework)
            {
                using (EfCommand cmd = new EfCommand())
                {
                    MessageBox.Show(
                        cmd.InserirPromocaoDesconto(textBoxInicio.Text,
                            textBoxFim.Text,
                            textBoxDescricao.Text,
                            textBoxTipo.Text,
                            textBoxDesconto.Text)
                        );
                }
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
        }
    }
}
