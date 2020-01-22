using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmFactura : Form
    {
        private int _Idventa;

        public int Idventa
        {
            get { return _Idventa; }
            set { _Idventa = value; }
        }

        public frmFactura()
        {
            InitializeComponent();
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            try
            {
                spfacturaTableAdapter.Fill(this.DSPrincipal.spfactura, Idventa);

                rvwFactura.RefreshReport();
            }
            catch (Exception ex)
            {
                this.rvwFactura.RefreshReport();
            }

            
        }
    }
}
