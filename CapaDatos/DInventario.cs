using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DInventario
    {
        //Variables
        private int _Idinventario;
        private int _Cantidad;
        private int _Idvehiculo;
        private string _TextoBuscar;

        //Propiedades Métodos Setter and Getter
        public int Idinventario
        {
            get { return _Idinventario; }
            set { _Idinventario = value; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        
        public int Idvehiculo
        {
            get { return _Idvehiculo; }
            set { _Idvehiculo = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores
        public DInventario()
        {

        }

        public DInventario(int idinventario, int cantidad,int idvehiculo, string textobuscar)
        {
            this.Idinventario = idinventario;
            this.Cantidad = cantidad;
            this.Idvehiculo = idvehiculo;
            this.TextoBuscar = textobuscar;
        }

        //Métodos
        //Insertar
        public string Insertar(DInventario Inventario)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_inventario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdinventario = new SqlParameter();
                ParIdinventario.ParameterName = "@IDInventario";
                ParIdinventario.SqlDbType = SqlDbType.Int;
                ParIdinventario.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdinventario);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Inventario.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParIdvehiculo = new SqlParameter();
                ParIdvehiculo.ParameterName = "@IDVehiculo";
                ParIdvehiculo.SqlDbType = SqlDbType.Int;
                ParIdvehiculo.Value = Inventario.Idvehiculo;
                SqlCmd.Parameters.Add(ParIdvehiculo);

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
        public string Editar(DInventario Inventario)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_inventario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdinventario = new SqlParameter();
                ParIdinventario.ParameterName = "@IDInventario";
                ParIdinventario.SqlDbType = SqlDbType.Int;
                ParIdinventario.Value = Inventario.Idinventario;
                SqlCmd.Parameters.Add(ParIdinventario);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Inventario.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

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
        public string Eliminar(DInventario Inventario)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_inventario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdinventario = new SqlParameter();
                ParIdinventario.ParameterName = "@IDInventario";
                ParIdinventario.SqlDbType = SqlDbType.Int;
                ParIdinventario.Value = Inventario.Idinventario;
                SqlCmd.Parameters.Add(ParIdinventario);

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
            DataTable DtResultado = new DataTable("Inventario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_inventario";
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
        public DataTable Buscar(DInventario Inventario)
        {
            DataTable DtResultado = new DataTable("Vehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_inventario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 25;
                ParTextoBuscar.Value = Inventario.TextoBuscar;
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
