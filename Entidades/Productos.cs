using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnidad { get; set; }

        public Productos(int idProducto, string nombreProducto, decimal precioUnidad) 
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            PrecioUnidad = precioUnidad;
        }

        public Productos(int idProducto, string nombreProducto)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
        }

        public Productos() { }
       
    }
}
