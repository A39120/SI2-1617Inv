using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace App
{
    public partial class AluguerAddForm : Form
    {   

        public AluguerAddForm()
        {
            InitializeComponent();
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {

            Command command = new Command();
            if(textBoxCliente.Text.Equals("")){
                Dictionary<String, String> dic = new Dictionary<string, string>();
                dic.Add("empregado", textBoxEmpregado.Text);
                dic.Add("eqId", textBoxEquipamento.Text);
                dic.Add("inicio", textBoxInicio.Text);
                dic.Add("duracao", textBoxDuracao.Text);
                dic.Add("preco", textBoxPreco.Text);
                dic.Add("pid", textBoxPromocao.Text);
                AluguerClienteAddForm acaf = new AluguerClienteAddForm(dic);
                acaf.Show();
            }
            else
            {
                MessageBox.Show(
                    command.executeProcedure((cmd)=> {
                        command.insertAluguerWithClientProcedure(cmd, 
                            textBoxEmpregado.Text, 
                            textBoxEquipamento.Text, 
                            textBoxInicio.Text, 
                            textBoxDuracao.Text, 
                            textBoxPreco.Text, 
                            textBoxPromocao.Text, 
                            textBoxCliente.Text);
                    },
                    "Aluguer inserted with success.", 
                    "Aluguer insert failed.")
                );
            }
            this.Close();
        }
    }
}
