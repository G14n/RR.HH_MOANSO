using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_ENTIDA;
using CAPA_LOGICA;

namespace Interfaz_proyecto_MOANSO
{
    public partial class Registro_Trabajador : Form
    {
      
        public Registro_Trabajador()
        {
            InitializeComponent();
            listarTrabajador();
        }
        //agregar
        private void button2_Click(object sender, EventArgs e)
        {
            //insertar
            try
            {
                Trabajador tra = new Trabajador();
                tra.Nombre = txtnombre.Text.Trim();
                tra.ApellidoPa = txtapellido_pa.Text;
                tra.ApellidoMa = txtapellido_ma.Text;
                tra.FechaNa = DTP_FN.Value;
                tra.Direccion = txtdirec.Text;
                tra.Telefono1 = txttel1.Text;
                tra.Telefono2 = txttel2.Text;
                tra.Banco = txtbanco.Text;
                tra.N_Cuenta_B = txtnumero_cuenta.Text;
                tra.Estado = checkBox1.Checked;
                LogTrabajador.Instancia.InsertaTrabajador(tra);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            listarTrabajador();
            limpiar();

        }
        public void listarTrabajador()
        {
            

            VerTrabajador.DataSource= LogTrabajador.Instancia.ListarTrabajador();
        }
        //editar
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Trabajador tra = new Trabajador();
                tra.IDtrabajador = int.Parse(txtid.Text.Trim());
                tra.Nombre = txtnombre.Text.Trim();
                tra.ApellidoPa = txtapellido_pa.Text.Trim();
                tra.ApellidoMa = txtapellido_ma.Text.Trim();
                tra.FechaNa = DTP_FN.Value;
                tra.Direccion = txtdirec.Text.Trim();
                tra.Telefono1 = txttel1.Text.Trim();
                tra.Telefono2 = txttel2.Text.Trim();
                tra.Banco = txtbanco.Text.Trim();
                tra.N_Cuenta_B = txtnumero_cuenta.Text.Trim();
                tra.Estado = checkBox1.Checked;
                LogTrabajador.Instancia.EditaTrabajador(tra);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            listarTrabajador();
            limpiar();



        }

        private void VerTrabajador_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaActual = VerTrabajador.Rows[e.RowIndex];
            txtid.Text = filaActual.Cells[0].Value.ToString();
            txtnombre.Text = filaActual.Cells[1].Value.ToString();
            txtapellido_pa.Text = filaActual.Cells[2].Value.ToString();
            txtapellido_ma.Text = filaActual.Cells[3].Value.ToString();
            DTP_FN.Text = filaActual.Cells[4].Value.ToString();
            txtdirec.Text = filaActual.Cells[5].Value.ToString();
            txttel1.Text = filaActual.Cells[6].Value.ToString();
            txttel2.Text = filaActual.Cells[7].Value.ToString();
            txtbanco.Text = filaActual.Cells[8].Value.ToString();
            txtnumero_cuenta.Text = filaActual.Cells[9].Value.ToString();
            checkBox1.Checked = Convert.ToBoolean(filaActual.Cells[10].Value);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Trabajador tra = new Trabajador();
                tra.IDtrabajador = int.Parse(txtid.Text.Trim());
                //checkBox1.Checked = false;
                //tra.Estado = checkBox1.Checked;
                LogTrabajador.Instancia.DeshabilitarTrabajador(tra);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            listarTrabajador();
            limpiar();
                
        }
        public void limpiar()
        {
            txtid.Text = "";
            txtnombre.Text = " ";
            txtapellido_pa.Text = "";
            txtapellido_ma.Text = "";
            txtbanco.Text = " ";
            txtdirec.Text = "";
            txtdni.Text = "";
            txtbanco.Text = " ";
            txtnumero_cuenta.Text = "";
            txttel1.Text= "";
            txttel2.Text= "";
            
            
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
