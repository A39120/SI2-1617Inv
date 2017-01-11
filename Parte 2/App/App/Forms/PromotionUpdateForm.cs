using App.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class PromotionUpdateForm : Form
    {
        public PromotionUpdateForm()
        {
            InitializeComponent();
        }

        private void buttonUpdateTempo_Click(object sender, EventArgs e)
        {
            if (Program.EntityFramework)
            {
                using (EfCommand cmd = new EfCommand())
                {
                    MessageBox.Show(cmd.ActualizarPromocaoTemporal(textBoxId.Text,
                            textBoxInicio.Text,
                            textBoxFim.Text,
                            textBoxDescricao.Text,
                            textBoxTempoExtra.Text));
                }
            }
            else
            {
                AdoCommand cmd = new AdoCommand();
                MessageBox.Show(cmd.executeProcedure((command) =>
                    {
                        cmd.promotionTemporalUpdate(command,
                          textBoxInicio.Text,
                          textBoxFim.Text,
                          textBoxDescricao.Text,
                          textBoxId.Text,
                          textBoxTempoExtra.Text);
                    },
                    "Promotion updated successfully.",
                    "Error in updating promotion:"
                ));
            }
        }

        private void buttonUpdateDesconto_Click(object sender, EventArgs e)
        {
            if (Program.EntityFramework)
            {
                using (EfCommand cmd = new EfCommand())
                {
                    MessageBox.Show(cmd.ActualizarPromocaoDesconto(textBoxId.Text,
                        textBoxInicio.Text,
                        textBoxFim.Text,
                        textBoxDescricao.Text,
                        textBoxDesconto.Text));
                }
            }
            else
            {
                AdoCommand cmd = new AdoCommand();
                MessageBox.Show(cmd.executeProcedure((command) =>
                {
                    cmd.promotionDescontoUpdate(command,
                      textBoxInicio.Text,
                      textBoxFim.Text,
                      textBoxDescricao.Text,
                      textBoxId.Text,
                      textBoxDesconto.Text);
                },
                    "Promotion updated successfully.",
                    "Error in updating promotion:"
                ));
            }
        }
    }
}
