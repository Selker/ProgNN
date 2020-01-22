using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NInventario
    {
        //Método Insertar
        public static string Insertar(int cantidad, int idvehiculo)
        {
            DInventario Obj = new DInventario();
            Obj.Cantidad = cantidad;
            Obj.Idvehiculo = idvehiculo;
            
            return Obj.Insertar(Obj);
        }

        //Método Editar
        public static string Editar(int idinventario, int cantidad)
        {
            DInventario Obj = new DInventario();
            Obj.Idinventario = idinventario;
            Obj.Cantidad = cantidad;

            return Obj.Editar(Obj);
        }

        //Método Eliminar
        public static string Eliminar(int idinventario)
        {
            DInventario Obj = new DInventario();
            Obj.Idinventario = idinventario;

            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DInventario().Mostrar();
        }

        //Método Buscar

        public static DataTable Buscar(string textobuscar)
        {
            DInventario Obj = new DInventario();
            Obj.TextoBuscar = textobuscar;

            return Obj.Buscar(Obj);
        }
    }
}
