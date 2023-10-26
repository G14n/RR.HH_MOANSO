using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
using CAPA_ENTIDA;
namespace CAPA_LOGICA
{
    public class LogTrabajador
    {
        #region sigleton
        //Patron Singleton
        // Variable estática para la instancia
        private static readonly LogTrabajador _instancia = new LogTrabajador();
        //privado para evitar la instanciación directa
        public static LogTrabajador Instancia
        {
            get
            {
                return LogTrabajador._instancia;
            }
        }
        #endregion singleton

        #region metodos
        ///listado

        public List<Trabajador> ListarTrabajador()
        {
            
            return Dat_Trabajador.Instancia.ListarTrabajador();
        }
        ///inserta
        public void InsertaTrabajador(Trabajador Tra)
        {
            Dat_Trabajador.Instancia.InsertarTrabajador(Tra);
        }
        //edita
        public void EditaTrabajador(Trabajador tra)
        {
            Dat_Trabajador.Instancia.EditarTrabajador(tra);
        }
        public void DeshabilitarTrabajador(Trabajador tra)
        {
            Dat_Trabajador.Instancia.DeshabilitarTrabajador(tra);
       
        }
        #endregion metodos

    }
}
