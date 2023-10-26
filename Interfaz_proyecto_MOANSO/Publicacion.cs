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
    public partial class Publicacion : Form
    {
        public Publicacion()
        {
            InitializeComponent();
            listarPublicacion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insertar
            try
            {
                entpublicacion pu = new entpublicacion();
                pu.Titulo = txttitulo.Text.Trim();
                pu.Descripcion = txtdescripcion.Text.Trim();
                pu.Requerimiento = txtrequeri.Text.Trim();         
                pu.Estado = checkBox1.Checked;
                logpublicacion.Instancia.InsertaPublicacion(pu);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            listarPublicacion();
            limpiar();

        }
        public void listarPublicacion()
        {


            dataGridView1.DataSource = logpublicacion.Instancia.ListarPublicacion();
        }
        //editar
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                entpublicacion pu = new entpublicacion();
                pu.ID_publicacion = int.Parse(txtid.Text.Trim());
                pu.Titulo = txttitulo.Text.Trim();
                pu.Descripcion = txtdescripcion.Text.Trim();
                pu.Requerimiento = txtrequeri.Text.Trim();
                pu.Estado = checkBox1.Checked;
                logpublicacion.Instancia.EditaPublicacion(pu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            listarPublicacion();
            limpiar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaActual = dataGridView1.Rows[e.RowIndex];
            txtid.Text = filaActual.Cells[0].Value.ToString();
            txttitulo.Text = filaActual.Cells[1].Value.ToString();
            txtdescripcion.Text = filaActual.Cells[2].Value.ToString();
            txtrequeri.Text = filaActual.Cells[3].Value.ToString();
            checkBox1.Checked = Convert.ToBoolean(filaActual.Cells[4].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                entpublicacion pu = new entpublicacion();
                pu.ID_publicacion = int.Parse(txtid.Text.Trim());
             
                logpublicacion.Instancia.DeshabilitarPublicacion(pu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            listarPublicacion();
        }
        public void limpiar()
        {
            txtid.Text = "";
            txtdescripcion.Text = " ";
            txttitulo.Text = "";
            txtrequeri.Text = "";
            checkBox1.Checked = false;
        }
    }
}
