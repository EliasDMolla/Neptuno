using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
   public class DetalleDePedidos
    {   
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }

        public DetalleDePedidos(int idPedido, int idProducto, decimal precioUnidad, int cantidad, int descuento)
        {
            IdPedido = idPedido;
            IdProducto = idProducto;
            PrecioUnidad = precioUnidad;
            Cantidad = cantidad;
            Descuento = descuento;
        }

        public DetalleDePedidos() { }
    }

       
}
