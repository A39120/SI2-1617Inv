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
                AEnimaEntities ctx = new AEnimaEntities();
                ctx.ActualizarPromocaoTemporal(int.Parse(textBoxId.Text),
                    DateTime.Parse(textBoxInicio.Text),
                    DateTime.Parse(textBoxFim.Text),
                    textBoxDescricao.Text,
                    TimeSpan.Parse(textBoxTempoExtra.Text)
                    );
                MessageBox.Show("Promoção temporal actualizada.");
            }
            else
            {
                AdoCommand cmd = new AdoCommand();
                MessageBox.Show(cmd.executeProcedure((command) =>
                    {
                        cmd.promotionTemporalUpdate(command,
                          textBoxId.Text,
                          textBoxDescricao.Text,
                          textBoxFim.Text,
                          textBoxInicio.Text,
                          textBoxTempoExtra.Text);
                    },
                    "Promotion updated successfully.",
                    "Error in updating promotion:"
                ));
            }
            this.Close();
        }

        private void buttonUpdateDesconto_Click(object sender, EventArgs e)
        {
            if (Program.EntityFramework)
            {
                AEnimaEntities ctx = new AEnimaEntities();
                ctx.ActualizarPromocaoDesconto(int.Parse(textBoxId.Text),
                    DateTime.Parse(textBoxInicio.Text),
                    DateTime.Parse(textBoxFim.Text),
                    textBoxDescricao.Text,
                    float.Parse(textBoxDesconto.Text)
                    );
                MessageBox.Show("Promoção de desconto actualizada.");
            }
            else
            {
                AdoCommand cmd = new AdoCommand();
                MessageBox.Show(cmd.executeProcedure((command) =>
                {
                    cmd.promotionDescontoUpdate(command,
                      textBoxId.Text,
                      textBoxDescricao.Text,
                      textBoxFim.Text,
                      textBoxInicio.Text,
                      textBoxDesconto.Text);
                },
                    "Promotion updated successfully.",
                    "Error in updating promotion:"
                ));
            }
            this.Close();
        }
    }
}
