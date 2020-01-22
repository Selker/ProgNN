using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVistaVehiculo_Inventario : Form
    {
        public frmVistaVehiculo_Inventario()
        {
            InitializeComponent();
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
            this.dgvListado.Columns[7].Visible = false;
            this.dgvListado.Columns[10].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dgvListado.DataSource = NVehiculo.Mostrar();
            this.OcultarColumnas();
        }

        //Método Buscar Modelo
        private void BuscarModelo()
        {
            this.dgvListado.DataSource = NVehiculo.BuscarModelo(this.txtBusqueda.Text);
            this.OcultarColumnas();
        }

        //Método Buscar Proveedor
        private void BuscarProveedor()
        {
            this.dgvListado.DataSource = NVehiculo.BuscarProveedor(this.txtBusqueda2.Text);
            this.OcultarColumnas();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.BuscarModelo();
        }

        private void frmVistaVehiculo_Inventario_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            frmInventario form = frmInventario.GetInstancia();
            string parametro1, parametro2, parametro3;
            parametro1 = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDVehiculo"].Value);
            parametro2 = Convert.ToString(this.dgvListado.CurrentRow.Cells["Modelo"].Value);
            parametro3 = Convert.ToString(this.dgvListado.CurrentRow.Cells["Precio"].Value);

            form.setVehiculo(parametro1, parametro2, parametro3);
            this.Hide();
        }

        private void txtBusqueda2_TextChanged(object sender, EventArgs e)
        {
            this.BuscarProveedor();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
