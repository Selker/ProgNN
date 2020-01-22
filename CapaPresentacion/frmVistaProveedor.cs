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
    public partial class frmVistaProveedor : Form
    {
        public frmVistaProveedor()
        {
            InitializeComponent();
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dgvListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
        }

        //Método Buscar
        private void Buscar()
        {
            this.dgvListado.DataSource = NProveedor.Buscar(this.txtBusqueda.Text);
            this.OcultarColumnas();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void frmVistaProveedor_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            frmVehiculo form = frmVehiculo.GetInstancia();
            string parametro1, parametro2;
            parametro1 = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDProveedor"].Value);
            parametro2 = Convert.ToString(this.dgvListado.CurrentRow.Cells["Razon_Social"].Value);

            form.setProveedor(parametro1,parametro2);
            this.Hide();
        }
    }
}
