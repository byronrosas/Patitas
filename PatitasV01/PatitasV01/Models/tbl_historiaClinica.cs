//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatitasV01.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_historiaClinica
    {
        public int hic_codigo { get; set; }
        public double hic_peso { get; set; }
        public string hic_color { get; set; }
        public string hic_pelaje { get; set; }
        public double hic_temperatura { get; set; }
        public string hic_frecuencia_cardica { get; set; }
        public string hic_pulso { get; set; }
        public string hic_fecha_atencion { get; set; }
        public string hic_fecha_proxima_atencion { get; set; }
        public int chc_codigo { get; set; }
        public int ser_codigo { get; set; }
        public string hic_diagnostico { get; set; }
        public string hic_sintomas { get; set; }
        public string hic_tratamiento { get; set; }
    
        public virtual tbl_cabeceraHClinica tbl_cabeceraHClinica { get; set; }
        public virtual tbl_servicio tbl_servicio { get; set; }
    }
}
