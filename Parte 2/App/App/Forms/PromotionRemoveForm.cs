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
    public partial class PromotionRemoveForm : Form
    {
        public PromotionRemoveForm()
        {
            InitializeComponent();
        }

        private void buttonRemoveDesconto_Click(object sender, EventArgs e)
        {
            if (Program.EntityFramework)
            {
                AEnimaEntities ctx = new AEnimaEntities();
                ctx.RemoverPromocaoDesconto(int.Parse(textBoxId.Text));
                MessageBox.Show("Promoção temporal removida.");
            }
            else
            {
                AdoCommand command = new AdoCommand();
                MessageBox.Show(command.executeProcedure((cmd) =>
                {
                    command.promotionDescontoRemove(cmd, textBoxId.Text);
                },
                    "Promotion removal was successfull.",
                    "Promotion removal failed."
                ));
            }
            this.Close();
        }

        private void buttonRemoveTemporal_Click(object sender, EventArgs e)
        {
            if (Program.EntityFramework)
            {
                AEnimaEntities ctx = new AEnimaEntities();
                ctx.RemoverPromocaoTemporal(int.Parse(textBoxId.Text));
                MessageBox.Show("Promoção temporal removida.");
            }
            else
            {
                AdoCommand command = new AdoCommand();
                MessageBox.Show(command.executeProcedure((cmd) =>
                {
                    command.promotionTemporalRemove(cmd, textBoxId.Text);
                },
                    "Promotion removal was successfull.",
                    "Promotion removal failed."
                ));
            }
            this.Close();
        }
    }
}
