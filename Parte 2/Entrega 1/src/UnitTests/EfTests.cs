using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using App.EF;
using System.Data;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace UnitTests
{
    [TestClass]
    public class EfTests
    {
        /*[TestMethod]
        public void Ef_MethodToRunTestsInOrder() {
            Ef_ActualizarPreco_test();
            Ef_ActualizarPromocaoDesconto_test();
            Ef_ActualizarPromocaoTemporal_test();
            Ef_InserirAluguer_test();
            Ef_InserirAluguerComNovoCliente_test();
            Ef_InserirPreco_test();
            Ef_InserirPromocaoDesconto_test();
            Ef_InserirPromocaoTemporal_test();
            Ef_RemoverAluguer_test();
            Ef_RemoverPreco_test();
            Ef_RemoverPromocaoTemporal_test();
            Ef_RemoverPromocaoDesconto_test();
        }*/

        [TestMethod]
        public void Ef_InserirAluguer_test()
        {
            using(EfCommand cmd = new EfCommand()) 
            {

                var aluguerView = cmd.GetContext().AluguerView;
                String aluguerId = cmd.InserirAluguer("1", "1", "1", "2187-01-01 00:00:00", "01:00:00", "10,0", "");
                var selectAluguer = cmd.GetContext().AluguerView.Where((al) => al.id == aluguerId);
                Assert.IsTrue(selectAluguer.Count() != 0);

            }
        }

        [TestMethod]
        public void Ef_InserirAluguerComNovoCliente_test()
        {
            using (EfCommand cmd = new EfCommand())
            {
                    //Select Cliente
                    var cliente = cmd.GetContext().Cliente.Where((c) => c.nif == 123132321);
                    Assert.IsTrue(cliente.Count() == 0);

                    String aluguerId = cmd.InserirAluguerComNovoCliente("123132321", "Antonio Costa", "Belem", "1", "1", "2187-01-01 00:00:00", "01:00:00", "10,0", "");

                    //Select Cliente
                    var cliente2 = cmd.GetContext().Cliente.Where((c) => c.nif == 123132321);
                    Assert.IsFalse(cliente2.Count() == 0);

                    //Select Aluguer
                    var selectAluguer = cmd.GetContext().AluguerView.Where((al) => al.id == aluguerId);
                    Assert.IsTrue(selectAluguer.Count() != 0);

            }
        }

        [TestMethod]
        public void Ef_RemoverAluguer_test()
        {
            using(EfCommand cmd = new EfCommand()) 
            {
                var aluguerView = cmd.GetContext().AluguerView;
                String id = aluguerView.First().id;
                int row = cmd.RemoverAluguer(id);
                var selectAluguer = aluguerView.Where((al) => al.id == id);
            }
        }

        [TestMethod]
        public void Ef_InserirPreco_test()
        {
            String tipo = "Baldes", valor = "20,0", duracao = "2:00:00", validade = "3000-10-10 10:00:00";

                using (EfCommand cmd = new EfCommand())
                {
                    var preco1 = cmd.GetContext().Preco.Where((prec)=>prec.tipo == tipo && prec.valor == 20);
                    Assert.IsTrue(preco1.Count() == 0);

                    int row = cmd.InserirPreco(tipo, valor, duracao, validade);
                    Assert.AreEqual(1, row);
                    var preco2 = cmd.GetContext().Preco.Where((prec) => prec.tipo == tipo && prec.valor == 20);
                    Assert.IsFalse(preco1.Count() == 0);
                }
            
        }

        [TestMethod]
        public void Ef_ActualizarPreco_test()
        {
            String nome = "Baldes", preco = "5,00", duracao = "00:45:00", validade = "3000-10-10 10:00:00";
            using (EfCommand cmd = new EfCommand())
            {

                var duracaoParsed = TimeSpan.Parse(duracao);
                var preco1 = cmd.GetContext().Preco.Where((prec) => prec.tipo == nome && prec.valor == 5 && prec.duracao == duracaoParsed);
                Assert.IsTrue(preco1.Count() == 1);

                int row = cmd.ActualizarPreco(nome, preco, duracao, validade, "5,00", "00:30:00", "3000-10-10 10:00:00");
                Assert.AreEqual(2, row);

                var preco2 = cmd.GetContext().Preco.Where((prec) => prec.tipo == nome && prec.valor == 5 && prec.duracao == duracaoParsed);
                Assert.IsFalse(preco1.Count() == 1);
            }
        }

        [TestMethod]
        public void Ef_RemoverPreco_test()
        {
            String nome = "Baldes", preco = "7,00", duracao = "00:50:00", validade = "3000-10-10 10:00:00";
            using (EfCommand cmd = new EfCommand())
            {

                var duracaoParsed = TimeSpan.Parse(duracao);
                var preco1 = cmd.GetContext().Preco.Where((prec) => prec.tipo == nome && prec.valor == 7 && prec.duracao == duracaoParsed);
                Assert.IsTrue(preco1.Count() > 0);

                int row = cmd.RemoverPreco(nome, preco, duracao, validade);
                Assert.AreEqual(1, row);

                var preco2 = cmd.GetContext().Preco.Where((prec) => prec.tipo == nome && prec.valor == 7 && prec.duracao == duracaoParsed);
                Assert.IsTrue(preco1.Count() == 0);
            }
            
        }

        [TestMethod]
        public void Ef_InserirPromocaoTemporal_test()
        {

            using (EfCommand cmd = new EfCommand())
            {
                int pid = cmd.InserirPromocaoTemporal("2000-10-10 10:00:00", "3000-10-10 10:00:00", "Teste Promocao Temporal", "Baldes", "1:00:00");
                Assert.AreEqual(3, pid);
            }
            
        }

        [TestMethod]
        public void Ef_InserirPromocaoDesconto_test()
        {
            using (EfCommand cmd = new EfCommand())
            {
                int pid = cmd.InserirPromocaoDesconto("2000-10-10 10:00:00", "3000-10-10 10:00:00", "Teste Promocao Temporal", "Baldes", "0,7");
                Assert.AreEqual(3, pid);
            }
        }

        [TestMethod]
        public void Ef_RemoverPromocaoTemporal_test()
        {
            using (EfCommand cmd = new EfCommand())
            {
                var promocao = cmd.GetContext().PromocaoTemporal.Where(p=>p.pId==1);
                Assert.IsTrue(promocao.Count()==1);

                int row = cmd.RemoverPromocaoTemporal("1");
                Assert.AreEqual(3, row);

                var promocao2 = cmd.GetContext().PromocaoTemporal.Where(p => p.pId == 1);
                Assert.IsTrue(promocao2.Count() == 0);
            }
        }

        [TestMethod]
        public void Ef_RemoverPromocaoDesconto_test()
        {
            using (EfCommand cmd = new EfCommand())
            {
                var promocao = cmd.GetContext().PromocaoDesconto.Where(p => p.pId == 2);
                Assert.IsTrue(promocao.Count() == 1);

                int row = cmd.RemoverPromocaoDesconto("2");
                Assert.AreEqual(3, row);

                var promocao2 = cmd.GetContext().PromocaoDesconto.Where(p => p.pId == 2);
                Assert.IsTrue(promocao2.Count() == 0);
            }
            
        }

        [TestMethod]
        public void Ef_ActualizarPromocaoTemporal_test()
        {
            String id = "3";
            String desc = "Promocao Temporal Ado Actualizada";
            using (EfCommand cmd = new EfCommand())
            {
                var promocao = cmd.GetContext().Promocao.Where(p=>p.pId==5&&p.descr==desc);
                Assert.IsTrue(promocao.Count() == 0);

                int row = cmd.ActualizarPromocaoTemporal(id, "2000-10-10 10:00:00", "3000-10-10 10:00:00", desc, "1:00:00");
                Assert.AreEqual(2, row);

                var promocao2 = cmd.GetContext().Promocao.Where(p => p.pId == 3 && p.descr == desc);
                Assert.IsTrue(promocao2.Count()==1);
            }
        }

        [TestMethod]
        public void Ef_ActualizarPromocaoDesconto_test()
        {
            String id = "4";
            String desc = "Promocao Temporal Ef Actualizada";
            using (EfCommand cmd = new EfCommand())
            {
                var promocao = cmd.GetContext().Promocao.Where(p => p.pId == 4 && p.descr == desc);
                Assert.IsTrue(promocao.Count() == 0);

                int row = cmd.ActualizarPromocaoDesconto(id, "2000-10-10 10:00:00", "3000-10-10 10:00:00", desc, "0,1");
                Assert.AreEqual(2, row);

                var promocao2 = cmd.GetContext().Promocao.Where(p => p.pId == 4 && p.descr == desc);
                Assert.IsTrue(promocao2.Count() == 1);
            }
        }
    }
}
