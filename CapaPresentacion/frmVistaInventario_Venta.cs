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
    public partial class frmVistaInventario_Venta : Form
    {
        public frmVistaInventario_Venta()
        {
            InitializeComponent();
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
            this.dgvListado.Columns[2].Visible = false;
            this.dgvListado.Columns[5].Visible = false;
            this.dgvListado.Columns[8].Visible = false;
            this.dgvListado.Columns[9].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dgvListado.DataSource = NInventario.Mostrar();
            this.OcultarColumnas();
        }

        //Método Buscar
        private void Buscar()
        {
            this.dgvListado.DataSource = NInventario.Buscar(this.txtBusqueda.Text);
            this.OcultarColumnas();
        }

        private void frmVistaInventario_Venta_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            int parametro1, parametro2, parametro4;
            string parametro3;
            decimal parametro5;
            parametro1 = Convert.ToInt32(this.dgvListado.CurrentRow.Cells["IDInventario"].Value);
            parametro2 = Convert.ToInt32(this.dgvListado.CurrentRow.Cells["IDVehiculo"].Value);
            parametro3 = Convert.ToString(this.dgvListado.CurrentRow.Cells["Modelo"].Value);
            parametro4 = Convert.ToInt32(this.dgvListado.CurrentRow.Cells["Cantidad"].Value);
            parametro5 = Convert.ToDecimal(this.dgvListado.CurrentRow.Cells["Precio"].Value);

            form.setVehiculo(parametro1, parametro2, parametro3, parametro4, parametro5);
            this.Hide();
        }
    }
}
