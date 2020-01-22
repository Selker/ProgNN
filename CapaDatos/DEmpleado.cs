using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEmpleado
    {
        //Variables
        private int _Idempleado;
        private string _Nombre;
        private string _Apellido;
        private string _Sexo;
        private string _Fecha_Nacimiento;
        private string _Tipo_Documento;
        private string _Numero_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Correo;
        private string _Cargo;
        private string _Usuario;
        private string _Clave;
        private string _TextoBuscar;

        //Propiedades Métodos Setter and Getter

        public int Idempleado
        {
            get { return _Idempleado; }
            set { _Idempleado = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }

        public string Fecha_Nacimiento
        {
            get { return _Fecha_Nacimiento; }
            set { _Fecha_Nacimiento = value; }
        }

        public string Tipo_Documento
        {
            get { return _Tipo_Documento; }
            set { _Tipo_Documento = value; }
        }
        public string Numero_Documento
        {
            get { return _Numero_Documento; }
            set { _Numero_Documento = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }

        public string Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores
        public DEmpleado()
        {

        }
         public DEmpleado(int idempleado, string nombre, string apellido, string sexo, string fecha_nacimiento,string tipo_documento,string numero_documento,string direccion, string telefono, string correo, string cargo, string usuario, string clave, string textobuscar)
        {
            this.Idempleado = idempleado;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Tipo_Documento = tipo_documento;
            this.Numero_Documento = numero_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Cargo = cargo;
            this.Usuario = usuario;
            this.Clave = clave;
            this.TextoBuscar = textobuscar;
        }

        //Métodos
        //Método Insertar
        public string Insertar(DEmpleado Empelado)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdempleado = new SqlParameter();
                ParIdempleado.ParameterName = "@IDEmpleado";
                ParIdempleado.SqlDbType = SqlDbType.Int;
                ParIdempleado.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdempleado);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Empelado.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos= new SqlParameter();
                ParApellidos.ParameterName = "@Apellido";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = Empelado.Apellido;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@Sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Empelado.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@Fecha_Nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.VarChar;
                ParFecha_Nacimiento.Size = 10;
                ParFecha_Nacimiento.Value = Empelado.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@Tipo_Documento";
                ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_Documento.Size = 3;
                ParTipo_Documento.Value = Empelado.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipo_Documento);

                SqlParameter ParNumero_Documento = new SqlParameter();
                ParNumero_Documento.ParameterName = "@Numero_Documento";
                ParNumero_Documento.SqlDbType = SqlDbType.VarChar;
                ParNumero_Documento.Size = 10;
                ParNumero_Documento.Value = Empelado.Numero_Documento;
                SqlCmd.Parameters.Add(ParNumero_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 150;
                ParDireccion.Value = Empelado.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Empelado.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@Correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 50;
                ParCorreo.Value = Empelado.Correo;
                SqlCmd.Parameters.Add(ParCorreo);

                SqlParameter ParCargo = new SqlParameter();
                ParCargo.ParameterName = "@Cargo";
                ParCargo.SqlDbType = SqlDbType.VarChar;
                ParCargo.Size = 20;
                ParCargo.Value = Empelado.Cargo;
                SqlCmd.Parameters.Add(ParCargo);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empelado.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParClave = new SqlParameter();
                ParClave.ParameterName = "@Clave";
                ParClave.SqlDbType = SqlDbType.VarChar;
                ParClave.Size = 20;
                ParClave.Value = Empelado.Clave;
                SqlCmd.Parameters.Add(ParClave);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;

        }

        //Método Editar
        public string Editar(DEmpleado Empelado)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@IDEmpleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empelado.Idempleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Empelado.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@Apellido";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = Empelado.Apellido;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@Sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Empelado.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@Fecha_Nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.VarChar;
                ParFecha_Nacimiento.Size = 10;
                ParFecha_Nacimiento.Value = Empelado.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@Tipo_Documento";
                ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_Documento.Size = 3;
                ParTipo_Documento.Value = Empelado.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipo_Documento);

                SqlParameter ParNumero_Documento = new SqlParameter();
                ParNumero_Documento.ParameterName = "@Numero_Documento";
                ParNumero_Documento.SqlDbType = SqlDbType.VarChar;
                ParNumero_Documento.Size = 10;
                ParNumero_Documento.Value = Empelado.Numero_Documento;
                SqlCmd.Parameters.Add(ParNumero_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 150;
                ParDireccion.Value = Empelado.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Empelado.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@Correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 50;
                ParCorreo.Value = Empelado.Correo;
                SqlCmd.Parameters.Add(ParCorreo);

                SqlParameter ParCargo = new SqlParameter();
                ParCargo.ParameterName = "@Cargo";
                ParCargo.SqlDbType = SqlDbType.VarChar;
                ParCargo.Size = 20;
                ParCargo.Value = Empelado.Cargo;
                SqlCmd.Parameters.Add(ParCargo);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empelado.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParClave = new SqlParameter();
                ParClave.ParameterName = "@Clave";
                ParClave.SqlDbType = SqlDbType.VarChar;
                ParClave.Size = 20;
                ParClave.Value = Empelado.Clave;
                SqlCmd.Parameters.Add(ParClave);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }

        //Método Eliminar
        public string Eliminar(DEmpleado Empelado)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdempleado = new SqlParameter();
                ParIdempleado.ParameterName = "@IDEmpleado";
                ParIdempleado.SqlDbType = SqlDbType.Int;
                ParIdempleado.Value = Empelado.Idempleado;
                SqlCmd.Parameters.Add(ParIdempleado);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        //Método Buscar
        public DataTable Buscar(DEmpleado Empelado)
        {
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 10;
                ParTextoBuscar.Value = Empelado.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Método Login
        public DataTable Login(DEmpleado Empelado)
        {
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empelado.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParClave = new SqlParameter();
                ParClave.ParameterName = "@Clave";
                ParClave.SqlDbType = SqlDbType.VarChar;
                ParClave.Size = 20;
                ParClave.Value = Empelado.Clave;
                SqlCmd.Parameters.Add(ParClave);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
}
