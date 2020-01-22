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
    public partial class frmInventario : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static frmInventario _Instancia;

        public static frmInventario GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmInventario();
            }
            return _Instancia;
        }

        public void setVehiculo(string idvehiculo, string modelo, string precio)
        {
            this.txtIDVehiculo.Text = idvehiculo;
            this.txtVehiculo.Text = modelo;
            this.txtPrecio.Text = precio;
        }

        public frmInventario()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese la cantidad del Vehiculo que hay en Inventario");
            this.txtID.ReadOnly = true;
            this.txtIDVehiculo.ReadOnly = true;
            this.txtVehiculo.ReadOnly = true;
            this.txtPrecio.ReadOnly = true;
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
            
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtCantidad.ReadOnly = !valor;
            this.btnBuscarVehiculo.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
            this.dgvListado.Columns[2].Visible = false;
            this.dgvListado.Columns[5].Visible = false;
            this.dgvListado.Columns[8].Visible = false;
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

        private void frmInventario_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtCantidad.Focus();
            gbxListado.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.txtCantidad.Text == string.Empty || this.txtPrecio.Text == string.Empty || this.txtVehiculo.Text == string.Empty || this.txtIDVehiculo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos relevantes");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio, "Ingrese un Valor");
                    errorIcono.SetError(txtVehiculo, "Ingrese un Valor");
                    errorIcono.SetError(txtIDVehiculo, "Ingrese un Valor");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        respuesta = NInventario.Insertar(Convert.ToInt32(this.txtCantidad.Text), Convert.ToInt32(this.txtIDVehiculo.Text));

                    }
                    else
                    {
                        respuesta = NInventario.Editar(Convert.ToInt32(this.txtID.Text), Convert.ToInt32(this.txtCantidad.Text));

                    }

                    if (respuesta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtID.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
            gbxListado.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            gbxListado.Enabled = true;
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
            this.txtID.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDInventario"].Value);
            this.txtIDVehiculo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDVehiculo"].Value);
            this.txtVehiculo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Modelo"].Value);
            this.txtPrecio.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Precio"].Value);
            this.txtCantidad.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Cantidad"].Value);
        }

        private void chbElimiar_CheckedChanged(object sender, EventArgs e)
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
                            respuesta = NInventario.Eliminar(Convert.ToInt32(ID));

                            if (respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(respuesta);
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

        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            frmVistaVehiculo_Inventario form = new frmVistaVehiculo_Inventario();
            form.ShowDialog();
        }

        private void frmInventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instancia = null;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }
    }
}
