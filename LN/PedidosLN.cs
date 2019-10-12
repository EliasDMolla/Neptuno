using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AD;

namespace LN
{
    public class PedidosLN
    {
        public List<Pedidos> ListaPedidos;
        public List<Empleados> ListaEmpleados;
        public List<Clientes> ListaClientes;
        public List<Productos> ListaProductos;
        public Productos ProductoSeleccionado;
        public Pedidos NuevoPedido;
        public List<DetalleDePedidos> ListaDetallePedido;

        public PedidosLN()
        { 
             ListaPedidos = PedidosAD.BuscarTodos();
             ListaEmpleados = EmpleadosAD.BuscarTodos();
             ListaClientes = ClientesAD.BuscarTodos();
             ListaProductos = ProductosAD.BuscarTodos();
             ListaProductos = ProductosAD.BuscarTodos();
             //ListaDetallePedido = DetalleDePedidosAD.BuscarTodos();
             NuevoPedido = new Pedidos();
             NuevoPedido.ListaDetallePedidos = new List<DetalleDePedidos>();
        }
        public void AgregarProductos(int _idProducto,int _cantidad,int _descuento)
        {
            DetalleDePedidos NuevoDP = new DetalleDePedidos();

            NuevoDP.IdProducto = _idProducto;
            NuevoDP.PrecioUnidad = ProductoSeleccionado.PrecioUnidad;
            NuevoDP.Cantidad = _cantidad;
            NuevoDP.Descuento = _descuento;

            NuevoPedido.ListaDetallePedidos.Add(NuevoDP);
        }
        public void AgregarPedido(int idPedido, string idCliente, string idEmpleado, String fechaPedido) 
        {
            NuevoPedido.IdPedido = idPedido;
            NuevoPedido.IdCliente = idCliente;
            NuevoPedido.IdEmpleado = idEmpleado;
            NuevoPedido.FechaPedido = fechaPedido;
        }
        public void GuardarPedido() 
        {
            PedidosAD.AgregarPedidoBD(NuevoPedido);
        }
    }
}
