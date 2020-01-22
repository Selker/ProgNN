using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NVenta
    {
        //Métodos para comunicarnos con la capa datos
        //Método Insertar
        public static string Insertar(int idcliente, int idempleado, int idinventario, string fecha, decimal iva, decimal precio_venta)
        {
            DVenta Obj = new DVenta();
            Obj.Idcliente = idcliente;
            Obj.Idempleado = idempleado;
            Obj.Idinventario = idinventario;
            Obj.Fecha = fecha;
            Obj.IVA = iva;
            Obj.Precio_venta = precio_venta;

            return Obj.Insertar(Obj);
        }

        //Método Eliminar
        public static string Eliminar(int idventa)
        {
            DVenta Obj = new DVenta();
            Obj.Idventa = idventa;

            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        //Método Buscar

        public static DataTable Buscar(string textobuscar)
        {
            DVenta Obj = new DVenta();
            Obj.TextoBuscar = textobuscar;
            return Obj.Buscar(Obj);
        }
    }
}
