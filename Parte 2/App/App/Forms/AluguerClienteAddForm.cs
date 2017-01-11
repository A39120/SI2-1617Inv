using App.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class AluguerClienteAddForm : Form
    {
        Dictionary<String, String> values;
        public AluguerClienteAddForm(Dictionary<String, String> values)
        {
            InitializeComponent();
            this.values = values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(ICommand cmd = Program.GetCommand())
            {
                //TODO: try, catch & handle return
                cmd.InserirAluguerComNovoCliente(
                    textBoxNif.Text,
                    textBoxNome.Text,
                    textBoxMorada.Text,
                    values["empregado"],
                    values["eqId"],
                    values["inicio"], 
                    values["duracao"], 
                    values["preco"], 
                    values["pid"]);
            }
            this.Close();
        }
    }
}
