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
    public partial class frmVehiculo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static frmVehiculo _Instancia;

        public static frmVehiculo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmVehiculo();
            }
            return _Instancia;
        }

        public void setProveedor(string idproveedor, string razon_social)
        {
            this.txtIDProveedor.Text = idproveedor;
            this.txtProveedor.Text = razon_social;
        }


        public frmVehiculo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtModelo, "Ingrese el Model del Vehiculo");
            this.ttMensaje.SetToolTip(this.txtMarca, "Ingrese la Marca del Vehiculo");
            this.ttMensaje.SetToolTip(this.cbxCategoria, "Seleccione la Categoria del Vehiculo");
            this.ttMensaje.SetToolTip(this.txtColor, "Ingrese el Color del Vehiculo");
            this.ttMensaje.SetToolTip(this.txtAno, "Ingrese el Año del Vehiculo");
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese la descripcion del Vehiculo");
            this.ttMensaje.SetToolTip(this.txtPrecio, "Ingrese el Precio del Vehiculo");
            this.ttMensaje.SetToolTip(this.pbxImagen, "Seleccione la Imagen del Vehiculo");
            this.txtID.ReadOnly = true;
            this.txtIDProveedor.ReadOnly = true;
            this.txtProveedor.ReadOnly = true;
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
            this.txtModelo.Text = string.Empty;
            this.txtMarca.Text = string.Empty;
            this.cbxCategoria.Text = string.Empty;
            this.txtAno.Text = string.Empty;
            this.txtColor.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtIDProveedor.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtModelo.ReadOnly = !valor;
            this.txtMarca.ReadOnly = !valor;
            this.txtAno.ReadOnly = !valor;
            this.txtColor.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.txtPrecio.ReadOnly = !valor;
            this.cbxCategoria.Enabled = valor;
            this.btnAgregarImagen.Enabled = valor;
            this.btnQuitarImagen.Enabled = valor;
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pbxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void frmVehiculo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            this.pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pbxImagen.Image = null;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.BuscarModelo();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtModelo.Focus();
            gbxListado.Enabled = false;
            this.pbxImagen.Image = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.txtModelo.Text == string.Empty || this.txtMarca.Text == string.Empty || this.cbxCategoria.Text == string.Empty || this.txtColor.Text == string.Empty || this.txtAno.Text == string.Empty || this.txtDescripcion.Text == string.Empty || this.txtPrecio.Text == string.Empty || this.txtProveedor.Text == string.Empty || this.txtIDProveedor.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos relevantes");
                    errorIcono.SetError(txtModelo, "Ingrese un Valor");
                    errorIcono.SetError(txtMarca, "Ingrese un Valor");
                    errorIcono.SetError(cbxCategoria, "Ingrese un Valor");
                    errorIcono.SetError(txtColor, "Ingrese un Valor");
                    errorIcono.SetError(txtAno, "Ingrese un Valor");
                    errorIcono.SetError(txtDescripcion, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio, "Ingrese un Valor");
                    errorIcono.SetError(txtProveedor, "Ingrese un Valor");
                    errorIcono.SetError(txtIDProveedor, "Ingrese un Valor");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pbxImagen.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();


                    if (this.IsNuevo)
                    {
                        respuesta = NVehiculo.Insertar(this.txtModelo.Text.Trim().ToUpper(), this.txtMarca.Text.Trim().ToUpper(), this.cbxCategoria.Text,txtColor.Text,txtAno.Text,txtDescripcion.Text,Convert.ToDecimal(txtPrecio.Text),imagen,Convert.ToInt32(this.txtIDProveedor.Text));

                    }
                    else
                    {
                        respuesta = NVehiculo.Editar(Convert.ToInt32(this.txtID.Text), this.txtModelo.Text.Trim().ToUpper(), this.txtMarca.Text.Trim().ToUpper(), this.cbxCategoria.Text, txtColor.Text, txtAno.Text, txtDescripcion.Text, Convert.ToDecimal(txtPrecio.Text), imagen, Convert.ToInt32(this.txtIDProveedor.Text));
                            
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
                    this.pbxImagen.Image = null; 
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
            this.pbxImagen.Image = null;
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
            this.txtID.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDVehiculo"].Value);
            this.txtModelo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Modelo"].Value);
            this.txtMarca.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Marca"].Value);
            this.cbxCategoria.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Categoria"].Value);
            this.txtColor.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Color"].Value);
            this.txtAno.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Ano"].Value);
            
            byte[] imagenBuffer = (byte[])this.dgvListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pbxImagen.Image = Image.FromStream(ms);
            this.pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtPrecio.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Precio"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Descripcion"].Value);
            this.txtIDProveedor.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IDProveedor"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Razon_Social"].Value);
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
                            respuesta = NVehiculo.Eliminar(Convert.ToInt32(ID));

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

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaProveedor form = new frmVistaProveedor();
            form.ShowDialog();
        }

        private void frmVehiculo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instancia = null;
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void txtAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void txtBusqueda2_TextChanged(object sender, EventArgs e)
        {
            this.BuscarProveedor();
        }
    }
}
