//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppPP3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIO
    {
        public int Id_Usuario { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }
        public int Id_Roll { get; set; }
    
        public virtual ROLL ROLL { get; set; }
    }
}
