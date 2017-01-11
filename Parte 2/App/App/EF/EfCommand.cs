using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace App.EF
{
    public class EfCommand : IDisposable
    {
        AEnimaEntities ctx;
        public EfCommand()
        {
            ctx = new AEnimaEntities();
        }

        public String InserirAluguer(String empregado, String cliente, String equipamento, String inicio, String duracao, String preco, String prom) 
        {
            try
            {
                if (prom.Equals(""))
                {
                    ctx.InserirAluguer(
                        int.Parse(empregado),
                        int.Parse(cliente),
                        int.Parse(equipamento),
                        DateTime.Parse(inicio),
                        TimeSpan.Parse(duracao),
                        double.Parse(preco), null);
                }
                else
                {
                    ctx.InserirAluguer(
                            int.Parse(empregado),
                            int.Parse(cliente),
                            int.Parse(equipamento),
                            DateTime.Parse(inicio),
                            TimeSpan.Parse(duracao),
                            double.Parse(preco),
                            int.Parse(prom));
                }
                return "Aluguer inserido com sucesso.";
            }
            catch (Exception e)
            {
                return "Falha ao inserir aluguer: " + e.InnerException.Message;
            }
        }
        public String InserirAluguerComNovoCliente(String nif, String nome, String morada, String empregado, String eq, String inicio, String duracao, String preco, String pid)
        {
            try
            {
                if(pid.Equals("")){
                    ctx.InserirAluguerComNovoCliente(
                    int.Parse(nif),
                    nome,
                    morada,
                    int.Parse(empregado),
                    int.Parse(eq),
                    DateTime.Parse(inicio),
                    TimeSpan.Parse(duracao),
                    double.Parse(preco),
                    null);
                }
                else 
                {
                    ctx.InserirAluguerComNovoCliente(
                    int.Parse(nif),
                    nome,
                    morada,
                    int.Parse(empregado),
                    int.Parse(eq),
                    DateTime.Parse(inicio),
                    TimeSpan.Parse(duracao),
                    double.Parse(preco),
                    int.Parse(pid));
                }
                return "Aluguer com novo cliente inserido com sucesso.";
            }
            catch (Exception e)
            {
                return "Falha ao criar aluguer e cliente: " + e.InnerException.Message;
            }
        }
        public String RemoverAluguer(String id)
        {
            try
            {
                ctx.RemoverAluguer(id);
                return "Aluguer removido com sucesso.";
            }
            catch (Exception e)
            {
                return "Falha ao remover o aluguer: " + e.InnerException.Message;
            }
        }
        public IQueryable<EquipamentosLivres_Result> EquipamentosLivres(String inicio, String fim) 
        {
            return ctx.EquipamentosLivres(DateTime.Parse(inicio), DateTime.Parse(fim), null);
        }
        public IQueryable<EquipamentosSemAlugueresNaUltimaSemana_Result> EquipamentosSemAlugueresNaUltimaSemana(){
            return ctx.EquipamentosSemAlugueresNaUltimaSemana();
        }
        public String InserirPreco(String tipo, String valor, String duracao, String validade)
        {
            try 
            {
                ctx.InserirPreco(
                    tipo,
                    double.Parse(valor),
                    TimeSpan.Parse(duracao),
                    DateTime.Parse(validade));
                return "Preço inserido com sucesso.";
            }
            catch (Exception e)
            {
                return "Falha ao inserir o novo Preço: " + e.InnerException.Message;
            }
        }
        public String ActualizarPreco(String tipo, String valor, String duracao, String validade, String novovalor, String novaduracao, String novavalidade)
        {
            try
            {
                ctx.ActualizarPreco(tipo,
                    double.Parse(valor),
                    TimeSpan.Parse(duracao),
                    DateTime.Parse(validade),
                    double.Parse(novovalor),
                    TimeSpan.Parse(novaduracao),
                    DateTime.Parse(novavalidade));
                return "Preço actualizado com sucesso.";
            }
            catch (Exception e)
            {
                return "Falha ao actualizar Preço: " + e.InnerException.Message;
            }
        }
        public String RemoverPreco(String tipo, String valor, String duracao, String validade)
        {
            try
            {
                ctx.RemoverPreco(tipo,
                        double.Parse(valor),
                        TimeSpan.Parse(duracao),
                        DateTime.Parse(validade));
                return "Preço removido com sucesso.";
            }
            catch (Exception e)
            {
                return "Falha ao remover o preço: " + e.InnerException.Message;
            }
        }
        public String InserirPromocaoTemporal(String inicio, String fim, String desc, String tipo, String tempoExtra)
        {
            try
            {
                ctx.InserirPromocaoTemporal(DateTime.Parse(inicio),
                    DateTime.Parse(fim),
                    desc,
                    tipo,
                    TimeSpan.Parse(tempoExtra));
                return "Promoção temporal inserida com sucesso";
            }
            catch (Exception e)
            {
                return "Falha ao inserir promoção temporal: " + e.InnerException.Message;
            }

        }
        public String InserirPromocaoDesconto(String inicio, String fim, String desc, String tipo, String desconto)
        {
            try{
                ctx.InserirPromocaoDesconto(
                    DateTime.Parse(inicio),
                    DateTime.Parse(fim),
                    desc,
                    tipo,
                    double.Parse(desconto));
                return "Promoção Desconto inserida com sucesso.";
            }catch (Exception e) {
                return "Falha ao inserir promoção desconto: " + e.InnerException.Message;
            }
        }
        public String RemoverPromocaoTemporal(String id)
        {
            try
            {
                ctx.RemoverPromocaoTemporal(int.Parse(id));
                return "Promoção removida com sucesso.";
            }
            catch (Exception e)
            {
                return "Falha ao remover a promoção: " + e.InnerException.Message;
            }
        }
        public String RemoverPromocaoDesconto(String id)
        {
            try
            {
                ctx.RemoverPromocaoDesconto(int.Parse(id));
                return "Promoção removida com sucesso.";
            }
            catch (Exception e)
            {
                return "Falha ao remover a promoção: " + e.InnerException.Message;
            }
        }
        public String ActualizarPromocaoTemporal(String id, String inicio, String fim, String desc, String tempoExtra)
        {
            try
            {
                ctx.ActualizarPromocaoTemporal(int.Parse(id),
                        DateTime.Parse(inicio),
                        DateTime.Parse(fim),
                        desc,
                        TimeSpan.Parse(tempoExtra));
                return "Promoção actualizada com sucesso.";
            }
            catch (Exception e)
            {
                return "Falha ao actualizar promoção: " + e.InnerException.Message;
            }
        }
        public String ActualizarPromocaoDesconto(String id, String inicio, String fim, String desc, String desconto)
        {
            try
            {
                ctx.ActualizarPromocaoDesconto(int.Parse(id),
                        DateTime.Parse(inicio),
                        DateTime.Parse(fim),
                        desc,
                        double.Parse(desconto));
                return "Promoção actualizada com sucesso.";
            }
            catch (Exception e)
            {
                return "Falha ao actualizar promoção: " + e.InnerException.Message;
            }
        }
        public String ExportarXml(String inicio, String fim)
        {
            //try
            //{
                XmlSerializer serializer = new XmlSerializer(typeof(xmlType));
                xmlType xml = new xmlType();
                xml.alugueres = new alugueresType();
                xml.alugueres.dataInicio = inicio;
                xml.alugueres.dataFim = fim;

                DateTime fimDate = DateTime.Parse(fim);
                DateTime inicioDate = DateTime.Parse(inicio);

                var alugueres = ctx.AluguerView.Join(ctx.Equipamento,
                        al => al.equipamento,
                        eq => eq.eqId,
                        (al, eq) => new { al.dataInicio, al.dataFim, al.cliente, al.empregado, al.equipamento, al.id, eq.tipo }
                    ).Where(
                        (al) => (al.dataFim <= fimDate && al.dataInicio >= inicioDate)
                    ).ToArray();
                
                
                xml.alugueres.aluguer = new aluguerType[alugueres.Length];
                int count = 0;
                foreach (var al in alugueres)
                {
                    xml.alugueres.aluguer[count] = new aluguerType();
                    xml.alugueres.aluguer[count].cliente = al.cliente.ToString();
                    xml.alugueres.aluguer[count].equipamento = al.equipamento.ToString();
                    xml.alugueres.aluguer[count].id = al.id;
                    xml.alugueres.aluguer[count].tipo = al.tipo;

                    count++;
                }
                String path =  Environment.CurrentDirectory + "\\Alugueres" + inicio.Replace(":", "").Replace(" ", "") + "_" + fim.Replace(":", "").Replace(" ", "") + ".xml";
                using (FileStream file = File.Create(path))
                {
                    serializer.Serialize(file, xml);
                }
                return "Sucesso ao criar ficheiro em: ";
            //}
            //catch (Exception e)
            //{
            //    return "Falha ao escrever XML:" + e.InnerException.Message;
            //}
        }
        void IDisposable.Dispose()
        {
            if(ctx != null)
                ctx.Dispose();
        }


    }
}
