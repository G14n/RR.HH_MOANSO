using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_ENTIDA;
using CAPA_DATOS;
namespace CAPA_LOGICA
{
   public class logpublicacion
    {
        #region sigleton
        //Patron Singleton
        // Variable estática para la instancia
        private static readonly logpublicacion _instancia = new logpublicacion();
        //privado para evitar la instanciación directa
        public static logpublicacion Instancia
        {
            get
            {
                return logpublicacion._instancia;
            }
        }
        #endregion singleton

        #region metodos
        ///listado

        public List<entpublicacion> ListarPublicacion()
        {

            return datpublicacion.Instancia.ListarPublicacion();
        }
        ///inserta
        public void InsertaPublicacion(entpublicacion pu)
        {
            datpublicacion.Instancia.InsertarPublicacion(pu);
        }
        //edita
        public void EditaPublicacion(entpublicacion pu)
        {
            datpublicacion.Instancia.EditarPublicacion(pu);
        }
        public void DeshabilitarPublicacion(entpublicacion pu)
        {
            datpublicacion.Instancia.DeshabilitarPublicacion(pu);

        }
        #endregion metodos
    }
}
