using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NEmpleado
    {
        //Métodos para comunicarnos con la capa datos
        //Método Insertar
        public static string Insertar(string nombre, string apellido, string sexo, string fecha_nacimiento, string tipo_documento, string numero_documento, string direccion, string telefono, string correo, string cargo, string usuario, string clave)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Numero_Documento = numero_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;
            Obj.Cargo = cargo;
            Obj.Usuario = usuario;
            Obj.Clave = clave;

            return Obj.Insertar(Obj);
        }

        //Método Editar
        public static string Editar(int idempleado, string nombre, string apellido, string sexo, string fecha_nacimiento, string tipo_documento, string numero_documento, string direccion, string telefono, string correo, string cargo, string usuario, string clave)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Idempleado = idempleado;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Numero_Documento = numero_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;
            Obj.Cargo = cargo;
            Obj.Usuario = usuario;
            Obj.Clave = clave;

            return Obj.Editar(Obj);
        }

        //Método Eliminar
        public static string Eliminar(int idempleado)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Idempleado = idempleado;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DEmpleado().Mostrar();
        }

        //Método Buscar
        public static DataTable Buscar(string textobuscar)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.TextoBuscar = textobuscar;
            return Obj.Buscar(Obj);
        }

        //Método Login
        public static DataTable Login(string usuario, string clave)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Usuario = usuario;
            Obj.Clave = clave;

            return Obj.Login(Obj);
        }
    }
}
