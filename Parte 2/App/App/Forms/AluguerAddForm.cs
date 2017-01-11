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
            if (textBoxCliente.Text.Equals(""))
            {
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
            else
            {
                #region EF
                if (Program.EntityFramework)
                {
                    using (EfCommand cmd = new EfCommand())
                    {
                        MessageBox.Show(
                            cmd.InserirAluguer(empregado, textBoxCliente.Text,
                                    equipamento,
                                    inicio,
                                    duracao,
                                    preco,
                                    pid)
                            );
                    }
                }
                #endregion
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
            }
        }
            
            
    }
}
