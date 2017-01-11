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
            using(ICommand cmd = Program.GetCommand())
            {
                //TODO: try, catch & handle return
                cmd.ActualizarPromocaoTemporal(textBoxId.Text,
                            textBoxInicio.Text,
                            textBoxFim.Text,
                            textBoxDescricao.Text,
                            textBoxTempoExtra.Text);
            }
        }

        private void buttonUpdateDesconto_Click(object sender, EventArgs e)
        {
            using(ICommand cmd = Program.GetCommand())
            {
                //TODO: try, catch & handle return
                cmd.ActualizarPromocaoDesconto(textBoxId.Text,
                        textBoxInicio.Text,
                        textBoxFim.Text,
                        textBoxDescricao.Text,
                        textBoxDesconto.Text);
            }
        }
    }
}
