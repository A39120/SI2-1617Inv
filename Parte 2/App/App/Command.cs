using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{

    class Command
    {

        public String executeProcedure(Action<SqlCommand> action, String success, String error){
            using(SqlConnection con = new SqlConnection()){
                con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    action(cmd);
                    try{
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return success;
                    }catch (Exception e){
                        return e.Message;
                    }
                }
            }
        }

        #region promotion
        #region promotion_insert
        public void promotionInsert(SqlCommand cmd,
            String textBoxTipo, 
            String textBoxDescricao, 
            String textBoxFim, 
            String textBoxInicio)
        {
            SqlParameter inicio = new SqlParameter("@inicio", SqlDbType.DateTime);
            SqlParameter fim = new SqlParameter("@fim", SqlDbType.DateTime);
            SqlParameter desc = new SqlParameter("@descricao", SqlDbType.VarChar, 255);
            SqlParameter tipo = new SqlParameter("@tipo", SqlDbType.VarChar, 31);
            
            tipo.Value = textBoxTipo;
            desc.Value = textBoxDescricao;
            fim.Value = textBoxFim;
            inicio.Value = textBoxInicio;
            
            //exec InserirPromocaoTemporal '2020-10-20 13:00:00', '2030-10-20 13:00:00', '1', 'Generic', '13:00:00'-- pId = 5
            //exec InserirPromocaoDesconto '2020-10-20 13:00:00', '2030-10-20 13:00:00', '1', 'Generic', 0.5-- pId = 6
            //exec InserirPromocaoTemporal @inicio, @fim, @descricao, @tipo, @tempoExtra
            //exec InserirPromocaoDesconto @inicio, @fim, @descricao, @tipo, @desconto
            
            cmd.Parameters.Add(tipo);
            cmd.Parameters.Add(fim);
            cmd.Parameters.Add(inicio);
            cmd.Parameters.Add(desc);
        }

        public void promotionTemporalInsert(SqlCommand cmd, 
            String textBoxTipo, 
            String textBoxDescricao, 
            String textBoxFim,
            String textBoxInicio,
            String textBoxTempoExtra)
        {
            promotionInsert(cmd, textBoxTipo, textBoxDescricao, textBoxFim, textBoxInicio);

            SqlParameter tempoExtra = new SqlParameter("@tempoExtra", SqlDbType.Time);
            tempoExtra.Value = textBoxTempoExtra;
            cmd.Parameters.Add(tempoExtra);

            cmd.CommandText = "InserirPromocaoTemporal";
        }

        public void promotionDescontoInsert(SqlCommand cmd,
            String textBoxTipo,
            String textBoxDescricao,
            String textBoxFim,
            String textBoxInicio,
            String textBoxDesconto)
        {
            promotionInsert(cmd, textBoxTipo, textBoxDescricao, textBoxFim, textBoxInicio);

            SqlParameter desconto = new SqlParameter("@desconto", SqlDbType.Float);
            desconto.Value = textBoxDesconto;
            cmd.Parameters.Add(desconto);

            cmd.CommandText = "InserirPromocaoDesconto";
        }
        #endregion 
        #region promotion_remove
        private void promotionRemove(SqlCommand cmd, 
            String textBoxId)
        {
            SqlParameter id = new SqlParameter("@pid", SqlDbType.Int);
            cmd.Parameters.Add(id);
            id.Value = textBoxId;
        }

        public void promotionTemporalRemove(SqlCommand cmd, 
            String textBoxId)
        {
            promotionRemove(cmd, textBoxId);
            cmd.CommandText = "RemoverPromocaoTemporal";
        }

        public void promotionDescontoRemove(SqlCommand cmd, 
            String textBoxId)
        {
            promotionRemove(cmd, textBoxId);
            cmd.CommandText = "RemoverPromocaoDesconto";
        }
        #endregion
        #region promotion_update
        public void promotionUpdate(SqlCommand cmd, 
            String inicio, 
            String fim, 
            String desc, 
            String id)
        {
            SqlParameter ParamInicio = new SqlParameter("@inicio", SqlDbType.DateTime);
            SqlParameter ParamFim = new SqlParameter("@fim", SqlDbType.DateTime);
            SqlParameter ParamDesc = new SqlParameter("@descricao", SqlDbType.VarChar, 255);
            SqlParameter ParamId = new SqlParameter("@promotion_id", SqlDbType.VarChar, 31);

            ParamId.Value = id;
            ParamDesc.Value = desc;
            ParamFim.Value = fim;
            ParamInicio.Value = inicio;

            cmd.Parameters.Add(id);
            cmd.Parameters.Add(fim);
            cmd.Parameters.Add(inicio);
            cmd.Parameters.Add(desc);
        }

        public void promotionTemporalUpdate(SqlCommand cmd, 
            String inicio, 
            String fim, 
            String desc, 
            String id, 
            String tempoExtra)
        {
            promotionUpdate(cmd, inicio, fim, desc, id);
            SqlParameter ParamTempoExtra = new SqlParameter("@tempoExtra", SqlDbType.Time);
            ParamTempoExtra.Value = tempoExtra;
            cmd.Parameters.Add(ParamTempoExtra);

            cmd.CommandText = "InserirPromocaoTemporal";
        }

        public void promotionDescontoUpdate(SqlCommand cmd, 
            String inicio, 
            String fim, 
            String desc, 
            String id, 
            String desconto)
        {
            promotionUpdate(cmd, inicio, fim, desc, id);
            SqlParameter paramDesconto = new SqlParameter("@desconto", SqlDbType.Float);
            paramDesconto.Value = desconto;
            cmd.Parameters.Add(paramDesconto);

            cmd.CommandText = "InserirPromocaoDesconto";
        }
        #endregion
        #endregion
        #region aluguer
        #region insert_aluguer
        public void insertAluguer(SqlCommand cmd, 
            String empregado, 
            String eqId, 
            String inicio, 
            String duracao, 
            String preco, 
            String pid)
        {
            SqlParameter param_empregado = new SqlParameter("@empregado", SqlDbType.Int);
            SqlParameter param_equipamento = new SqlParameter("@eqId", SqlDbType.Int);
            SqlParameter param_inicioAluguer = new SqlParameter("@inicioAluguer", SqlDbType.DateTime);
            SqlParameter param_duracao = new SqlParameter("@duracao", SqlDbType.Time);
            SqlParameter param_preco = new SqlParameter("@preco", SqlDbType.Float);
            SqlParameter param_promocao = new SqlParameter("@pid", SqlDbType.Int);

            param_empregado.Value = empregado;
            param_equipamento.Value = eqId;
            param_inicioAluguer.Value = inicio;
            param_duracao.Value = duracao;
            param_preco.Value = preco;
            param_promocao.Value = pid;

            cmd.Parameters.Add(param_empregado);
            cmd.Parameters.Add(param_equipamento);
            cmd.Parameters.Add(param_inicioAluguer);
            cmd.Parameters.Add(param_duracao);
            cmd.Parameters.Add(param_preco);
            cmd.Parameters.Add(param_promocao);
        }

        public void insertAluguerWithClientProcedure(SqlCommand cmd, String empregado,
            String eqId,
            String inicio,
            String duracao,
            String preco,
            String pid,
            String cliente)
        {
            insertAluguer(cmd, empregado, eqId, inicio, duracao, preco, pid);
            SqlParameter param_cliente = new SqlParameter("@cliente", SqlDbType.Int);
            param_cliente.Value = cliente;
            cmd.Parameters.Add(param_cliente);
            cmd.CommandText = "InserirAluguer";
        }

        public void insertAluguerWithNewClientProcedure(SqlCommand cmd, String empregado,
            String eqId,
            String inicio,
            String duracao,
            String preco,
            String pid,
            String cliente_nif,
            String cliente_morada, 
            String cliente_nome)
        {
            insertAluguer(cmd, empregado, eqId, inicio, duracao, preco, pid);
            SqlParameter clienteNif = new SqlParameter("@cliente_nif", SqlDbType.Int);
            SqlParameter clienteNome = new SqlParameter("@cliente_nome", SqlDbType.VarChar, 31);
            SqlParameter clienteMorada = new SqlParameter("@cliente_morada", SqlDbType.VarChar, 100);

            clienteNif.Value = cliente_nif;
            clienteMorada.Value = cliente_morada;
            clienteNome.Value = cliente_nome;

            cmd.Parameters.Add(clienteNif);
            cmd.Parameters.Add(clienteNome);
            cmd.Parameters.Add(clienteMorada);

            cmd.CommandText = "InserirAluguerComNovoCliente";
        }

        #endregion

        public void removeAluguerProcedure(SqlCommand cmd, String serialForm)
        {
            SqlParameter serial = new SqlParameter("@serial", SqlDbType.VarChar, 36);
            serial.Value = serialForm;
            cmd.Parameters.Add(serial);
            cmd.CommandText = "RemoverAluguer";
        }
        #endregion
        #region price
        public void priceInsert(SqlCommand cmd, String tipo, 
            String valor, String duracao, String validade)
        {
            SqlParameter tipoParam = new SqlParameter("@tipo", SqlDbType.VarChar, 31);
            SqlParameter valorParam = new SqlParameter("@valor", SqlDbType.Float);
            SqlParameter duracaoParam = new SqlParameter("@duracao", SqlDbType.Time);
            SqlParameter validadeParam = new SqlParameter("@validade", SqlDbType.Date);

            tipoParam.Value = tipo;
            valorParam.Value = valor;
            duracaoParam.Value = duracao;
            validadeParam.Value = validade;

            cmd.Parameters.Add(tipoParam);
            cmd.Parameters.Add(valorParam);
            cmd.Parameters.Add(duracaoParam);
            cmd.Parameters.Add(validadeParam);

            cmd.CommandText = "InserirPreco";
        }

        public void priceUpdate(SqlCommand cmd, String tipo,
            String valor, String duracao, String validade,
            String novovalor, String novaduracao, String novavalidade)
        {
            priceInsert(cmd, tipo, valor, duracao, validade);
            SqlParameter novovalorParam = new SqlParameter("@novovalor", SqlDbType.Float);
            SqlParameter novaduracaoParam = new SqlParameter("@novaduracao", SqlDbType.Time);
            SqlParameter novavalidadeParam = new SqlParameter("@novavalidade", SqlDbType.Date);

            novovalorParam.Value = novovalor;
            novaduracaoParam.Value = novaduracao;
            novavalidadeParam.Value = novavalidade;

            cmd.Parameters.Add(novovalorParam);
            cmd.Parameters.Add(novaduracaoParam);
            cmd.Parameters.Add(novavalidadeParam);

            cmd.CommandText = "ActualizarPreco";
        }

        public void priceRemove(SqlCommand cmd, String tipo, String valor, String duracao, String validade)
        {
            priceInsert(cmd, tipo, valor, duracao, validade);
            cmd.CommandText = "RemoverPreco";
        }
        #endregion

        /*public void manageTable(Action<SqlCommand> action, Action<SqlDataReader> action2)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    action(cmd);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    action2(sdr);
                    sdr.Close();
                }
            }
        }*/

        public void getLastWeekUnusedEquipments(SqlCommand cmd)
        {
            cmd.CommandText = "SELECT * FROM EquipamentosSemAlugueresNaUltimaSemana()";
        }

        public void getUnusedEquipmentsFor(SqlCommand cmd, String inicio, String fim)
        {
            SqlParameter paramInicio = new SqlParameter("@inicio", SqlDbType.DateTime);
            SqlParameter paramFim = new SqlParameter("@fim", SqlDbType.DateTime);

            paramInicio.Value = inicio;
            paramFim.Value = fim;
            cmd.Parameters.Add(paramInicio);
            cmd.Parameters.Add(paramFim);

            cmd.CommandText = "SELECT * FROM EquipamentosLivres(@inicio, @fim, NULL)";
        }
    }

    
}
