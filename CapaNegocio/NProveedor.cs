using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NProveedor
    {
        //Métodos para comunicarnos con la capa datos
        //Método Insertar
        public static string Insertar(string razon_social, string tipo_documento, string numero_documento, string direccion, string telefono, string correo)
        {
            DProveedor Obj = new DProveedor();
            Obj.Razon_Social = razon_social;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Numero_Documento = numero_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;

            return Obj.Insertar(Obj);
        }

        //Método Editar
        public static string Editar(int idproveedor, string razon_social, string tipo_documento, string numero_documento, string direccion, string telefono, string correo)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.Razon_Social = razon_social;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Numero_Documento = numero_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;

            return Obj.Editar(Obj);
        }

        //Método Eliminar
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        //Método Buscar

        public static DataTable Buscar(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.Buscar(Obj);
        }
    }
}
