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
            Command cmd = new Command();
            MessageBox.Show(cmd.executeProcedure((command) =>
                { cmd.promotionTemporalUpdate(command, 
                    textBoxId.Text, 
                    textBoxDescricao.Text, 
                    textBoxFim.Text, 
                    textBoxInicio.Text, 
                    textBoxTempoExtra.Text); 
                },
                "Promotion updated successfully.",
                "Error in updating promotion:"
            ));
            this.Close();
        }

        private void buttonUpdateDesconto_Click(object sender, EventArgs e)
        {
            Command cmd = new Command();
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
            this.Close();
        }
    }
}
