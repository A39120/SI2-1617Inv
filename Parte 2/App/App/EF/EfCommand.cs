using System;
using System.Data;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace App.EF
{
    public class EfCommand : IDisposable, ICommand
    {
        AEnimaEntities ctx;
        public EfCommand()
        {
            ctx = new AEnimaEntities();
        }

        public object EquipamentosSemAlugueresNaUltimaSemana()
        {
            return ctx.EquipamentosSemAlugueresNaUltimaSemana();
        }

        public object EquipamentosLivres(String inicio, String fim) {
            return ctx.EquipamentosLivres(DateTime.Parse(inicio), DateTime.Parse(fim), null);
        }

        public string InserirAluguer(string empregado, string cliente, string equipamento, string inicio, string duracao, string preco, string prom)
        {
            var novoID = new ObjectParameter("novoID", typeof(string));
            
            ctx.InserirAluguer(
                int.Parse(empregado),
                int.Parse(cliente),
                int.Parse(equipamento),
                DateTime.Parse(inicio),
                TimeSpan.Parse(duracao),
                double.Parse(preco),
                prom.Equals("") ? null as int? : int.Parse(prom),
                novoID); //out parameter novoID

            return novoID.Value as string;
        }

        public string InserirAluguerComNovoCliente(string nif, string nome, string morada, string empregado, string eq, string inicio, string duracao, string preco, string pid)
        {

            var novoID = new ObjectParameter("novoID", typeof(string));
            ctx.InserirAluguerComNovoCliente(
                int.Parse(nif),
                nome,
                morada,
                int.Parse(empregado),
                int.Parse(eq),
                DateTime.Parse(inicio),
                TimeSpan.Parse(duracao),
                double.Parse(preco),
                pid.Equals("") ? null as int? : int.Parse(pid),
                novoID);

            return novoID.Value as string;
        }

        public int RemoverAluguer(string id)
        {
            return ctx.RemoverAluguer(id);
        }

        public int InserirPreco(string tipo, string valor, string duracao, string validade)
        {
            int rows = ctx.InserirPreco(
                tipo,
                double.Parse(valor),
                TimeSpan.Parse(duracao),
                DateTime.Parse(validade));

            return rows;
        }

        public int ActualizarPreco(string tipo, string valor, string duracao, string validade, string novovalor, string novaduracao, string novavalidade)
        {
            int rows = ctx.ActualizarPreco(
                tipo,
                double.Parse(valor),
                TimeSpan.Parse(duracao),
                DateTime.Parse(validade),
                double.Parse(novovalor),
                TimeSpan.Parse(novaduracao),
                DateTime.Parse(novavalidade));

            return rows;
        }

        public int RemoverPreco(string tipo, string valor, string duracao, string validade)
        {
            int rows = ctx.RemoverPreco(
               tipo,
               double.Parse(valor),
               TimeSpan.Parse(duracao),
               DateTime.Parse(validade));

            return rows;
        }

        public int InserirPromocaoTemporal(string inicio, string fim, string desc, string tipo, string tempoExtra)
        {
            
            int rows = ctx.InserirPromocaoTemporal(DateTime.Parse(inicio),
                DateTime.Parse(fim),
                desc,
                tipo,
                TimeSpan.Parse(tempoExtra));

            return rows;
        }

        public int InserirPromocaoDesconto(string inicio, string fim, string desc, string tipo, string desconto)
        {
            int id = ctx.InserirPromocaoDesconto(
                    DateTime.Parse(inicio),
                    DateTime.Parse(fim),
                    desc,
                    tipo,
                    double.Parse(desconto));

            return id;
        }

        public int RemoverPromocaoTemporal(string id)
        {
            return ctx.RemoverPromocaoTemporal(int.Parse(id));
        }

        public int RemoverPromocaoDesconto(string id)
        {
            return ctx.RemoverPromocaoDesconto(int.Parse(id));
        }

        public int ActualizarPromocaoTemporal(string id, string inicio, string fim, string desc, string tempoExtra)
        {
            int rows = ctx.ActualizarPromocaoTemporal(
                int.Parse(id),
                DateTime.Parse(inicio),
                DateTime.Parse(fim),
                desc,
                TimeSpan.Parse(tempoExtra));

            return rows;
        }

        public int ActualizarPromocaoDesconto(string id, string inicio, string fim, string desc, string desconto)
        {
            return ctx.ActualizarPromocaoDesconto(
                int.Parse(id),
                DateTime.Parse(inicio),
                DateTime.Parse(fim),
                desc,
                double.Parse(desconto));
        }

        public string ExportarXml(string inicio, string fim)
        {
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
            String path = Environment.CurrentDirectory + "\\EFAlugueres" + inicio.Replace(":", "").Replace(" ", "") + "_" + fim.Replace(":", "").Replace(" ", "") + ".xml";
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, xml);
                return path;
            }

        }
        public AEnimaEntities GetContext()
        {
            return this.ctx;
        }

        public void Dispose()
        {
            if (ctx != null)
                ctx.Dispose();
        }
    }
}
