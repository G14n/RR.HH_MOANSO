using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CAPA_ENTIDA;
namespace CAPA_DATOS
{
    public class Dat_Trabajador
    {
        #region sigleton
        //Patron Singleton
        // Variable estática para la instancia
        private static readonly Dat_Trabajador _instancia = new Dat_Trabajador();
        //privado para evitar la instanciación directa
        public static Dat_Trabajador Instancia
        {
            get
            {
                return Dat_Trabajador._instancia;
            }
        }
        #endregion singleton
        #region metodos
        ////////////////////listado de Clientes
        public List<Trabajador> ListarTrabajador()
        {
            SqlCommand cmd = null;
            List<Trabajador> lista = new List<Trabajador>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Trabajador Tra = new Trabajador();
                    Tra.IDtrabajador= Convert.ToInt32(dr["ID_Trabajador"]);
                    Tra.Nombre=dr["Nombre"].ToString();
                    Tra.ApellidoPa= dr["Apellido_Pa"].ToString();
                    Tra.ApellidoMa = dr["Apellido_Ma"].ToString();
                    Tra.FechaNa = Convert.ToDateTime(dr["Fecha_Nacimiento"]);
                    Tra.Direccion = dr["Direccion"].ToString();
                    Tra.Telefono1 = dr["Telefono1"].ToString();
                    Tra.Telefono2 = dr["Telefono2"].ToString();
                    Tra.Banco = dr["Banco"].ToString();
                    Tra.N_Cuenta_B = dr["Cuenta_Bancaria"].ToString();
                    Tra.Estado = Convert.ToBoolean(dr["Estado"]);
                    lista.Add(Tra);
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
        public Boolean InsertarTrabajador(Trabajador Tra)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Tra.Nombre);
                cmd.Parameters.AddWithValue("@Apellido_Pa", Tra.ApellidoPa);
                cmd.Parameters.AddWithValue("@Apellido_Ma", Tra.ApellidoMa);
                cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Tra.FechaNa);
                cmd.Parameters.AddWithValue("@Direccion", Tra.Direccion);
                cmd.Parameters.AddWithValue("@Telefono1", Tra.Telefono1);
                cmd.Parameters.AddWithValue("@Telefono2", Tra.Telefono2);
                cmd.Parameters.AddWithValue("@Banco", Tra.Banco);
                cmd.Parameters.AddWithValue("@Cuenta_Bancaria", Tra.N_Cuenta_B);
                cmd.Parameters.AddWithValue("@Estado", Tra.Estado);
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
        public Boolean EditarTrabajador(Trabajador Tra)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Trabajador", Tra.IDtrabajador);
                cmd.Parameters.AddWithValue("@Nombre", Tra.Nombre);
                cmd.Parameters.AddWithValue("@Apellido_Pa", Tra.ApellidoPa);
                cmd.Parameters.AddWithValue("@Apellido_Ma", Tra.ApellidoMa);
                cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Tra.FechaNa);
                cmd.Parameters.AddWithValue("@Direccion", Tra.Direccion);
                cmd.Parameters.AddWithValue("@Telefono1", Tra.Telefono1);
                cmd.Parameters.AddWithValue("@Telefono2", Tra.Telefono2);
                cmd.Parameters.AddWithValue("@Banco", Tra.Banco);
                cmd.Parameters.AddWithValue("@Cuenta_Bancaria", Tra.N_Cuenta_B);
                cmd.Parameters.AddWithValue("@Estado", Tra.Estado);
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
        public Boolean DeshabilitarTrabajador(Trabajador tra)
        {
            SqlCommand cmd = null;
            Boolean delete = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spDeshabilitaTrabajador", cn);   
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Trabajador", tra.IDtrabajador);
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