using System.Xml.Serialization;

public partial class Xml
{
    public Alugueres alugueres { get; set; }
}

public partial class Alugueres
{
    public Aluguer[] aluguer { get; set; }
    public string dataInicio { get; set; }
    public string dataFim { get; set; }
}

public partial class Aluguer
{
    public string cliente { get; set; }
    public string equipamento { get; set; }
    public string id { get; set; }
    public string tipo { get; set; }
}
