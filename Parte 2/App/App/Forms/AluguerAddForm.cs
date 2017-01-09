using App.EF;
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
            String empregado = textBoxEmpregado.Text;
            String equipamento = textBoxEquipamento.Text;
            String inicio = textBoxInicio.Text;
            String duracao = textBoxDuracao.Text;
            String preco = textBoxPreco.Text;
            String pid = textBoxPromocao.Text;
            if (textBoxCliente.Text.Equals("")){
                Dictionary<String, String> dic = new Dictionary<string, string>();
                dic.Add("empregado", empregado);
                dic.Add("eqId", equipamento);
                dic.Add("inicio", inicio);
                dic.Add("duracao", duracao);
                dic.Add("preco", preco);
                dic.Add("pid", pid);
                AluguerClienteAddForm acaf = new AluguerClienteAddForm(dic);
                acaf.Show();
                this.Close();
            }
            if (Program.EntityFramework) {
                AEnimaEntities ctx = new AEnimaEntities();
                ctx.InserirAluguer(
                    int.Parse(empregado),
                    int.Parse(textBoxCliente.Text),
                    int.Parse(equipamento), 
                    DateTime.Parse(inicio), 
                    TimeSpan.Parse(duracao), 
                    double.Parse(preco), 
                    int.Parse(pid));
                MessageBox.Show("Aluguer inserido.");
            }
            #region ADO
            else
            {
                AdoCommand command = new AdoCommand();
                MessageBox.Show(
                        command.executeProcedure((cmd) =>
                        {
                            command.insertAluguerWithClientProcedure(cmd,
                                empregado,
                                equipamento,
                                inicio,
                                duracao,
                                preco,
                                pid,
                                textBoxCliente.Text);
                        },
                        "Aluguer inserted with success.",
                        "Aluguer insert failed.")
                    );
                }
            #endregion
            this.Close();
        }
            
            
    }
}
