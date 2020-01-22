using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVenta
    {
        //Variables
        private int _Idventa;
        private int _Idcliente;
        private int _Idempleado;
        private int _Idinventario; 
        private string _Fecha;
        private decimal _IVA;
        private decimal _Precio_venta;
        private string _TextoBuscar;

        //Propiedades Métodos Setter and Getter
        public int Idventa
        {
            get { return _Idventa; }
            set { _Idventa = value; }
        }

        public int Idcliente
        {
            get { return _Idcliente; }
            set { _Idcliente = value; }
        }

        public int Idempleado
        {
            get { return _Idempleado; }
            set { _Idempleado = value; }
        }

        public int Idinventario
        {
            get { return _Idinventario; }
            set { _Idinventario = value; }
        }
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }

        public decimal Precio_venta
        {
            get { return _Precio_venta; }
            set { _Precio_venta = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores 
        public DVenta()
        {

        }
        public DVenta(int idventa, int idcliente, int idempleado, int idinventario, string fecha, decimal iva, decimal precio_venta)
        {
            this.Idventa = idventa;
            this.Idcliente = idcliente;
            this.Idempleado = idempleado;
            this.Idinventario = idinventario;
            this.Fecha = fecha;
            this.IVA = iva;
            this.Precio_venta = precio_venta;
        }

        //Métodos
        //Disminuir Inventario
        public string DisminuirInventario(int idinventario)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdisminuir_inventario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdinventario = new SqlParameter();
                ParIdinventario.ParameterName = "@IDInventario";
                ParIdinventario.SqlDbType = SqlDbType.Int;
                ParIdinventario.Value = idinventario;
                SqlCmd.Parameters.Add(ParIdinventario);

                //Ejecutamos nuestro comando

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizó el stock";


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

        //Insertar
        public string Insertar(DVenta Venta)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@IDVenta";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@IDCliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Venta.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);

                SqlParameter ParIdempleado = new SqlParameter();
                ParIdempleado.ParameterName = "@IDEmpleado";
                ParIdempleado.SqlDbType = SqlDbType.Int;
                ParIdempleado.Value = Venta.Idempleado;
                SqlCmd.Parameters.Add(ParIdempleado);

                SqlParameter ParIdinventario = new SqlParameter();
                ParIdinventario.ParameterName = "@IDInventario";
                ParIdinventario.SqlDbType = SqlDbType.Int;
                ParIdinventario.Value = Venta.Idinventario;
                SqlCmd.Parameters.Add(ParIdinventario);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.VarChar;
                ParFecha.Size = 10;
                ParFecha.Value = Venta.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParIVA = new SqlParameter();
                ParIVA.ParameterName = "@IVA";
                ParIVA.SqlDbType = SqlDbType.Money;
                ParIVA.Value = Venta.IVA;
                SqlCmd.Parameters.Add(ParIVA);

                SqlParameter ParPrecio_venta = new SqlParameter();
                ParPrecio_venta.ParameterName = "@Precio_Venta";
                ParPrecio_venta.SqlDbType = SqlDbType.Money;
                ParPrecio_venta.Value = Venta.Precio_venta;
                SqlCmd.Parameters.Add(ParPrecio_venta);

                //Ejecutamos nuestro comando

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

                if (respuesta.Equals("OK"))
                {
                    //Actualizamos el stock
                    respuesta = DisminuirInventario(Idinventario);                   
                 }
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
        public string Eliminar(DVenta Venta)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@IDVenta";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "NO" : "Se Eliminó Correctamente el registro";


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
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_venta";
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
        public DataTable Buscar(DVenta Venta)
        {
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 25;
                ParTextoBuscar.Value = Venta.TextoBuscar;
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
    }
}
