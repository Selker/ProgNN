using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.Net.Mail;



namespace CapaPresentacion
{
    public partial class fmRecuperacionContra : Form
    {
        public fmRecuperacionContra()
        {
            InitializeComponent();
        }

        private void btnRecuperarContrasena_Click(object sender, EventArgs e)
        {

            //           SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["BDProyectoPNN1"].ToString());        
            SqlConnection sc = new SqlConnection(CapaDatos.Conexion.Cn);//ConfigurationManager.ConnectionStrings[""].ToString());
            {

                /*      PROCEDURE [dbo].[spValidarCorreo]

                      @correo varchar(50)

                      AS

                     SELECT * FROM Usuarios WHERE @correo=Correo*/

                SqlCommand cmd = new SqlCommand("spValidarCorreo", sc);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Correo", txtCorreoElectronico.Text);
                try
                {
                    sc.Open();
                    SqlDataReader lector = cmd.ExecuteReader();
                    if (lector.Read())
                    {

                        GenerarNuevaContrasena(txtCorreoElectronico.Text);
                    }
                    else
                    {
                        MessageBox.Show("Correo no encontrado");

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }


        public void GenerarNuevaContrasena(string email)
        {
            Random rd = new Random(DateTime.Now.Millisecond);
            int nuevaContrasena = rd.Next(100000, 999999);
            SqlConnection sc = new SqlConnection(CapaDatos.Conexion.Cn);


            //PROCEDURE [dbo].[spNuevaContrasena]

            //  @correo varchar (50),
            //  @contrasena varchar(10)

            //     AS

            //    UPDATE Usuarios SET Contrasena=@contrasena

            //     FROM Usuarios 
            //     WHERE CorreoElectronico=@correo

            SqlCommand cmd = new SqlCommand("spNuevaContrasena", sc);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@correo", email);
            cmd.Parameters.AddWithValue("@Clave", nuevaContrasena);
            try
            {
                sc.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas != 0)
                {
                    EnviarCorreoContrasena(nuevaContrasena, email);
                }
            }
            catch
            {

            }
        }



        private void EnviarCorreoContrasena(int contrasenaNueva, string correo)
        {
            string contraseña = this.Contrasena;
            string mensaje = string.Empty;
            //Creando el correo electronico
            string destinatario = correo;
            string remitente = "WildTunesSoporte@gmail.com";
            string asunto = "Nueva contraseña Wild Tunes ♥";
            string cuerpoDelMesaje = "Hola! Usted a solicitado una Nueva contraseña " + " " + Convert.ToString(contrasenaNueva) +" esta Contraseña es provicionar por favor cambiela al sistema Muchas Gracias por usar nuestro Servicios :)";
            MailMessage ms = new MailMessage(remitente, destinatario, asunto, cuerpoDelMesaje);


            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("WildTunesSoporte@gmail.com", contraseña);

            try
            {
                Task.Run(() =>
                {

                    smtp.Send(ms);
                    ms.Dispose();
                    MessageBox.Show("Correo enviado, sirvase revisar su bandeja de entrada");
                }
                );

                MessageBox.Show("Esta tarea puede tardar unos segundos, por favor espere...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electronico: " + ex.Message);
            }
        }
        public string Contrasena
        {
            get
            {
                return "Admin.123";
            }
        }

        
    }
    
}
