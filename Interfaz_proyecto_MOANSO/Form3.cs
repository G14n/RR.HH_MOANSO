using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_proyecto_MOANSO
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            personalizar();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //metodo para estableser propiedad visible a falso
        private void personalizar()
        {
            panelSubMenu_nomina.Visible = false;
            panelSubMenu_desempe.Visible = false;
            panelSubMenu_SelecEmpleados.Visible = false;
        }

        //metodo para ocultar submenu
        private void HideSubMenu()
        {
            if (panelSubMenu_SelecEmpleados.Visible == true) 
            {
                panelSubMenu_SelecEmpleados.Visible = false; 
            }
            if (panelSubMenu_nomina.Visible == true)
            {
                panelSubMenu_nomina.Visible = false;
            }
            if(panelSubMenu_desempe.Visible==true)
            {
                panelSubMenu_desempe.Visible = false;
            }
        }

        private void ShowSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                HideSubMenu();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }

        private void btn_seleccion_empleados_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubMenu_SelecEmpleados);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new Publicacion());
            HideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new Form5());
            HideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new Registro_Trabajador());
            HideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubMenu_nomina);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubMenu_desempe);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            HideSubMenu();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            HideSubMenu();

        }
        //metodo para abrir formularios hijos
        private Form formularioActivo=null;
        private void OpenChildFrom(Form childform)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            panelContenedor.Controls.Add(childform);
            childform.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new Ver_Trabajador());
            HideSubMenu();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState =FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}
