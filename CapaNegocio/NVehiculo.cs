using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NVehiculo
    {
        //Métodos para comunicarnos con la capa datos
        //Método Insertar
        public static string Insertar(string modelo, string marca, string categoria, string color, string ano, string descripcion, decimal precio, byte[] imagen, int idproveedor)
        {
            DVehiculo Obj = new DVehiculo();
            Obj.Modelo = modelo;
            Obj.Marca = marca;
            Obj.Categoria = categoria;
            Obj.Color = color;
            Obj.Ano = ano;
            Obj.Descripcion = descripcion;
            Obj.Precio = precio;
            Obj.Imagen = imagen;
            Obj.Idproveedor = idproveedor;

            return Obj.Insertar(Obj);
        }

        //Método Editar
        public static string Editar(int idvehiculo,string modelo, string marca, string categoria, string color, string ano, string descripcion, decimal precio, byte[] imagen, int idproveedor)
        {
            DVehiculo Obj = new DVehiculo();
            Obj.Idvehiculo = idvehiculo;
            Obj.Modelo = modelo;
            Obj.Marca = marca;
            Obj.Categoria = categoria;
            Obj.Color = color;
            Obj.Ano = ano;
            Obj.Descripcion = descripcion;
            Obj.Precio = precio;
            Obj.Imagen = imagen;
            Obj.Idproveedor = idproveedor;

            return Obj.Editar(Obj);
        }

        //Método Eliminar
        public static string Eliminar(int idvehiculo)
        {
            DVehiculo Obj = new DVehiculo();
            Obj.Idvehiculo = idvehiculo;

            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DVehiculo().Mostrar();
        }

        //Método Buscar Modelo

        public static DataTable BuscarModelo(string textobuscar)
        {
            DVehiculo Obj = new DVehiculo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarModelo(Obj);
        }

        public static DataTable BuscarProveedor(string textobuscar)
        {
            DVehiculo Obj = new DVehiculo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProveedor(Obj);
        }
    }
}
