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
    public partial class AluguerAddForm : Form
    {   

        public AluguerAddForm()
        {
            InitializeComponent();
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            List<SqlParameter> col = new List<SqlParameter>();
            SqlParameter empregado = new SqlParameter("@empregado", SqlDbType.Int);
            SqlParameter equipamento = new SqlParameter("@eqId", SqlDbType.Int);
            SqlParameter inicioAluguer = new SqlParameter("@inicioAluguer", SqlDbType.DateTime);
            SqlParameter duracao = new SqlParameter("@duracao", SqlDbType.Time);
            SqlParameter preco = new SqlParameter("@preco", SqlDbType.Float);
            SqlParameter promocao = new SqlParameter("@pid", SqlDbType.Int);

            empregado.Value = textBoxEmpregado.Text;
            equipamento.Value = textBoxEquipamento.Text;
            inicioAluguer.Value = textBoxInicio.Text;
            duracao.Value = textBoxDuracao.Text;
            preco.Value = textBoxPreco.Text;
            promocao.Value = textBoxPromocao.Text;

            col.Add(empregado);
            col.Add(equipamento);
            col.Add(inicioAluguer);
            col.Add(duracao);
            col.Add(preco);
            col.Add(promocao);

            if(textBoxCliente.Equals("")){
                AluguerClienteAddForm acaf = new AluguerClienteAddForm(col);
                acaf.Show();
            }
            else
            {
                using (SqlConnection con = new SqlConnection())
                {
                    using(SqlCommand cmd = new SqlCommand(){
                        CommandType = CommandType.StoredProcedure
                    }){
                        SqlParameter cliente = new SqlParameter("@cliente", SqlDbType.Int);
                        cliente.Value = textBoxCliente.Text;

                        col.Add(cliente);
                        col.ForEach((param) => cmd.Parameters.Add(param));

                        cmd.CommandText = "InserirAluguer";
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Aluguer adicionado.");

                        }
                        catch
                        {
                            MessageBox.Show("Não se conseguiu adicionar o Aluguer.");
                        }
                       
                    }

                }
            }
            this.Close();
        }

        
    }
}
