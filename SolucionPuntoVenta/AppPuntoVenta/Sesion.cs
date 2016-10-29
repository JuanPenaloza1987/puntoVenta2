using SRATAPV.Utilerias.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppPuntoVenta
{
    static class Sesion
    {
        public static string Empresa;
        public static string RFCEmpresa;
        public static string DireccionEmpresa;
        public static string Usuario;
        public static string NombreUsuario;
        public static string CodigoCorte;
        public static decimal CambioDolar;
        public static decimal Impuesto;
        public static List<clsPermisos> Permisos;
        public static List<Entidades.Promocion> Promociones { get; set; }

        public static bool TienePermiso(string nombreFRM)
        {
            bool tienePermiso = false;
            if(Permisos != null)
            {
                var consulta = from per in Permisos where per.ppe_keypan == nombreFRM select per;
                if(consulta.Count() > 0)
                {
                    tienePermiso = true;
                }
            }
            return tienePermiso;
        }
    }

    

}
