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
    public partial class frmVistaCliente : Form
    {
        public frmVistaCliente()
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
            this.dgvListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
        }

        //Método Buscar
        private void Buscar()
        {
            this.dgvListado.DataSource = NCliente.Buscar(this.txtBusqueda.Text);
            this.OcultarColumnas();
        }

        private void frmVistaCliente_Load(object sender, EventArgs e)
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
            string parametro1, parametro2;
            parametro1 = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDCliente"].Value);
            parametro2 = Convert.ToString(this.dgvListado.CurrentRow.Cells["Nombre"].Value) + " " + Convert.ToString(this.dgvListado.CurrentRow.Cells["Apellido"].Value);

            form.setCliente(parametro1, parametro2);
            this.Hide();
        }
    }
}
