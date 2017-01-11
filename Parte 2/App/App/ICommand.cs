using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    interface ICommand : IDisposable
    {
        public String InserirAluguer(String empregado, String cliente, String equipamento, String inicio, String duracao, String preco, String prom);
        public String InserirAluguerComNovoCliente(String nif, String nome, String morada, String empregado, String eq, String inicio, String duracao, String preco, String pid);
        public int RemoverAluguer(String id);

        //public IQueryable<EquipamentosLivres_Result> EquipamentosLivres(String inicio, String fim);
        //public IQueryable<EquipamentosSemAlugueresNaUltimaSemana_Result> EquipamentosSemAlugueresNaUltimaSemana();

        public int InserirPreco(String tipo, String valor, String duracao, String validade);
        public int ActualizarPreco(String tipo, String valor, String duracao, String validade, String novovalor, String novaduracao, String novavalidade);
        public int RemoverPreco(String tipo, String valor, String duracao, String validade);
        public int InserirPromocaoTemporal(String inicio, String fim, String desc, String tipo, String tempoExtra);
        public int InserirPromocaoDesconto(String inicio, String fim, String desc, String tipo, String desconto);
        public int RemoverPromocaoTemporal(String id);
        public int RemoverPromocaoDesconto(String id);
        public int ActualizarPromocaoTemporal(String id, String inicio, String fim, String desc, String tempoExtra);
        public int ActualizarPromocaoDesconto(String id, String inicio, String fim, String desc, String desconto);
        public void ExportarXml(String inicio, String fim);

    }
}
