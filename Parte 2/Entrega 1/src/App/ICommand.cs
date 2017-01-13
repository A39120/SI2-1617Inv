using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    interface ICommand : IDisposable
    {
        String InserirAluguer(String empregado, String cliente, String equipamento, String inicio, String duracao, String preco, String prom);
        String InserirAluguerComNovoCliente(String nif, String nome, String morada, String empregado, String eq, String inicio, String duracao, String preco, String pid);
        object EquipamentosSemAlugueresNaUltimaSemana();
        object EquipamentosLivres(String inicio, String fim);
        int RemoverAluguer(String id);
        int InserirPreco(String tipo, String valor, String duracao, String validade);
        int ActualizarPreco(String tipo, String valor, String duracao, String validade, String novovalor, String novaduracao, String novavalidade);
        int RemoverPreco(String tipo, String valor, String duracao, String validade);
        int InserirPromocaoTemporal(String inicio, String fim, String desc, String tipo, String tempoExtra);
        int InserirPromocaoDesconto(String inicio, String fim, String desc, String tipo, String desconto);
        int RemoverPromocaoTemporal(String id);
        int RemoverPromocaoDesconto(String id);
        int ActualizarPromocaoTemporal(String id, String inicio, String fim, String desc, String tempoExtra);
        int ActualizarPromocaoDesconto(String id, String inicio, String fim, String desc, String desconto);
        string ExportarXml(String inicio, String fim);
    }
}
