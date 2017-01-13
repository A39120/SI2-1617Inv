using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using App.ADO.NET;

namespace UnitTests
{
    [TestClass]
    public class AdoTests
    {
        [TestMethod]
        public void InserirAluguer_test()
        {
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand selectAluguer = cmd.GetConnection().CreateCommand();
                    String aluguerId = cmd.InserirAluguer("1", "1", "1", "2187-01-01 00:00:00", "01:00:00", "10,0", "");
                    //selectAluguer.Parameters.Add("@serial", SqlDbType.VarChar, 36).Value = aluguerId;
                    selectAluguer.CommandText = "SELECT * FROM AluguerView WHERE id='"+aluguerId+"'";
                    
                    SqlDataReader readerAluguer = selectAluguer.ExecuteReader();
                    Assert.IsTrue(readerAluguer.HasRows);

                    readerAluguer.Dispose();
                    tran.Complete();
                }
            }
        }

        [TestMethod]
        public void InserirAluguerComNovoCliente_test()
        {
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand selectCliente1 = cmd.GetConnection().CreateCommand();
                    SqlCommand selectCliente2 = cmd.GetConnection().CreateCommand();
                    SqlCommand selectAluguer = cmd.GetConnection().CreateCommand();
                    selectCliente2.CommandText = selectCliente1.CommandText = "SELECT * FROM Cliente WHERE nif = 123132321";
                    
                    //Select Cliente
                    SqlDataReader readerCliente1 = selectCliente1.ExecuteReader();
                    Assert.IsFalse(readerCliente1.HasRows);
                    readerCliente1.Dispose();

                    String aluguerId = cmd.InserirAluguerComNovoCliente("123132321", "Antonio Costa", "Belem", "1", "1", "2187-01-01 00:00:00", "01:00:00", "10,0", "");

                    //Select Cliente
                    SqlDataReader readerCliente2 = selectCliente1.ExecuteReader();
                    Assert.IsTrue(readerCliente2.HasRows);
                    readerCliente2.Dispose();

                    //Select Aluguer
                    selectAluguer.CommandText = "SELECT * FROM AluguerView WHERE id = '"+aluguerId+"'";
                    SqlDataReader readerAluguer = selectAluguer.ExecuteReader();
                    Assert.IsTrue(readerAluguer.HasRows);
                    readerAluguer.Dispose();

                    tran.Complete();
                }
            }
        }

        [TestMethod]
        public void RemoverAluguer_test()
        {
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand select1 = cmd.GetConnection().CreateCommand();
                    SqlCommand select2 = cmd.GetConnection().CreateCommand();
                    select1.CommandText = "SELECT * FROM AluguerView ";
                    select2.CommandText = "SELECT * FROM AluguerView WHERE id = @id ";
                    
                    //TODO: Tirar o primeiro id que aparecer
                    SqlDataReader reader1 = select1.ExecuteReader();
                    Assert.IsTrue(reader1.HasRows);
                    reader1.Read();
                    String id = reader1.GetString(0);
                    reader1.Dispose();

                    int row = cmd.RemoverAluguer(id);

                    //verificar se o aluguer ainda está disponivel

                    SqlParameter idParam = new SqlParameter("@id", SqlDbType.VarChar, 36);
                    idParam.Value = id;
                    select2.Parameters.Add(idParam);
                    SqlDataReader reader2 = select2.ExecuteReader();
                    Assert.IsFalse(reader2.HasRows);
                    reader2.Dispose();
                    tran.Complete();
                }
            }
        }

        [TestMethod]
        public void InserirPreco_test() 
        {
            String tipo = "Baldes", valor = "20,0", duracao = "2:00:00", validade = "3000-10-10 10:00:00";
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand preco1 = cmd.GetConnection().CreateCommand();
                    preco1.CommandText = "SELECT * FROM Preco WHERE tipo = '"+tipo+"' AND valor = "+20;

                    //SqlParameter tipoParam = new SqlParameter("@tipo", SqlDbType.VarChar, 32);
                    //SqlParameter valorParam = new SqlParameter("@valor",SqlDbType.Float);
                    //SqlParameter duracaoParam = new SqlParameter("@duracao",SqlDbType.Time);
                    //SqlParameter validadeParam = new SqlParameter("@validade",SqlDbType.DateTime);
                    //
                    //tipoParam.Value = tipo;
                    //valorParam.Value = valor;
                    //duracaoParam.Value = duracao;
                    //validadeParam.Value = validade;
                    //
                    //preco1.Parameters.Add(tipoParam);
                    //preco1.Parameters.Add(valorParam);
                    //preco1.Parameters.Add(duracaoParam);
                    //preco1.Parameters.Add(validadeParam);
                    SqlCommand preco2 = preco1.Clone();
                    
                    SqlDataReader reader1 = preco1.ExecuteReader();
                    Assert.IsFalse(reader1.HasRows);
                    reader1.Dispose();

                    int row = cmd.InserirPreco(tipo, valor, duracao, validade);
                    Assert.AreEqual(1, row);

                    SqlDataReader reader2 = preco2.ExecuteReader();
                    Assert.IsTrue(reader2.HasRows);
                    reader2.Dispose();
                    tran.Complete();
                }
            }
        }

        [TestMethod]
        public void ActualizarPreco_test()
        {
            String nome = "Baldes", preco = "5,00", duracao = "00:45:00", validade = "3000-10-10 10:00:00";
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    
                    SqlCommand preco1 = cmd.GetConnection().CreateCommand();
                    preco1.CommandText = "SELECT * FROM Preco WHERE tipo = @tipo AND valor = @valor AND duracao = @duracao ";

                    SqlParameter tipoParam = new SqlParameter("@tipo", SqlDbType.VarChar, 32);
                    SqlParameter valorParam = new SqlParameter("@valor", SqlDbType.Float);
                    SqlParameter duracaoParam = new SqlParameter("@duracao", SqlDbType.Time);

                    tipoParam.Value = nome;
                    valorParam.Value = preco;
                    duracaoParam.Value = duracao;

                    preco1.Parameters.Add(tipoParam);
                    preco1.Parameters.Add(valorParam);
                    preco1.Parameters.Add(duracaoParam);

                    SqlCommand preco2 = preco1.Clone();

                    SqlDataReader reader1 = preco1.ExecuteReader();
                    Assert.IsTrue(reader1.HasRows);
                    reader1.Dispose();
                    

                    int row = cmd.ActualizarPreco(nome, preco, duracao, validade, "5,00", "00:30:00", "3000-10-10 10:00:00");
                    Assert.AreEqual(2, row);

                    SqlDataReader reader2 = preco2.ExecuteReader();
                    Assert.IsFalse(reader2.HasRows);
                    reader2.Dispose();
                    
                    tran.Complete();
                }
            }
        }

        [TestMethod]
        public void RemoverPreco_test() 
        {
            String nome = "Baldes", preco = "7,00", duracao = "00:50:00", validade = "3000-10-10 10:00:00";
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand preco1 = cmd.GetConnection().CreateCommand();
                    preco1.CommandText = "SELECT * FROM Preco WHERE tipo = @tipo AND valor = @valor AND duracao = @duracao ";

                    SqlParameter tipoParam = new SqlParameter("@tipo", SqlDbType.VarChar, 32);
                    SqlParameter valorParam = new SqlParameter("@valor", SqlDbType.Float);
                    SqlParameter duracaoParam = new SqlParameter("@duracao", SqlDbType.Time);

                    tipoParam.Value = nome;
                    valorParam.Value = preco;
                    duracaoParam.Value = duracao;

                    preco1.Parameters.Add(tipoParam);
                    preco1.Parameters.Add(valorParam);
                    preco1.Parameters.Add(duracaoParam);
                    SqlCommand preco2 = preco1.Clone();
                    
                    SqlDataReader reader1 = preco1.ExecuteReader();
                    Assert.IsTrue(reader1.HasRows);
                    reader1.Dispose();

                    int row = cmd.RemoverPreco(nome, preco, duracao, validade);
                    Assert.AreEqual(1, row);

                    SqlDataReader reader2 = preco2.ExecuteReader();
                    Assert.IsFalse(reader2.HasRows);
                    reader2.Dispose();
                    tran.Complete();
                }
            }
        }

        [TestMethod]
        public void InserirPromocaoTemporal_test()
        {
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand promocao = cmd.GetConnection().CreateCommand();
                    promocao.CommandText = "SELECT * FROM PromocaoTemporal WHERE pId = @pId";

                    int pid = cmd.InserirPromocaoTemporal("2000-10-10 10:00:00", "3000-10-10 10:00:00", "Teste Promocao Temporal", "Baldes", "1:00:00");

                    //promocao.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int)).Value = pid;
                    promocao.CommandText = "SELECT * FROM Promocao WHERE pId = " + pid;
                    SqlDataReader reader = promocao.ExecuteReader();
                    Assert.IsTrue(reader.HasRows);

                    reader.Dispose();
                    tran.Complete();
                }
            }
        }

        [TestMethod]
        public void InserirPromocaoDesconto_test()
        {
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand promocao = cmd.GetConnection().CreateCommand();
                    

                    int pid = cmd.InserirPromocaoDesconto("2000-10-10 10:00:00", "3000-10-10 10:00:00", "Teste Promocao Temporal", "Baldes", "0,7");

                    //promocao.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int)).Value = pid;
                    promocao.CommandText = "SELECT * FROM PromocaoDesconto WHERE pId = " + pid;
                    SqlDataReader reader = promocao.ExecuteReader();
                    Assert.IsTrue(reader.HasRows);
                    reader.Dispose();
                    tran.Complete();
                }
            }
        }

        [TestMethod]
        public void RemoverPromocaoTemporal_test()
        {
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand promocao = cmd.GetConnection().CreateCommand();
                    promocao.CommandText = "SELECT * FROM PromocaoTemporal WHERE pId = 1";
                    SqlCommand promocao2 = promocao.Clone();


                    SqlDataReader reader = promocao.ExecuteReader();
                    Assert.IsTrue(reader.HasRows);
                    reader.Dispose();

                    int row = cmd.RemoverPromocaoTemporal("1");
                    Assert.AreEqual(3, row);

                    SqlDataReader reader2 = promocao2.ExecuteReader();
                    Assert.IsFalse(reader2.HasRows);

                    reader2.Dispose();
                    tran.Complete();
                }
            }
        }
        
        [TestMethod]
        public void RemoverPromocaoDesconto_test()
        {
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand promocao = cmd.GetConnection().CreateCommand();
                    promocao.CommandText = "SELECT * FROM PromocaoDesconto WHERE pId = 2";
                    SqlCommand promocao2 = promocao.Clone();

                    
                    SqlDataReader reader = promocao.ExecuteReader();
                    Assert.IsTrue(reader.HasRows);
                    reader.Dispose();
                    

                    int row = cmd.RemoverPromocaoDesconto("2");
                    Assert.AreEqual(3, row);

                    SqlDataReader reader2 = promocao2.ExecuteReader();
                    Assert.IsFalse(reader2.HasRows);
                    

                    reader2.Dispose();
                    tran.Complete();
                }
            }
        }
        
        [TestMethod]
        public void ActualizarPromocaoTemporal_test()
        {
            String id = "5";
            String desc = "Promocao Temporal Ado Actualizada";
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand promocao = cmd.GetConnection().CreateCommand();
                    promocao.CommandText = "SELECT * FROM Promocao WHERE pId =" + id + " AND descr='" + desc + "'";
                    SqlCommand promocao2 = promocao.Clone();
                    
                    SqlDataReader reader = promocao.ExecuteReader();
                    Assert.IsFalse(reader.HasRows);
                    reader.Dispose();

                    int row = cmd.ActualizarPromocaoTemporal(id, "2000-10-10 10:00:00", "3000-10-10 10:00:00", desc, "1:00:00");
                    Assert.AreEqual(2, row);

                    SqlDataReader reader2 = promocao2.ExecuteReader();
                    Assert.IsTrue(reader2.HasRows);

                    reader2.Dispose();
                    tran.Complete();
                }
            }
        }
        
        [TestMethod]
        public void ActualizarPromocaoDesconto_test()
        {
            String id = "4";
            String desc = "Promocao Desconto Ado Actualizada";
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand promocao = cmd.GetConnection().CreateCommand();
                    promocao.CommandText = "SELECT * FROM Promocao WHERE pId =" + id + " AND descr='" + desc + "'";
                    SqlCommand promocao2 = promocao.Clone();

                    
                    SqlDataReader reader = promocao.ExecuteReader();
                    Assert.IsFalse(reader.HasRows);
                    reader.Dispose();

                    int row = cmd.ActualizarPromocaoTemporal(id, "2000-10-10 10:00:00", "3000-10-10 10:00:00", desc, "1:00:00");
                    Assert.AreEqual(1, row);

                    SqlDataReader reader2 = promocao2.ExecuteReader();
                    Assert.IsTrue(reader2.HasRows);

                    reader2.Dispose();
                    tran.Complete();
                }
            }
        }
    }
}
