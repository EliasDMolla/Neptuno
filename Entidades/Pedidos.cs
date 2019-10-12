using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Pedidos
    {   
        public int IdPedido {get; set;}
        public string IdCliente { get; set; }
        public String IdEmpleado {get; set;}
        public String FechaPedido { get; set; }
        public List<DetalleDePedidos> ListaDetallePedidos {get; set;}

        public decimal MontoTotal
        {
            get {
                decimal total = 0;
                foreach (var item in ListaDetallePedidos)
                {
                    total += (item.PrecioUnidad * item.Cantidad) - item.Descuento;
                }
                return total; 
            }
        }
        

        public Pedidos(int idPedido,string idCliente, int idEmpleado,String fechaPedido,List<DetalleDePedidos> listaDePedidos)
        {
            IdPedido = idPedido;
            IdCliente = idCliente;
            IdEmpleado = IdEmpleado;
            FechaPedido = fechaPedido;
            ListaDetallePedidos = listaDePedidos;
        }
        public Pedidos(){}
    }
}
