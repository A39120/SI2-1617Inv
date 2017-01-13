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
            ICommand cmd;

            if (Program.EntityFramework)
            {
                
                using (cmd = Program.GetCommand())
                {
                    cmd.RemoverPromocaoDesconto(textBoxId.Text);
                }
            }
        }

        private void buttonRemoveTemporal_Click(object sender, EventArgs e)
        {
            using (ICommand cmd = Program.GetCommand())
            {
                //TODO: Use result, try & catch
                cmd.RemoverPromocaoTemporal(textBoxId.Text);
            }
        }
    }
}
