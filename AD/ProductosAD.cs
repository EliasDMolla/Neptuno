using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Configuration;

namespace AD
{
    public class ProductosAD
    {
        public static List<Productos> BuscarTodos()
        {
            List<Productos> lista = new List<Productos>();

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyBD"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select idproducto,nombreProducto,precioUnidad from productos", conexion);

            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Productos pProductos = new Productos();

                pProductos.IdProducto = reader.GetInt32(0);
                pProductos.NombreProducto = reader.GetString(1);
                pProductos.PrecioUnidad = reader.GetDecimal(2);

                lista.Add(pProductos);
            }
            conexion.Close();
            return lista;
        }
    }
}
