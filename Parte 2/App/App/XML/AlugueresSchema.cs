using System.Xml.Serialization;

public partial class xmlType {
    public alugueres alugueres {get; set;}
}

public partial class alugueres {
    public aluguer[] aluguer { get; set; }
    public string dataInicio { get; set; }
    public string dataFim { get; set; }
}

public partial class aluguer {
    public string cliente { get; set; }
    public string equipamento { get; set; }
    public string id { get; set; }
    public string tipo { get; set; }
}
