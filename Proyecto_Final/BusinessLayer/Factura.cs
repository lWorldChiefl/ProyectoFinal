//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Factura
    {
        [Key]
        public int invoiceId { get; set; }
        public Nullable<System.DateTime> invoiceDate { get; set; }
        public Nullable<int> detailsId { get; set; }
        public Nullable<int> userId { get; set; }
    
        public virtual Detalle Detalle { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
