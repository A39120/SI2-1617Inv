using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using App.EF;
using App.ADO.NET;
using App;

namespace UnitTests {
    [TestClass]
    public class UnitTests {
        [TestMethod]
        public void CompareADO_VS_EF() {
            Stopwatch sw = new Stopwatch();
            int MAX_RUNS = 20;

            // Test EF speed for EquipamentosSemAlugueresNaUltimaSemana
            sw.Start();
            for (int i = 0; i < MAX_RUNS; i++ )
                using (EfCommand cmd = new EfCommand()) {
                    cmd.EquipamentosSemAlugueresNaUltimaSemana();
                }
            sw.Stop();
            long EFtime = sw.ElapsedMilliseconds;

            // Test ADO.NET speed for EquipamentosSemAlugueresNaUltimaSemana
            sw.Reset();
            sw.Start();
            for (int i = 0; i < MAX_RUNS; i++)
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                    using (SqlCommand cmd = con.CreateCommand()) {
                        App.AdoCommand command = new AdoCommand();
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows) {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                        }
                        reader.Close();
                    }
                }
            sw.Stop();
            long ADOdotNETtime = sw.ElapsedMilliseconds;

            Console.WriteLine(
                "EF: " + EFtime + "ms" +
                "ADO.NET: " + ADOdotNETtime + "ms"
            );
        }
    }
}
