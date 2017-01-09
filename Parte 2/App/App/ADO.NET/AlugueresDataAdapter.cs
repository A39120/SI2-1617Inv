using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ADO.NET
{
    class AlugueresDataAdapter
    {
        public void exportAlugueresToXml(String inicio, String fim)
        {
            AlugueresDataSet ds = new AlugueresDataSet();
            SqlDataAdapter adapterAluguer, adapterAlugueres; //adapterEquipamento
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    SqlParameter param_inicio = new SqlParameter("@inicio", SqlDbType.DateTime);
                    SqlParameter param_fim = new SqlParameter("@fim", SqlDbType.DateTime);
                    param_inicio.Value = inicio;
                    param_fim.Value = fim;
            
                    cmd.Parameters.Add(param_inicio);
                    cmd.Parameters.Add(param_fim);
                    cmd.CommandText = "SELECT @inicio as dataInicio, @fim as dataFim, al.serial as id " +
                        "FROM Aluguer al INNER JOIN AluguerDataFim adf ON (al.serial = adf.serial_adf) "+
                        "WHERE al.data_inicio >= @inicio AND adf.data_fim <= @fim";
                    adapterAlugueres = new SqlDataAdapter(cmd);
                    adapterAlugueres.Fill(ds.AlugueresTable);
            
                    cmd.CommandText = "SELECT serial as id, tipo, al.eqId as equipamento, cliente " +
                        "FROM Aluguer al INNER JOIN Equipamento eq ON (al.eqId = eq.eqId) " +
                        "INNER JOIN AluguerDataFim adf ON (al.serial = adf.serial_adf) "+
                        "WHERE al.deleted = 0 AND data_inicio >= @inicio AND adf.data_fim <= @fim"; 
                    adapterAluguer = new SqlDataAdapter(cmd);
                    adapterAluguer.Fill(ds.AluguerTable);
            
                    DataRelation alugueres = ds.Relations.Add("xml",  
                        ds.Tables["alugueres"].Columns["id"], ds.Tables["aluguer"].Columns["id"]);
            
                    alugueres.Nested = true;
                    
                }
                ds.WriteXml("VendorDS.XML"); //TODO: Fix this
            }
        }
    }
}
