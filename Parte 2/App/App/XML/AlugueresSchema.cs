﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlRootAttribute("xml", Namespace="", IsNullable=false)]
public partial class xmlType {
    
    private alugueresType alugueresField;
    
    /// <remarks/>
    public alugueresType alugueres {
        get {
            return this.alugueresField;
        }
        set {
            this.alugueresField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class alugueresType {
    
    private aluguerType[] aluguerField;
    
    private string dataInicioField;
    
    private string dataFimField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("aluguer")]
    public aluguerType[] aluguer {
        get {
            return this.aluguerField;
        }
        set {
            this.aluguerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string dataInicio {
        get {
            return this.dataInicioField;
        }
        set {
            this.dataInicioField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string dataFim {
        get {
            return this.dataFimField;
        }
        set {
            this.dataFimField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class aluguerType {
    
    private string clienteField;
    
    private string equipamentoField;
    
    private string idField;
    
    private string tipoField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger")]
    public string cliente {
        get {
            return this.clienteField;
        }
        set {
            this.clienteField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger")]
    public string equipamento {
        get {
            return this.equipamentoField;
        }
        set {
            this.equipamentoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="positiveInteger")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tipo {
        get {
            return this.tipoField;
        }
        set {
            this.tipoField = value;
        }
    }
}
