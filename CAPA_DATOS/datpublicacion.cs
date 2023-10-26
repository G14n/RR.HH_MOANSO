using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_ENTIDA;

namespace CAPA_DATOS
{
   public class datpublicacion
    {

        #region sigleton
        //Patron Singleton
        // Variable estática para la instancia
        private static readonly datpublicacion _instancia = new datpublicacion();
        //privado para evitar la instanciación directa
        public static datpublicacion Instancia
        {
            get
            {
                return datpublicacion._instancia;
            }
        }
        #endregion singleton
        #region metodos
        ////////////////////listado de Clientes
        public List<entpublicacion> ListarPublicacion()
        {
            SqlCommand cmd = null;
            List<entpublicacion> lista = new List<entpublicacion>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaPublicacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entpublicacion pu = new entpublicacion();
                    pu.ID_publicacion = Convert.ToInt32(dr["ID_publicacion"]);
                    pu.Titulo = dr["Titulo"].ToString();
                    pu.Descripcion = dr["Descripcion"].ToString();
                    pu.Requerimiento = dr["Requerimiento"].ToString();
                    pu.Estado = Convert.ToBoolean(dr["Estado"]);
                    lista.Add(pu);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;


        }
        public Boolean InsertarPublicacion(entpublicacion pu)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaPublicacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Titulo", pu.Titulo);
                cmd.Parameters.AddWithValue("@Descripcion", pu.Descripcion);
                cmd.Parameters.AddWithValue("@Requerimiento", pu.Requerimiento);
                cmd.Parameters.AddWithValue("@Estado", pu.Estado);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }
        //////////////////////////////////EditaCliente
        public Boolean EditarPublicacion(entpublicacion pu)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaPublicacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_publicacion", pu.ID_publicacion);
                cmd.Parameters.AddWithValue("@Titulo", pu.Titulo);
                cmd.Parameters.AddWithValue("@Descripcion", pu.Descripcion);
                cmd.Parameters.AddWithValue("@Requerimiento", pu.Requerimiento);
                cmd.Parameters.AddWithValue("@Estado", pu.Estado);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    edita = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return edita;
        }
        //deshabilitaCliente
        public Boolean DeshabilitarPublicacion(entpublicacion pu)
        {
            SqlCommand cmd = null;
            Boolean delete = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spDeshabilitaPublicacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_publicacion", pu.ID_publicacion);
                //cmd.Parameters.AddWithValue("@Estado", tra.Estado);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    delete = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return delete;
        }


        #endregion metodos

    }
}
