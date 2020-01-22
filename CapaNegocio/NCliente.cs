using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        //Métodos para comunicarnos con la capa datos
        //Método Insertar
        public static string Insertar(string nombre, string apellido, string sexo, string fecha_nacimiento, string tipo_documento, string numero_documento, string direccion, string telefono, string correo)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Numero_Documento = numero_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;

            return Obj.Insertar(Obj);
        }

        //Método Editar
        public static string Editar(int idcliente, string nombre, string apellido, string sexo, string fecha_nacimiento, string tipo_documento, string numero_documento, string direccion, string telefono, string correo)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Numero_Documento = numero_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;
            return Obj.Editar(Obj);
        }

        //Método Eliminar
        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //Método Buscar

        public static DataTable Buscar(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.Buscar(Obj);
        }
    }
}
