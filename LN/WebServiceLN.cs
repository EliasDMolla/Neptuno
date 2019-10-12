using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AD;
using System.Data;

namespace LN
{
    public class WebServiceLN
    {
        public static List<Pedidos> ListaPedidos()
        {
            return PedidosAD.BuscarTodos();
        }

        public static DataSet PedidosDT() 
        {
            return PedidosAD.BuscarTodosDS();
        }

    }
}
