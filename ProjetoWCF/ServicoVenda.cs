//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoWCF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServicoVenda
    {
        public int id { get; set; }
        public int idservico { get; set; }
        public int idvenda { get; set; }
    
        public virtual Servico Servico { get; set; }
        public virtual Venda Venda { get; set; }
    }
}