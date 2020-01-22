using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = CapaNegocio.NEmpleado.Login(this.txtUsuario.Text, this.txtClave.Text);

            //Evaluar si existe el usuario
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("NO tiene acceso al Sistema porque el usuario o la clave no existe","Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                frmPrincipal frm = new frmPrincipal();
                frm.IDEmpleado = Datos.Rows[0][0].ToString();
                frm.Nombre = Datos.Rows[0][1].ToString();
                frm.Apellido = Datos.Rows[0][2].ToString();
                frm.Cargo = Datos.Rows[0][3].ToString();

                frm.Show();
                this.Hide();
            }
        }




   /*     public string recoverPassword(string userRequesting)
        {
            using (var connection = ConnectionToSql())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from Users where LoginName=@user or Email=@mail";
                    command.Parameters.AddWithValue("@user", userRequesting);
                    command.Parameters.AddWithValue("@mail", userRequesting);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        string userName = reader.GetString(3) + ", " + reader.GetString(4);
                        string userMail = reader.GetString(6);
                        string accountPassword = reader.GetString(2);
                        var mailService = new MailServices.SystemSupportMail();
                        mailService.sendMail(
                          subject: "SYSTEM: Password recovery request",
                          body: "Hi, " + userName + "\nYou Requested to Recover your password.\n" +
                          "your current password is: " + accountPassword +
                          "\nHowever, we ask that you change your password inmediately once you enter the system.",
                          recipientMail: new List<string> { userMail }
                          );
                        return "Hi, " + userName + "\nYou Requested to Recover your password.\n" +
                          "Please check your mail: " + userMail +
                          "\nHowever, we ask that you change your password inmediately once you enter the system.";
                    }
                    else
                        return "Sorry, you do not have an account with that mail or username";
                }
            }
        }


    */



        private void lbRecuperarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmRecuperacionContra cs = new fmRecuperacionContra();
                cs.Show();
                
        }
    }
}
