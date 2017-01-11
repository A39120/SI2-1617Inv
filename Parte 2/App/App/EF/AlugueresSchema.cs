using System.Xml.Serialization;

public partial class xmlType {
    public alugueresType alugueres {get; set;}
}

public partial class alugueresType {
    public aluguerType[] aluguer { get; set; }
    [XmlAttribute]
    public string dataInicio { get; set; }
    [XmlAttribute]
    public string dataFim { get; set; }
}

public partial class aluguerType {
    public string cliente { get; set; }
    public string equipamento { get; set; }
    [XmlAttribute]
    public string id { get; set; }
    [XmlAttribute]
    public string tipo { get; set; }
}
