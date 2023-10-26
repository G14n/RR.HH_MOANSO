using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDA
{
    public class Trabajador
    {

        public int IDtrabajador { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPa { get; set; }
        public String ApellidoMa { get; set; }
        public DateTime FechaNa { get; set; }
        public string Direccion { get; set; }
        public String Telefono1 { get; set; }
        public String Telefono2 { get; set; }
        public string Banco { get; set; }
        public String N_Cuenta_B { get; set; }
        public Boolean Estado { get; set; }
    }
}
