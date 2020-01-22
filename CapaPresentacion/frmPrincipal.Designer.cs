namespace CapaPresentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuLezort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVehiculos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCerrarSeccion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.lbUser = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLezort,
            this.mnuVentas,
            this.mnuClientes,
            this.mnuEmpleados,
            this.mnuProveedores,
            this.mnuVehiculos,
            this.mnuInventario,
            this.mnCerrarSeccion,
            this.mnuSalir});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(735, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // mnuLezort
            // 
            this.mnuLezort.ForeColor = System.Drawing.Color.Lime;
            this.mnuLezort.Name = "mnuLezort";
            this.mnuLezort.Size = new System.Drawing.Size(70, 24);
            this.mnuLezort.Text = "&LEZORT";
            this.mnuLezort.Click += new System.EventHandler(this.mnuLezort_Click);
            // 
            // mnuVentas
            // 
            this.mnuVentas.ForeColor = System.Drawing.Color.White;
            this.mnuVentas.Name = "mnuVentas";
            this.mnuVentas.Size = new System.Drawing.Size(62, 24);
            this.mnuVentas.Text = "&Ventas";
            this.mnuVentas.Click += new System.EventHandler(this.mnuVentas_Click);
            // 
            // mnuClientes
            // 
            this.mnuClientes.ForeColor = System.Drawing.Color.White;
            this.mnuClientes.Name = "mnuClientes";
            this.mnuClientes.Size = new System.Drawing.Size(69, 24);
            this.mnuClientes.Text = "&Clientes";
            this.mnuClientes.Click += new System.EventHandler(this.mnuClientes_Click);
            // 
            // mnuEmpleados
            // 
            this.mnuEmpleados.ForeColor = System.Drawing.Color.White;
            this.mnuEmpleados.Name = "mnuEmpleados";
            this.mnuEmpleados.Size = new System.Drawing.Size(90, 24);
            this.mnuEmpleados.Text = "&Empleados";
            this.mnuEmpleados.Click += new System.EventHandler(this.mnuEmpleados_Click);
            // 
            // mnuProveedores
            // 
            this.mnuProveedores.ForeColor = System.Drawing.Color.White;
            this.mnuProveedores.Name = "mnuProveedores";
            this.mnuProveedores.Size = new System.Drawing.Size(100, 24);
            this.mnuProveedores.Text = "&Proveedores";
            this.mnuProveedores.Click += new System.EventHandler(this.mnuProveedores_Click);
            // 
            // mnuVehiculos
            // 
            this.mnuVehiculos.ForeColor = System.Drawing.Color.White;
            this.mnuVehiculos.Name = "mnuVehiculos";
            this.mnuVehiculos.Size = new System.Drawing.Size(80, 24);
            this.mnuVehiculos.Text = "&Vehiculos";
            this.mnuVehiculos.Click += new System.EventHandler(this.mnuVehiculos_Click);
            // 
            // mnuInventario
            // 
            this.mnuInventario.ForeColor = System.Drawing.Color.White;
            this.mnuInventario.Name = "mnuInventario";
            this.mnuInventario.Size = new System.Drawing.Size(78, 24);
            this.mnuInventario.Text = "&Inventario";
            this.mnuInventario.Click += new System.EventHandler(this.mnuInventario_Click);
            // 
            // mnCerrarSeccion
            // 
            this.mnCerrarSeccion.ForeColor = System.Drawing.Color.DarkRed;
            this.mnCerrarSeccion.Name = "mnCerrarSeccion";
            this.mnCerrarSeccion.Size = new System.Drawing.Size(110, 24);
            this.mnCerrarSeccion.Text = "&Cerrar Seccion";
            this.mnCerrarSeccion.Click += new System.EventHandler(this.mnCerrarSeccion_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.ForeColor = System.Drawing.Color.DarkRed;
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(47, 24);
            this.mnuSalir.Text = "&Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslHora
            // 
            this.tsslHora.Name = "tsslHora";
            this.tsslHora.Size = new System.Drawing.Size(0, 17);
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.BackColor = System.Drawing.SystemColors.Control;
            this.lbUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbUser.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbUser.Location = new System.Drawing.Point(706, 364);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(0, 16);
            this.lbUser.TabIndex = 4;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.BackColor = System.Drawing.SystemColors.Control;
            this.lbType.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbType.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbType.Location = new System.Drawing.Point(706, 408);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(0, 16);
            this.lbType.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 783);
            this.panel1.TabIndex = 7;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.Logo;
            this.ClientSize = new System.Drawing.Size(735, 453);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LEZORT MOTORS - MENU PRINCIPAL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem mnuVentas;
        private System.Windows.Forms.ToolStripMenuItem mnuClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuEmpleados;
        private System.Windows.Forms.ToolStripMenuItem mnuProveedores;
        private System.Windows.Forms.ToolStripMenuItem mnuVehiculos;
        private System.Windows.Forms.ToolStripMenuItem mnuInventario;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuLezort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslHora;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ToolStripMenuItem mnCerrarSeccion;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Panel panel1;
    }
}



