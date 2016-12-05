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

    public partial class Detalle : IEntity
    {
        public Detalle()
        {
            this.Facturas = new HashSet<Factura>();
        }
    
        public int detailsId { get; set; }
        public Nullable<int> productId { get; set; }
        public Nullable<int> detailsQuantity { get; set; }
        public Nullable<int> detailsPrice { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
