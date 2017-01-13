using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using App.EF;
using App;
using App.ADO.NET;

namespace UnitTests {
    [TestClass]
    public class PerformanceTest {
        [TestMethod]
        public void CompareADO_VS_EF() {
            Stopwatch sw = new Stopwatch();
            int MAX_RUNS = 50;

            // Test EF speed for EquipamentosSemAlugueresNaUltimaSemana
            long EFBestTime = int.MaxValue;
            sw.Start();
            for (int i = 0; i < MAX_RUNS; i++) {
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                using (EfCommand cmd = new EfCommand()) {
                    cmd.EquipamentosSemAlugueresNaUltimaSemana();
                }
                sw2.Stop();
                EFBestTime = (sw2.ElapsedTicks < EFBestTime) ? sw2.ElapsedTicks : EFBestTime;
            }
            sw.Stop();
            long EFtime = sw.ElapsedMilliseconds;

            // Test ADO.NET speed for EquipamentosSemAlugueresNaUltimaSemana
            sw.Reset();
            sw.Start();

            long ADOdotNETBestTime = int.MaxValue;
            for (int i = 0; i < MAX_RUNS; i++) {
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                using (AdoCommand cmd = new AdoCommand()) {
                    cmd.EquipamentosSemAlugueresNaUltimaSemana();
                }
                sw2.Stop();
                ADOdotNETBestTime = (sw2.ElapsedTicks < ADOdotNETBestTime) ? sw2.ElapsedTicks : ADOdotNETBestTime;
            }

            sw.Stop();
            long ADOdotNETtime = sw.ElapsedMilliseconds;

            Console.WriteLine(
                "EF -> Total time: " + EFtime + "ms Best time: " + EFBestTime + "ticks" +
                "\nADO.NET -> Total time: " + ADOdotNETtime + "ms Best time: " + ADOdotNETBestTime + "ticks"
            );
        }

        [TestMethod]
        public void CompareADO_VS_EF_Round2() {
            Stopwatch sw = new Stopwatch();
            int MAX_RUNS = 50;
            int ignore = 0;

            // Test EF speed for InserirPreco followed by RemoverPreco
            long EFBestTime = int.MaxValue;
            sw.Start();
            for (int i = 0; i < MAX_RUNS; i++) {
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                using (EfCommand cmd = new EfCommand()) {
                    // inserir
                    ignore = cmd.InserirPreco("Baldes", "9999" + i, "23:00:00", "3000-01-01 00:00:00");
                }
                using (EfCommand cmd = new EfCommand()) {
                    // remover o que inserimos
                    ignore = cmd.RemoverPreco("Baldes", "9999" + i, "23:00:00", "3000-01-01 00:00:00");
                }
                sw2.Stop();
                EFBestTime = (sw2.ElapsedTicks < EFBestTime) ? sw2.ElapsedTicks : EFBestTime;
            }
            sw.Stop();
            long EFtime = sw.ElapsedMilliseconds;

            // Test ADO.NET speed for InserirPreco followed by RemoverPreco
            sw.Reset();
            sw.Start();

            long ADOdotNETBestTime = int.MaxValue;
            for (int i = 0; i < MAX_RUNS; i++) {
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                using (AdoCommand cmd = new AdoCommand()) {
                    // inserir
                    ignore = cmd.InserirPreco("Baldes", "9999" + i, "23:00:00", "3000-01-01 00:00:00");
                }
                using (AdoCommand cmd = new AdoCommand()) {
                    // remover o que inserimos
                    ignore = cmd.RemoverPreco("Baldes", "9999" + i, "23:00:00", "3000-01-01 00:00:00");
                }
                sw2.Stop();
                ADOdotNETBestTime = (sw2.ElapsedTicks < ADOdotNETBestTime) ? sw2.ElapsedTicks : ADOdotNETBestTime;
            }

            sw.Stop();
            long ADOdotNETtime = sw.ElapsedMilliseconds;

            Console.WriteLine(
                "EF -> Total time: " + EFtime + "ms Best time: " + EFBestTime + "ticks" +
                "\nADO.NET -> Total time: " + ADOdotNETtime + "ms Best time: " + ADOdotNETBestTime + "ticks"
            );
        }
    }
}
