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

    public partial class Tipos_Usuarios : IEntity
    {
        public Tipos_Usuarios()
        {
            this.Usuarios = new HashSet<Usuario>();
        }
    
        public int userTypeId { get; set; }
        public string userTypeDescription { get; set; }
    
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
