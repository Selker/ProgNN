using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVehiculo
    {
        //Variables
        private int _Idvehiculo;
        private string _Modelo;
        private string _Marca;
        private string _Categoria;
        private string _Color;
        private string _Ano;    
        private string _Descripcion;
        private decimal _Precio;
        private byte[] _Imagen;
        private int _Idproveedor;
        private string _TextoBuscar;

        //Propiedades Métodos Setter and Getter
        public int Idvehiculo
        {
            get { return _Idvehiculo; }
            set { _Idvehiculo = value; }
        }
        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }
        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
        public string Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }
        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        public string Ano
        {
            get { return _Ano; }
            set { _Ano = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
        public int Idproveedor
        {
            get { return _Idproveedor; }
            set { _Idproveedor = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores
        public DVehiculo()
        {

        }

        public DVehiculo(int idvehiculo, string modelo, string marca, string categoria, string color, string ano, string descripcion, decimal precio, byte[] imagen, int idproveedor, string textobuscar)
        {
            this.Idvehiculo = idvehiculo;
            this.Modelo = modelo;
            this.Marca = marca;
            this.Categoria = categoria;
            this.Color = color;
            this.Ano = ano;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Idproveedor = idproveedor;
            this.TextoBuscar = textobuscar;

        }

        //Métodos
        //Insertar
        public string Insertar(DVehiculo Vehiculo)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdvehiculo = new SqlParameter();
                ParIdvehiculo.ParameterName = "@IDVehiculo";
                ParIdvehiculo.SqlDbType = SqlDbType.Int;
                ParIdvehiculo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdvehiculo);

                SqlParameter ParModelo = new SqlParameter();
                ParModelo.ParameterName = "@Modelo";
                ParModelo.SqlDbType = SqlDbType.VarChar;
                ParModelo.Size = 25;
                ParModelo.Value = Vehiculo.Modelo;
                SqlCmd.Parameters.Add(ParModelo);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@Marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 25;
                ParMarca.Value = Vehiculo.Marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParCategoria = new SqlParameter();
                ParCategoria.ParameterName = "@Categoria";
                ParCategoria.SqlDbType = SqlDbType.VarChar;
                ParCategoria.Size = 25;
                ParCategoria.Value = Vehiculo.Categoria;
                SqlCmd.Parameters.Add(ParCategoria);

                SqlParameter ParColor = new SqlParameter();
                ParColor.ParameterName = "@Color";
                ParColor.SqlDbType = SqlDbType.VarChar;
                ParColor.Size = 25;
                ParColor.Value = Vehiculo.Color;
                SqlCmd.Parameters.Add(ParColor);

                SqlParameter ParAno = new SqlParameter();
                ParAno.ParameterName = "@Ano";
                ParAno.SqlDbType = SqlDbType.VarChar;
                ParAno.Size = 4;
                ParAno.Value = Vehiculo.Ano;
                SqlCmd.Parameters.Add(ParAno);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 200;
                ParDescripcion.Value = Vehiculo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@Precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = Vehiculo.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Vehiculo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Vehiculo.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);

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
        public string Editar(DVehiculo Vehiculo)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdvehiculo = new SqlParameter();
                ParIdvehiculo.ParameterName = "@IDVehiculo";
                ParIdvehiculo.SqlDbType = SqlDbType.Int;
                ParIdvehiculo.Value = Vehiculo.Idvehiculo;
                SqlCmd.Parameters.Add(ParIdvehiculo);

                SqlParameter ParModelo = new SqlParameter();
                ParModelo.ParameterName = "@Modelo";
                ParModelo.SqlDbType = SqlDbType.VarChar;
                ParModelo.Size = 25;
                ParModelo.Value = Vehiculo.Modelo;
                SqlCmd.Parameters.Add(ParModelo);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@Marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 25;
                ParMarca.Value = Vehiculo.Marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParCategoria = new SqlParameter();
                ParCategoria.ParameterName = "@Categoria";
                ParCategoria.SqlDbType = SqlDbType.VarChar;
                ParCategoria.Size = 25;
                ParCategoria.Value = Vehiculo.Categoria;
                SqlCmd.Parameters.Add(ParCategoria);

                SqlParameter ParColor = new SqlParameter();
                ParColor.ParameterName = "@Color";
                ParColor.SqlDbType = SqlDbType.VarChar;
                ParColor.Size = 25;
                ParColor.Value = Vehiculo.Color;
                SqlCmd.Parameters.Add(ParColor);

                SqlParameter ParAno = new SqlParameter();
                ParAno.ParameterName = "@Ano";
                ParAno.SqlDbType = SqlDbType.VarChar;
                ParAno.Size = 4;
                ParAno.Value = Vehiculo.Ano;
                SqlCmd.Parameters.Add(ParAno);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 200;
                ParDescripcion.Value = Vehiculo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@Precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = Vehiculo.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Vehiculo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Vehiculo.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);

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
        public string Eliminar(DVehiculo Vehiculo)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdvehiculo = new SqlParameter();
                ParIdvehiculo.ParameterName = "@IDVehiculo";
                ParIdvehiculo.SqlDbType = SqlDbType.Int;
                ParIdvehiculo.Value = Vehiculo.Idvehiculo;
                SqlCmd.Parameters.Add(ParIdvehiculo);

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
            DataTable DtResultado = new DataTable("Vehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_vehiculo";
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


        //Método Buscar Modelo
        public DataTable BuscarModelo(DVehiculo Vehiculo)
        {
            DataTable DtResultado = new DataTable("Vehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 25;
                ParTextoBuscar.Value = Vehiculo.TextoBuscar;
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

        //Método Buscar Proveedor
        public DataTable BuscarProveedor(DVehiculo Vehiculo)
        {
            DataTable DtResultado = new DataTable("Vehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_vehiculoproveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 25;
                ParTextoBuscar.Value = Vehiculo.TextoBuscar;
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
