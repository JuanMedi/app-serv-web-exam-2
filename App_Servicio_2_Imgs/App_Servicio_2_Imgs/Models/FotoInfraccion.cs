//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App_Servicio_2_Imgs.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FotoInfraccion
    {
        public int idFoto { get; set; }
        public string NombreFoto { get; set; }
        public int idInfraccion { get; set; }
    
        public virtual Infraccion Infraccion { get; set; }
    }
}
