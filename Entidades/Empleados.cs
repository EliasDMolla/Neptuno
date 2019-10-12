using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Empleados
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
        public Empleados() { }

        public Empleados(string nombre,string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public Empleados(int idEmpleado, string nombreCompleto) 
        {
            IdEmpleado = idEmpleado;
            NombreCompleto = nombreCompleto;
        }

    }
}

