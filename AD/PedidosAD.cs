using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AD
{
    public class PedidosAD
    {
        public static List<Pedidos> BuscarTodos()
        {
            List<Pedidos> lista = new List<Pedidos>();

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyBD"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select IdPedido,IdCliente,Empleados.Nombre + ' ' + Apellidos As 'Empleados',FechaPedido As 'Fecha de Pedido' from Pedidos inner join Empleados On Pedidos.IdEmpleado = Empleados.IdEmpleado Order by IdPedido desc", conexion);
            
            conexion.Open();
            
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Pedidos pPedidos = new Pedidos();
                pPedidos.IdPedido = reader.GetInt32(0);
                pPedidos.IdCliente  = reader.GetString(1);
                pPedidos.IdEmpleado = reader.GetString(2);
                pPedidos.FechaPedido = reader.GetString(3);
                pPedidos.ListaDetallePedidos = new List<DetalleDePedidos>();
                pPedidos.ListaDetallePedidos = DetalleDePedidosAD.BuscarDetallePorIdPedido(pPedidos.IdPedido);

                lista.Add(pPedidos);
            }
            conexion.Close();
            return lista;
        }

        public static DataSet BuscarTodosDS() 
        {
            DataSet ds = new DataSet();

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyBD"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select IdPedido,IdCliente,IdEmpleado,FechaPedido From Pedidos", conexion);

            conexion.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            
            sda.Fill(ds);

            conexion.Close();

            return ds;
        }

        public static void AgregarPedidoBD(Pedidos NuevoPedido) 
        {
            List<Pedidos> lista = new List<Pedidos>();

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyBD"].ConnectionString);
           
            conexion.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert Into Pedidos(IdCliente,IdEmpleado,FechaPedido)Values " +
                              "(@idCliente, @idEmpleado, @fechaPedido);select SCOPE_IDENTITY()";
            cmd.Connection = conexion;   

            cmd.Parameters.AddWithValue("@idCliente", NuevoPedido.IdCliente);
            cmd.Parameters.AddWithValue("@idEmpleado", NuevoPedido.IdEmpleado);
            cmd.Parameters.AddWithValue("@fechaPedido", NuevoPedido.FechaPedido);
            
            int idNuevoPedido = int.Parse(cmd.ExecuteScalar().ToString());

            foreach (DetalleDePedidos item in NuevoPedido.ListaDetallePedidos) 
            {
                DetalleDePedidosAD.RegistrarDetalleDePedido(item, idNuevoPedido,ref conexion);
            }

            conexion.Close();      
         }
            
    }

}
 

