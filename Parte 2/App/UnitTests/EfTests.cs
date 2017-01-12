using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;

namespace UnitTests
{
    [TestClass]
    public class EfTests
    {
        [TestMethod]
        public void InserirAluguer_test()
        {
            using (AdoCommand cmd = new AdoCommand())
            {
                String aluguerId  = cmd.InserirAluguer("1", "1", "1", "2187-01-01 00:00:00", "01:00:00", "10,0", "");
            }
        }

        [TestMethod]
        public void InserirAluguerComNovoCliente_test()
        {
            using(TransactionScope tran = new TransactionScope()){
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
                    selectAluguer.Parameters.Add("@serial", SqlDbType.VarChar, 36);
                    selectAluguer.CommandText = "SELECT * FROM AluguerView WHERE id = @serial";
                    SqlDataReader readerAluguer = selectAluguer.ExecuteReader();
                    Assert.IsTrue(readerAluguer.HasRows);
                    readerAluguer.Dispose();

                    tran.Dispose();
                }
            }
        }

        [TestMethod]
        public void RemoverAluguer() 
        {
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand select1 = cmd.GetConnection().CreateCommand();
                    SqlCommand select2 = cmd.GetConnection().CreateCommand();
                    select1.CommandText = "SELECT * FROM AluguerView";
                    select2.CommandText = "SELECT * FROM AluguerView WHERE id = @id ";

                    //TODO: Tirar o primeiro id que aparecer
                    SqlDataReader reader1 = select1.ExecuteReader();
                    Assert.IsTrue(reader1.HasRows);
                    String id = reader1.GetString(0);
                    int row = cmd.RemoverAluguer(id);

                    //verificar se o aluguer ainda está disponivel
                    SqlParameter idParam = new SqlParameter("@id", SqlDbType.VarChar, 36);
                    idParam.Value = id;
                    select2.Parameters.Add(idParam);
                    SqlDataReader reader2 = select1.ExecuteReader();
                    Assert.IsFalse(reader1.HasRows);

                    reader1.Dispose();
                    reader2.Dispose();
                }
            }
        }

        [TestMethod]
        public void InserirPreco() 
        {
            using (TransactionScope tran = new TransactionScope())
            {
                using (AdoCommand cmd = new AdoCommand())
                {
                    SqlCommand select1 = cmd.GetConnection().CreateCommand();
                    SqlCommand select2 = cmd.GetConnection().CreateCommand();
                    select1.CommandText = "SELECT * FROM AluguerView";
                    select2.CommandText = "SELECT * FROM AluguerView WHERE id = @id ";

                    //TODO: Tirar o primeiro id que aparecer
                    SqlDataReader reader1 = select1.ExecuteReader();
                    Assert.IsTrue(reader1.HasRows);
                    String id = reader1.GetString(0);
                    int row = cmd.RemoverAluguer(id);

                    //verificar se o aluguer ainda está disponivel
                    SqlParameter idParam = new SqlParameter("@id", SqlDbType.VarChar, 36);
                    idParam.Value = id;
                    select2.Parameters.Add(idParam);
                    SqlDataReader reader2 = select1.ExecuteReader();
                    Assert.IsFalse(reader1.HasRows);

                    reader1.Dispose();
                    reader2.Dispose();
                }
            }
        }

        [TestMethod]
        public void ActualizarPreco()
        {
            using (AdoCommand cmd = new AdoCommand())
            {

            }
        }

        [TestMethod]
        public void RemoverPreco() 
        {
            using (AdoCommand cmd = new AdoCommand())
            {

            }
        }

        [TestMethod]
        public void InserirPromocaoTemporal()
        {
            using (AdoCommand cmd = new AdoCommand())
            {

            }
        }

        [TestMethod]
        public void InserirPromocaoDesconto()
        {
            using (AdoCommand cmd = new AdoCommand())
            {

            }
        }

        [TestMethod]
        public void RemoverPromocaoTemporal()
        {
            using (AdoCommand cmd = new AdoCommand())
            {

            }
        }
        
        [TestMethod]
        public void RemoverPromocaoDesconto()
        {
            using (AdoCommand cmd = new AdoCommand())
            {

            }
        }
        
        [TestMethod]
        public void ActualizarPromocaoTemporal()
        {
            using (AdoCommand cmd = new AdoCommand())
            {

            }
        }
        
        [TestMethod]
        public void ActualizarPromocaoDesconto()
        {
            using (AdoCommand cmd = new AdoCommand())
            {

            }
        }
    }
}
