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
    
    public partial class PUESTOS
    {
        public int Id_puestos { get; set; }
        public string Ubicacion { get; set; }
        public string Posicion { get; set; }
        public string Empresa { get; set; }
        public string Horario { get; set; }
        public byte[] foto { get; set; }
        public string Descripcion { get; set; }
        public double Salario { get; set; }
        public System.DateTime Fecha_Publicacion { get; set; }
        public int Id_Categoria { get; set; }
    
        public virtual CATEGORIA CATEGORIA { get; set; }
    }
}
