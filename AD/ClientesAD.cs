using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Configuration;

namespace AD
{
    public class ClientesAD
    {
        public static List<Clientes> BuscarTodos() 
        {
            List<Clientes> lista = new List<Clientes>();

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyBD"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select idCliente,NombreContacto from clientes", conexion);

            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                Clientes pClientes = new Clientes();

                pClientes.IdCliente = reader.GetString(0);
                pClientes.NombreContacto = reader.GetString(1);

                lista.Add(pClientes);
            }
            conexion.Close();
            return lista;
        }
    }
}
