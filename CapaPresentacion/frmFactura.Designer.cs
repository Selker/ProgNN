namespace CapaPresentacion
{
    partial class frmFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFactura));
            this.spfacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSPrincipal = new CapaPresentacion.DSPrincipal();
            this.spfacturaTableAdapter = new CapaPresentacion.DSPrincipalTableAdapters.spfacturaTableAdapter();
            this.rvwFactura = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.spfacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // spfacturaBindingSource
            // 
            this.spfacturaBindingSource.DataMember = "spfactura";
            this.spfacturaBindingSource.DataSource = this.DSPrincipal;
            // 
            // DSPrincipal
            // 
            this.DSPrincipal.DataSetName = "DSPrincipal";
            this.DSPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spfacturaTableAdapter
            // 
            this.spfacturaTableAdapter.ClearBeforeFill = true;
            // 
            // rvwFactura
            // 
            this.rvwFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spfacturaBindingSource;
            this.rvwFactura.LocalReport.DataSources.Add(reportDataSource1);
            this.rvwFactura.LocalReport.ReportEmbeddedResource = "CapaPresentacion.rptFactura.rdlc";
            this.rvwFactura.Location = new System.Drawing.Point(0, 0);
            this.rvwFactura.Name = "rvwFactura";
            this.rvwFactura.Size = new System.Drawing.Size(615, 484);
            this.rvwFactura.TabIndex = 0;
            // 
            // frmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 484);
            this.Controls.Add(this.rvwFactura);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFactura";
            this.Text = "FACTURA";
            this.Load += new System.EventHandler(this.frmFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spfacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource spfacturaBindingSource;
        private DSPrincipal DSPrincipal;
        private DSPrincipalTableAdapters.spfacturaTableAdapter spfacturaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer rvwFactura;
    }
}