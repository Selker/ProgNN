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
    public partial class frmVenta : Form
    {
        private bool IsNuevo = false;
        public int Idempleado;

        private decimal Precio = 0;
        private decimal IVA = 0;
        private decimal PrecioTotal = 0;

        private static frmVenta _instancia;

        public static frmVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmVenta();
            }
            return _instancia;
        }

        public void setCliente(string idcliente, string nombre)
        {
            this.txtIDCliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }

        public void setVehiculo(int idinventario, int idvehiculo, string modelo, int cantidad, decimal precio)
        {
            this.txtIDInventario.Text = Convert.ToString(idinventario);
            this.txtIDVehiculo.Text = Convert.ToString(idvehiculo);
            this.txtVehiculo.Text = modelo;
            this.txtCantidad.Text = Convert.ToString(cantidad);
            this.txtPrecio.Text = Convert.ToString(precio);
        }

        public frmVenta()
        {
            InitializeComponent();
            this.txtID.ReadOnly = true;
            this.txtIDCliente.ReadOnly = true;
            this.txtCliente.ReadOnly = true;
            this.txtIDInventario.ReadOnly = true;
            this.txtIDVehiculo.ReadOnly = true;
            this.txtVehiculo.ReadOnly = true;
            this.txtCantidad.ReadOnly = true;
            this.txtPrecio.ReadOnly = true;
            this.txtIVA.ReadOnly = true;
            this.txtTotal.ReadOnly = true;
            this.dtpFecha_Venta.Enabled = false;
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtID.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtVehiculo.Text = string.Empty;
            this.txtIDVehiculo.Text = string.Empty;
            this.txtIDCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtIVA.Text = string.Empty;
            this.txtTotal.Text = string.Empty;
            this.txtIDInventario.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.btnBuscarCliente.Enabled = valor;
            this.btnBuscarVehiculo.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
            this.dgvListado.Columns[3].Visible = false;
            this.dgvListado.Columns[6].Visible = false;
            this.dgvListado.Columns[8].Visible = false;
            this.dgvListado.Columns[9].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dgvListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
        }

        //Método Buscar
        private void Buscar()
        {
            this.dgvListado.DataSource = NVenta.Buscar(this.dtpBusqueda.Text);
            this.OcultarColumnas();
        }

        private void frmVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Calculos()
        {
            if(txtPrecio.Text != "")
            {
                Precio = Convert.ToDecimal(txtPrecio.Text);
                IVA = ((Precio * 16) / 100);
                txtIVA.Text = Convert.ToString(IVA);
                PrecioTotal = Precio + IVA;
                txtTotal.Text = Convert.ToString(PrecioTotal);
            }

            else
            {
                MessageBox.Show("No se seleciono ningun Vehiculo","Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmVistaCliente vista = new frmVistaCliente();
            vista.ShowDialog();
        }

        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            frmVistaInventario_Venta vista = new frmVistaInventario_Venta();
            vista.ShowDialog();
            Calculos();
        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string ID;
                    string respuesta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            ID = Convert.ToString(row.Cells[1].Value);
                            respuesta = NVenta.Eliminar(Convert.ToInt32(ID));

                            if (respuesta.Equals("NO"))
                            {
                                this.MensajeError("NO Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeOk(respuesta);
                            }

                        }
                    }
                    this.Mostrar();
                    this.chbEliminar.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEliminar.Checked)
            {
                this.dgvListado.Columns[0].Visible = true;
            }
            else
            {
                this.dgvListado.Columns[0].Visible = false;
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtID.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDVenta"].Value);
            this.txtIDVehiculo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDVehiculo"].Value);
            this.txtVehiculo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Modelo"].Value);
            this.txtPrecio.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Precio"].Value);
            this.txtIDInventario.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDInventario"].Value);
            this.txtIDCliente.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDCliente"].Value);
            this.txtCliente.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Nombre"].Value);
            this.txtIVA.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IVA"].Value);
            this.txtTotal.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Precio_Venta"].Value);
            this.dtpFecha_Venta.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Fecha"].Value);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            gbxListado.Enabled = false;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            gbxListado.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.txtIDCliente.Text == string.Empty || this.txtCliente.Text == string.Empty || this.txtCantidad.Text == string.Empty || this.txtPrecio.Text == string.Empty || this.txtTotal.Text == string.Empty || this.txtIVA.Text == string.Empty || this.txtVehiculo.Text == string.Empty || this.txtIDVehiculo.Text == string.Empty || this.txtIDInventario.Text == string.Empty || this.dtpFecha_Venta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos relevantes");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio, "Ingrese un Valor");
                    errorIcono.SetError(txtVehiculo, "Ingrese un Valor");
                    errorIcono.SetError(txtIDVehiculo, "Ingrese un Valor");
                    errorIcono.SetError(txtIDInventario, "Ingrese un Valor");
                    errorIcono.SetError(txtIDCliente, "Ingrese un Valor");
                    errorIcono.SetError(txtCliente, "Ingrese un Valor");
                    errorIcono.SetError(txtTotal, "Ingrese un Valor");
                    errorIcono.SetError(txtIVA, "Ingrese un Valor");
                    errorIcono.SetError(dtpFecha_Venta, "Ingrese un Valor");
                }
                else
                {
                    if (Convert.ToInt32(txtCantidad.Text) == 0)
                    {
                        this.MensajeError("Inventario Agotado");
                    }
                    else
                    {
                        respuesta = NVenta.Insertar(Convert.ToInt32(this.txtIDCliente.Text), Idempleado, Convert.ToInt32(this.txtIDInventario.Text), this.dtpFecha_Venta.Text, Convert.ToDecimal(this.txtIVA.Text), Convert.ToDecimal(this.txtTotal.Text));

                        if (respuesta.Equals("OK"))
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeError(respuesta);
                        }
                    }
                    
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
                gbxListado.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            frmFactura frm = new frmFactura();
            frm.Idventa = Convert.ToInt32(this.dgvListado.CurrentRow.Cells["IDVenta"].Value);
            frm.ShowDialog();
        }
    }
}
