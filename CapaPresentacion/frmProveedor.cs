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
    public partial class frmProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static frmProveedor _instancia;

        public static frmProveedor GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmProveedor();
            }
            return _instancia;
        }

        public frmProveedor()
        {
            InitializeComponent();
            this.txtID.ReadOnly = true;
            this.ttMensaje.SetToolTip(this.txtRazon_Social, "Ingrese la Razon Social del Proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Proveedor");
            this.ttMensaje.SetToolTip(this.txtNumero_Documento, "Ingrese el número de Documento del Proveedor");
            this.ttMensaje.SetToolTip(this.txtCorreo, "Ingrese el Correo del Proveedor");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Ingrese el Telefono del Proveedor");
            this.ttMensaje.SetToolTip(this.cbxTipo_Documento, "Seleccione el Tipo de Documento del Proveedor");
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
            this.txtRazon_Social.Text = string.Empty;
            this.txtNumero_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtID.Text = string.Empty;
            this.cbxTipo_Documento.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtRazon_Social.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbxTipo_Documento.Enabled = valor;
            this.txtNumero_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;
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

        private void frmProveedor_Load(object sender, EventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string respuesta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            respuesta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

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
                    this.chkEliminar.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
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
            this.txtID.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDProveedor"].Value);
            this.txtRazon_Social.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Razon_Social"].Value);
            this.cbxTipo_Documento.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Tipo_Documento"].Value);
            this.txtNumero_Documento.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Numero_Documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Telefono"].Value);
            this.txtCorreo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Correo"].Value);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazon_Social.Focus();
            gbxListado.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.txtRazon_Social.Text == string.Empty || this.txtNumero_Documento.Text == string.Empty || this.cbxTipo_Documento.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos relevantes");
                    errorIcono.SetError(txtRazon_Social, "Ingrese la Razon Social");
                    errorIcono.SetError(txtNumero_Documento, "Ingrese el Numero de Documento");
                    errorIcono.SetError(cbxTipo_Documento, "Seleccione el Tipo de Documento");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        respuesta = NProveedor.Insertar(this.txtRazon_Social.Text.Trim().ToUpper(), this.cbxTipo_Documento.Text, txtNumero_Documento.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text);
                    }
                    else
                    {
                        respuesta = NProveedor.Editar(Convert.ToInt32(this.txtID.Text), this.txtRazon_Social.Text.Trim().ToUpper(), this.cbxTipo_Documento.Text, txtNumero_Documento.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text);
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
            this.Habilitar(false);
            this.Limpiar();
            gbxListado.Enabled = true;
        }

        private void frmProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }
    }
}
