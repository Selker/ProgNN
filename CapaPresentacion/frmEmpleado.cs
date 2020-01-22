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
    public partial class frmEmpleado : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static frmEmpleado _instancia;

        public static frmEmpleado GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmEmpleado();
            }
            return _instancia;
        }

        public frmEmpleado()
        {
            InitializeComponent();
            this.txtID.ReadOnly = true;
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Empleado");
            this.ttMensaje.SetToolTip(this.txtApellido, "Ingrese el Apellido del Empleado");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Empleado");
            this.ttMensaje.SetToolTip(this.txtNumero_Documento, "Ingrese el número de Documento del Empleado");
            this.ttMensaje.SetToolTip(this.txtCorreo, "Ingrese el Correo del Empleado");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Ingrese el Telefono del Empleado");
            this.ttMensaje.SetToolTip(this.dtpFecha_Nacimiento, "Ingrese la Fecha de Nacimiento del Empleado");
            this.ttMensaje.SetToolTip(this.cbxTipo_Documento, "Seleccione el Tipo de Documento del Empleado");
            this.ttMensaje.SetToolTip(this.cbxSexo, "Seleccione el Sexo del Empleado");
            this.ttMensaje.SetToolTip(this.cbxCargo, "Seleccione el Cargo del Empleado");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese el Usuario del Empleado");
            this.ttMensaje.SetToolTip(this.txtClave, "Ingrese la Clave del Empleado");
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
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtNumero_Documento.Text = string.Empty;
            this.dtpFecha_Nacimiento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtID.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtClave.Text = string.Empty;
            this.cbxSexo.Text = string.Empty;
            this.cbxTipo_Documento.Text = string.Empty;
            this.cbxCargo.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.dtpFecha_Nacimiento.Enabled = valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbxSexo.Enabled = valor;
            this.cbxTipo_Documento.Enabled = valor;
            this.txtNumero_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;
            this.cbxCargo.Enabled = valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtClave.ReadOnly = !valor;
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
            this.dgvListado.DataSource = NEmpleado.Mostrar();
            this.OcultarColumnas();
        }

        //Método Buscar
        private void Buscar()
        {
            this.dgvListado.DataSource = NEmpleado.Buscar(this.txtBusqueda.Text);
            this.OcultarColumnas();
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
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
                            respuesta = NEmpleado.Eliminar(Convert.ToInt32(Codigo));

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
            this.txtID.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDEmpleado"].Value);
            this.txtNombre.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Apellido"].Value);
            this.cbxSexo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Sexo"].Value);
            this.dtpFecha_Nacimiento.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Fecha_Nacimiento"].Value);
            this.cbxTipo_Documento.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Tipo_Documento"].Value);
            this.txtNumero_Documento.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Numero_Documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Telefono"].Value);
            this.txtCorreo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Correo"].Value);
            this.cbxCargo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Cargo"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Usuario"].Value);
            this.txtClave.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Clave"].Value);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNumero_Documento.Focus();
            gbxListado.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || this.txtNumero_Documento.Text == string.Empty || this.cbxTipo_Documento.Text == string.Empty || this.cbxSexo.Text == string.Empty || this.dtpFecha_Nacimiento.Text == string.Empty || this.cbxCargo.Text == string.Empty || this.txtUsuario.Text == string.Empty || this.txtClave.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos relevantes");
                    errorIcono.SetError(txtNombre, "Ingrese el Nombre");
                    errorIcono.SetError(txtApellido, "Ingrese el Apellido");
                    errorIcono.SetError(txtNumero_Documento, "Ingrese el Numero de Documento");
                    errorIcono.SetError(cbxTipo_Documento, "Seleccione el Tipo de Documento");
                    errorIcono.SetError(cbxSexo, "Seleccione el Sexo");
                    errorIcono.SetError(dtpFecha_Nacimiento, "Ingrese la Fecha de Nacimiento");
                    errorIcono.SetError(cbxCargo, "Seleccione el Cargo");
                    errorIcono.SetError(txtUsuario, "Ingrese el Usuario");
                    errorIcono.SetError(txtClave, "Ingrese la Clave");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        respuesta = NEmpleado.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(), this.cbxSexo.Text, dtpFecha_Nacimiento.Text, cbxTipo_Documento.Text, txtNumero_Documento.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, cbxCargo.Text, txtUsuario.Text, txtClave.Text);
                    }
                    else
                    {
                        respuesta = NEmpleado.Editar(Convert.ToInt32(this.txtID.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(), this.cbxSexo.Text, dtpFecha_Nacimiento.Text, cbxTipo_Documento.Text, txtNumero_Documento.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, cbxCargo.Text, txtUsuario.Text, txtClave.Text);
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

        private void frmEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }
    }
}
