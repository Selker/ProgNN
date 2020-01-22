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
    public partial class frmLezort : Form
    {
        private static frmLezort _instancia;

        public static frmLezort GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmLezort();
            }
            return _instancia;
        }

        public frmLezort()
        {
            InitializeComponent();
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
        }

        private void frmLezort_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void frmLezort_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }
    }
}
