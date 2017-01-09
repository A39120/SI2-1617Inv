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
            
            if (Program.EntityFramework) {
                AEnimaEntities ctx = new AEnimaEntities();
                ctx.InserirAluguerComNovoCliente(
                    int.Parse(textBoxNif.Text),
                    textBoxNome.Text,
                    textBoxMorada.Text,
                    int.Parse(values["empregado"]),
                    int.Parse(values["eqId"]),
                    DateTime.Parse(values["inicio"]), 
                    TimeSpan.Parse(values["duracao"]), 
                    double.Parse(values["preco"]), 
                    int.Parse(values["pid"]));
                MessageBox.Show("Aluguer e novo clientes inserido.");
            }
            #region ADO
            else 
                        {
            AdoCommand command = new AdoCommand();
            MessageBox.Show(command.executeProcedure(
                    (cmd) =>
                    {
                        command.insertAluguerWithNewClientProcedure(cmd,
                            values["empregado"],
                            values["eqId"],
                            values["inicio"],
                            values["duracao"],
                            values["preco"],
                            values["pid"],
                            textBoxNif.Text,
                            textBoxNome.Text,
                            textBoxMorada.Text
                        );
                    }, 
                    "Cliente and Aluguer added with success.",
                    "Failed to insert Cliente and Aluguer."
                ));
        }
            #endregion
            this.Close();
        }
    }
}
