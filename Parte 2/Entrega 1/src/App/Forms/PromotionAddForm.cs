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
            using(ICommand cmd = Program.GetCommand())
            {
                //TODO: try, catch & handle return
                cmd.InserirPromocaoTemporal(textBoxInicio.Text, 
                            textBoxFim.Text,
                            textBoxDescricao.Text,
                            textBoxTipo.Text,
                            textBoxTempoExtra.Text);

            }
        }

        private void buttonAddDesconto_Click(object sender, EventArgs e)
        {
            using(ICommand cmd = Program.GetCommand())
            {
                //TODO: try, catch & handle return
                cmd.InserirPromocaoDesconto(textBoxInicio.Text,
                    textBoxFim.Text,
                    textBoxDescricao.Text,
                    textBoxTipo.Text,
                    textBoxDesconto.Text);
            }
        }
    }
}
