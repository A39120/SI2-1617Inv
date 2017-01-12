using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace App
{
    public class AdoCommand : ICommand
    {
        SqlConnection con;
        SqlDataReader reader = null;

        public AdoCommand()
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        private DataTable executeFunction(Action<SqlCommand> action) {
            using (SqlCommand cmd = con.CreateCommand()) {
                action(cmd);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
                reader.Close();
                return null;
            }
        }

        private T executeProcedure<T>(Func<SqlCommand, T> action){
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return action(cmd);
            }
        }

        private int ReturnRowNumber(SqlCommand cmd, Action<SqlCommand> action){
            action(cmd);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            return i;
        }

        private String ReturnSerial(SqlCommand cmd, Action<SqlCommand> action)
        {
            action(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            return (String)cmd.Parameters["@ret"].Value;
        }

        private int ReturnResult(SqlCommand cmd, Action<SqlCommand> action)
        {
            action(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ret"].Value; ;
        }

        #region parameters
        private void InsertPromotionParameters(SqlCommand cmd,
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
            
            cmd.Parameters.Add(tipo);
            cmd.Parameters.Add(fim);
            cmd.Parameters.Add(inicio);
            cmd.Parameters.Add(desc);
        }

        private void InsertPromotionTemporalParameters(SqlCommand cmd, 
            String textBoxTipo, 
            String textBoxDescricao, 
            String textBoxFim,
            String textBoxInicio,
            String textBoxTempoExtra)
        {
            InsertPromotionParameters(cmd, textBoxTipo, textBoxDescricao, textBoxFim, textBoxInicio);

            SqlParameter tempoExtra = new SqlParameter("@tempoExtra", SqlDbType.Time);
            tempoExtra.Value = textBoxTempoExtra;
            cmd.Parameters.Add(tempoExtra);

            cmd.CommandText = "InserirPromocaoTemporal";
        }

        private void InsertPromotionDescontoParameters(SqlCommand cmd,
            String textBoxTipo,
            String textBoxDescricao,
            String textBoxFim,
            String textBoxInicio,
            String textBoxDesconto)
        {
            InsertPromotionParameters(cmd, textBoxTipo, textBoxDescricao, textBoxFim, textBoxInicio);

            SqlParameter desconto = new SqlParameter("@desconto", SqlDbType.Float);
            desconto.Value = textBoxDesconto;
            cmd.Parameters.Add(desconto);

            cmd.CommandText = "InserirPromocaoDesconto";
        }

        private void RemovePromotionParameters(SqlCommand cmd, 
            String textBoxId)
        {
            SqlParameter id = new SqlParameter("@pid", SqlDbType.Int);
            cmd.Parameters.Add(id);
            id.Value = textBoxId;
        }

        private void RemovePromotionTemporalParameters(SqlCommand cmd, 
            String textBoxId)
        {
            RemovePromotionParameters(cmd, textBoxId);
            cmd.CommandText = "RemoverPromocaoTemporal";
        }

        private void RemovePromotionDescontoParameters(SqlCommand cmd, 
            String textBoxId)
        {
            RemovePromotionParameters(cmd, textBoxId);
            cmd.CommandText = "RemoverPromocaoDesconto";
        }

        private void UpdatePromotionParameters(SqlCommand cmd, 
            String inicio, 
            String fim, 
            String desc, 
            String id)
        {
            SqlParameter ParamInicio = new SqlParameter("@inicio", SqlDbType.DateTime);
            SqlParameter ParamFim = new SqlParameter("@fim", SqlDbType.DateTime);
            SqlParameter ParamDesc = new SqlParameter("@descr", SqlDbType.VarChar, 255);
            SqlParameter ParamId = new SqlParameter("@promotion_id", SqlDbType.VarChar, 31);

            ParamId.Value = id;
            ParamDesc.Value = desc;
            ParamFim.Value = fim;
            ParamInicio.Value = inicio;

            cmd.Parameters.Add(ParamId);
            cmd.Parameters.Add(ParamFim);
            cmd.Parameters.Add(ParamInicio);
            cmd.Parameters.Add(ParamDesc);
        }

        private void UpdatePromotionTemporalParameters(SqlCommand cmd, 
            String inicio, 
            String fim, 
            String desc, 
            String id, 
            String tempoExtra)
        {
            UpdatePromotionParameters(cmd, inicio, fim, desc, id);
            SqlParameter ParamTempoExtra = new SqlParameter("@tempoExtra", SqlDbType.Time);
            ParamTempoExtra.Value = tempoExtra;
            cmd.Parameters.Add(ParamTempoExtra);

            cmd.CommandText = "ActualizarPromocaoTemporal";
        }

        private void UpdatePromotionDescontoParameters(SqlCommand cmd, 
            String inicio, 
            String fim, 
            String desc, 
            String id, 
            String desconto)
        {
            UpdatePromotionParameters(cmd, inicio, fim, desc, id);
            SqlParameter paramDesconto = new SqlParameter("@desconto", SqlDbType.Float);
            paramDesconto.Value = desconto;
            cmd.Parameters.Add(paramDesconto);

            cmd.CommandText = "ActualizarPromocaoDesconto";
        }

        private void InsertAluguerParameters(SqlCommand cmd, 
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
            if (!pid.Equals(""))
            {
                SqlParameter param_promocao = new SqlParameter("@pid", SqlDbType.Int);
                param_promocao.Value = pid;
                cmd.Parameters.Add(param_promocao);
            }

            param_empregado.Value = empregado;
            param_equipamento.Value = eqId;
            param_inicioAluguer.Value = inicio;
            param_duracao.Value = duracao;
            param_preco.Value = preco;
            

            cmd.Parameters.Add(param_empregado);
            cmd.Parameters.Add(param_equipamento);
            cmd.Parameters.Add(param_inicioAluguer);
            cmd.Parameters.Add(param_duracao);
            cmd.Parameters.Add(param_preco);
            
        }

        private void InsertAluguerWithClientParameters(SqlCommand cmd, String empregado,
            String eqId,
            String inicio,
            String duracao,
            String preco,
            String pid,
            String cliente)
        {
            InsertAluguerParameters(cmd, empregado, eqId, inicio, duracao, preco, pid);
            SqlParameter param_cliente = new SqlParameter("@cliente", SqlDbType.Int);
            param_cliente.Value = cliente;
            cmd.Parameters.Add(param_cliente);
            cmd.CommandText = "InserirAluguer";
        }

        private void InsertAluguerWithNewClientParameters(SqlCommand cmd, String empregado,
            String eqId,
            String inicio,
            String duracao,
            String preco,
            String pid,
            String cliente_nif,
            String cliente_morada, 
            String cliente_nome)
        {
            InsertAluguerParameters(cmd, empregado, eqId, inicio, duracao, preco, pid);
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

        private void RemoveAluguerParameters(SqlCommand cmd, String serialForm)
        {
            SqlParameter serial = new SqlParameter("@serial", SqlDbType.VarChar, 36);
            serial.Value = serialForm;
            cmd.Parameters.Add(serial);
            cmd.CommandText = "RemoverAluguer";
        }

        private void InsertPriceParameters(SqlCommand cmd, String tipo, 
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

        private void UpdatePriceParameters(SqlCommand cmd, String tipo,
            String valor, String duracao, String validade,
            String novovalor, String novaduracao, String novavalidade)
        {
            InsertPriceParameters(cmd, tipo, valor, duracao, validade);
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

        private void RemovePriceParameters(SqlCommand cmd, String tipo, String valor, String duracao, String validade)
        {
            InsertPriceParameters(cmd, tipo, valor, duracao, validade);
            cmd.CommandText = "RemoverPreco";
        }

        private void GetLastWeekUnusedEquipments(SqlCommand cmd)
        {
            cmd.CommandText = "SELECT * FROM EquipamentosSemAlugueresNaUltimaSemana()";
        }

        private void GetUnusedEquipmentsFor(SqlCommand cmd, String inicio, String fim)
        {
            SqlParameter paramInicio = new SqlParameter("@inicio", SqlDbType.DateTime);
            SqlParameter paramFim = new SqlParameter("@fim", SqlDbType.DateTime);

            paramInicio.Value = inicio;
            paramFim.Value = fim;
            cmd.Parameters.Add(paramInicio);
            cmd.Parameters.Add(paramFim);

            cmd.CommandText = "SELECT * FROM EquipamentosLivres(@inicio, @fim, NULL)";
        }
#endregion 

        public object EquipamentosLivres(String inicio, String fim) {
            return executeFunction((cmd) => {
                GetUnusedEquipmentsFor(cmd, inicio, fim);
            });
        }

        public object EquipamentosSemAlugueresNaUltimaSemana() {
            return executeFunction((cmd) => {
                GetLastWeekUnusedEquipments(cmd);
            });
        }

        public String InserirAluguer(string empregado, string cliente, string equipamento, string inicio, string duracao, string preco, string prom)
        {
            Func<SqlCommand, String> ret = (comd) => ReturnSerial(comd,
                (cmd) => { InsertAluguerWithClientParameters(cmd, empregado, equipamento, inicio, duracao, preco, prom, cliente); });
            return executeProcedure(ret);
        }
        public String InserirAluguerComNovoCliente(string nif, string nome, string morada, string empregado, string eq, string inicio, string duracao, string preco, string pid)
        {
            Func<SqlCommand, String> ret = (comd) => ReturnSerial(comd,
                (cmd) => { InsertAluguerWithNewClientParameters(cmd, empregado, eq, inicio, duracao, preco, pid, nif, morada, nome); });
            return executeProcedure(ret);
        }
        public int RemoverAluguer(string id)
        {
            Func<SqlCommand, int> ret = (comd) => ReturnRowNumber(comd,
               (cmd) => { RemoveAluguerParameters(cmd, id); });
            return executeProcedure(ret);
        }
        public int InserirPreco(string tipo, string valor, string duracao, string validade)
        {
            Func<SqlCommand, int> ret = (comd) => ReturnRowNumber(comd,
                (cmd) => { InsertPriceParameters(cmd, tipo, valor, duracao, validade); });
            return executeProcedure(ret);
        }
        public int ActualizarPreco(string tipo, string valor, string duracao, string validade, string novovalor, string novaduracao, string novavalidade)
        {
            Func<SqlCommand, int> ret = (comd) => ReturnRowNumber(comd, 
                (cmd) => { UpdatePriceParameters(cmd, tipo, valor, duracao, validade, novovalor, novaduracao, novavalidade);} );
            return executeProcedure(ret);
        }
        public int RemoverPreco(string tipo, string valor, string duracao, string validade)
        {
            Func<SqlCommand, int> ret = (comd) => ReturnRowNumber(comd,
                (cmd) => { RemovePriceParameters(cmd, tipo, valor, duracao, validade); });
            return executeProcedure(ret);
        }
        public int InserirPromocaoTemporal(string inicio, string fim, string desc, string tipo, string tempoExtra)
        {
            Func<SqlCommand, int> ret = (comd) => ReturnRowNumber(comd,
                (cmd) => { InsertPromotionTemporalParameters(cmd, tipo, desc, fim, inicio, tempoExtra); });
            return executeProcedure(ret);
        }
        public int InserirPromocaoDesconto(string inicio, string fim, string desc, string tipo, string desconto)
        {
            Func<SqlCommand, int> ret = (comd) => ReturnRowNumber(comd,
                (cmd) => { InsertPromotionDescontoParameters(cmd, tipo, desc, fim, inicio, desconto); });
            return executeProcedure(ret);
        }
        public int RemoverPromocaoTemporal(string id)
        {
            Func<SqlCommand, int> ret = (comd) => ReturnRowNumber(comd,
                (cmd) => { RemovePromotionTemporalParameters(cmd, id); });
            return executeProcedure(ret);
        }
        public int RemoverPromocaoDesconto(string id)
        {
            Func<SqlCommand, int> ret = (comd) => ReturnRowNumber(comd,
                (cmd) => { RemovePromotionDescontoParameters(cmd, id); });
            return executeProcedure(ret);
        }
        public int ActualizarPromocaoTemporal(string id, string inicio, string fim, string desc, string tempoExtra)
        {
            Func<SqlCommand, int> ret = (comd) => ReturnRowNumber(comd,
                (cmd) => { UpdatePromotionTemporalParameters(cmd, inicio, fim, desc, id, tempoExtra); });
            return executeProcedure(ret);
        }
        public int ActualizarPromocaoDesconto(string id, string inicio, string fim, string desc, string desconto)
        {
            Func<SqlCommand, int> ret = (comd) => ReturnRowNumber(comd,
                (cmd) => { UpdatePromotionDescontoParameters(cmd, inicio, fim, desc, id, desconto); });
            return executeProcedure(ret);
        }
        public string ExportarXml(string inicio, string fim)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(xmlType),"xml");
            xmlType xml = new xmlType();
            xml.alugueres = new alugueresType();
            xml.alugueres.dataInicio = inicio;
            xml.alugueres.dataFim = fim;

            using (SqlCommand cmd = con.CreateCommand())
            {
                AluguerTable at = new AluguerTable();
                SqlDataAdapter adapterAluguer;
                SqlParameter param_inicio = new SqlParameter("@inicio", SqlDbType.DateTime);
                SqlParameter param_fim = new SqlParameter("@fim", SqlDbType.DateTime);
                param_inicio.Value = inicio;
                param_fim.Value = fim;

                cmd.Parameters.Add(param_inicio);
                cmd.Parameters.Add(param_fim);
                cmd.CommandText = "SELECT id, eq.tipo as tipo, equipamento, cliente " +
                    "FROM AluguerView al INNER JOIN Equipamento eq ON (al.equipamento = eq.eqId) " +
                    "WHERE dataInicio >= @inicio AND dataFim <= @fim";
                adapterAluguer = new SqlDataAdapter(cmd);
                adapterAluguer.Fill(at);
                xml.alugueres.aluguer = new aluguerType[at.Select().Length];

                int count = 0;
                foreach(DataRow row in at.Rows){
                    xml.alugueres.aluguer[count] = new aluguerType();
                    xml.alugueres.aluguer[count].cliente = row["cliente"].ToString();
                    xml.alugueres.aluguer[count].equipamento = row["equipamento"].ToString();
                    xml.alugueres.aluguer[count].id = row["id"].ToString();
                    xml.alugueres.aluguer[count].tipo = row["tipo"].ToString();
                    count++;
                }
            }
            String path =  Environment.CurrentDirectory + "\\ADOAlugueres" + inicio.Replace(":", "").Replace(" ", "") + "_" + fim.Replace(":", "").Replace(" ", "") + ".xml";
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, xml);
                return path;
            }
        }

        public void Dispose()
        {
            if(con != null) 
                con.Dispose();
        }
    }
}
