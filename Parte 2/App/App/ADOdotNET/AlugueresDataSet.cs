using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace App
{
    class AlugueresTable : DataTable
    {
        public AlugueresTable()
            : base("alugueresType")
        {
            this.Columns.Add("dataInicio", typeof(String));
            this.Columns.Add("dataFim", typeof(String));
            this.Columns.Add("id", typeof(String));

            Id.ColumnMapping = MappingType.Hidden;
            
            DataInicio.ColumnMapping = MappingType.Attribute;
            DataFim.ColumnMapping = MappingType.Attribute;
        }

        public DataColumn Id { get { return this.Columns["id"]; } }
        public DataColumn DataInicio { get { return this.Columns["dataInicio"]; } }
        public DataColumn DataFim { get { return this.Columns["dataFim"]; } }
    }

    class AluguerTable : DataTable 
    {
        public AluguerTable() : base("aluguerType")
        {
            this.Columns.Add("id", typeof(String));
            this.Columns.Add("equipamento", typeof(int));
            this.Columns.Add("tipo", typeof(String));
            this.Columns.Add("cliente", typeof(int));
            this.PrimaryKey = new DataColumn[]{this.Columns["id"]};

            Id.ColumnMapping = MappingType.Attribute;
            Tipo.ColumnMapping = MappingType.Attribute;
        }

        public DataColumn Id { get { return this.Columns["id"]; }}
        public DataColumn Equipamento { get { return this.Columns["equipamento"]; }}
        public DataColumn Tipo { get { return this.Columns["tipo"]; } }
        public DataColumn Cliente { get { return this.Columns["cliente"]; }}
    }

    
    class AlugueresDataSet : DataSet
    {
        AluguerTable aluguerTable;
        AlugueresTable alugueresTable;

        public AlugueresDataSet()
            : base("xmlType")
        {
            aluguerTable = new AluguerTable();
            alugueresTable = new AlugueresTable();
            this.Tables.Add(aluguerTable);
            this.Tables.Add(alugueresTable);

            this.ReadXmlSchema("AlugueresSchema.xsd");
        }
        public DataTable AlugueresTable { get { return this.alugueresTable; } }
        public DataTable AluguerTable { get { return this.aluguerTable; } }

    }

}
