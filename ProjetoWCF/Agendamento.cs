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
    
    public partial class Agendamento
    {
        public int id { get; set; }
        public int idprestador { get; set; }
        public int idcliente { get; set; }
        public System.DateTime horario { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Prestador Prestador { get; set; }
    }
}