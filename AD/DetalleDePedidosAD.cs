using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Configuration;

namespace AD
{           
     public class DetalleDePedidosAD
     {
        internal static void RegistrarDetalleDePedido(DetalleDePedidos item, int idNuevoPedido,ref SqlConnection conexion)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.Parameters.AddWithValue("@idPedido",idNuevoPedido);
            command.Parameters.AddWithValue("@idProducto",item.IdProducto);
            command.Parameters.AddWithValue("@precioUnidad", item.PrecioUnidad);
            command.Parameters.AddWithValue("@cantidad", item.Cantidad);
            command.Parameters.AddWithValue("@descuento", item.Descuento);
    
            command.CommandText = "INSERT INTO detallesdepedidos(idpedido, idproducto, preciounidad, cantidad, descuento) VALUES " +
                "(@idPedido, @idProducto, @precioUnidad, @cantidad, @descuento)";

            command.ExecuteNonQuery();
        }

        internal static List<DetalleDePedidos> BuscarDetallePorIdPedido(int p)
        {
            List<DetalleDePedidos> lista = new List<DetalleDePedidos>();

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyBD"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select IdPedido,Idproducto,preciounidad,cantidad ,descuento from detallesdepedidos where idpedido=@idpedido", conexion);
            cmd.Parameters.AddWithValue("@idpedido", p);

            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DetalleDePedidos dPedidos = new DetalleDePedidos();
                dPedidos.IdPedido = p;
                dPedidos.IdProducto = reader.GetInt32(1);
                dPedidos.PrecioUnidad = reader.GetDecimal(2);
                dPedidos.Cantidad = reader.GetInt32(3);
                dPedidos.Descuento = reader.GetDecimal(4);

                lista.Add(dPedidos);
            }
            conexion.Close();
            return lista;
        }
     }
}
