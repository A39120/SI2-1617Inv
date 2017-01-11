using App.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class AluguerRemoveForm : Form
    {
        public AluguerRemoveForm()
        {
            InitializeComponent();
        }

        private void buttonRemoverAluguer_Click(object sender, EventArgs e)
        {
            using (ICommand cmd = Program.GetCommand())
            {
                //TODO: Use result, try & catch
                cmd.RemoverAluguer(textBox1.Text);
            }
        }
    }
}
