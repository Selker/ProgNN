using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public string IDEmpleado = "";
        public string Nombre = "";
        public string Apellido = "";
        public string Cargo = "";

        public frmPrincipal()
        {
            InitializeComponent();
        }
        
        private void mnuSalir_Click(object sender, EventArgs e)
        {  

                Application.Exit();   
        }
        private void mnCerrarSeccion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere Cerrar Seccion?", "ADVERTENCIA!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                frmLogin frm = new frmLogin();

                frm.Show();
                this.Hide();
            }
        }

        private void mnuVentas_Click(object sender, EventArgs e)
        {
            frmVenta frm = frmVenta.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.Idempleado = Convert.ToInt32(IDEmpleado);
        }

        private void mnuClientes_Click(object sender, EventArgs e)
        {
            frmCliente frm = frmCliente.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleado frm = frmEmpleado.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuProveedores_Click(object sender, EventArgs e)
        {
            frmProveedor frm = frmProveedor.GetInstancia();
            frm.MdiParent = this;
            
            frm.Show();
        }

        private void mnuVehiculos_Click(object sender, EventArgs e)
        {
            frmVehiculo frm = frmVehiculo.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuInventario_Click(object sender, EventArgs e)
        {
            frmInventario frm = frmInventario.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuarios();
            lbUser.Text ="Usario Acutal: "+ Nombre;
            lbType.Text = "Tipo de Cargo: "+Cargo;
        }

        private void GestionUsuarios()
        {
            //Controlar accesos
            if(Cargo == "Gerente")
            {
                this.mnuClientes.Enabled = true;
                this.mnuVentas.Enabled = true;
                this.mnuEmpleados.Enabled = true;
                this.mnuVehiculos.Enabled = true;
                this.mnuProveedores.Enabled = true;
                this.mnuInventario.Enabled = true;
            }

            else if (Cargo == "Vendedor")
            {
                this.mnuClientes.Enabled = true;
                this.mnuVentas.Enabled = true;
                this.mnuEmpleados.Enabled = false;
                this.mnuVehiculos.Enabled = false;
                this.mnuProveedores.Enabled = false;
                this.mnuInventario.Enabled = false;
            }

            else if (Cargo == "Almacenador")
            {
                this.mnuClientes.Enabled = false;
                this.mnuVentas.Enabled = false;
                this.mnuEmpleados.Enabled = false;
                this.mnuVehiculos.Enabled = true;
                this.mnuProveedores.Enabled = true;
                this.mnuInventario.Enabled = true;
            }

            else
            {
                this.mnuClientes.Enabled = false;
                this.mnuVentas.Enabled = false;
                this.mnuEmpleados.Enabled = false;
                this.mnuVehiculos.Enabled = false;
                this.mnuProveedores.Enabled = false;
                this.mnuInventario.Enabled = false;         
            }
        }

        private void mnuLezort_Click(object sender, EventArgs e)
        {
            frmLezort frm = frmLezort.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tsslHora.Text = DateTime.Now.ToString();
        }

       
    }
}
