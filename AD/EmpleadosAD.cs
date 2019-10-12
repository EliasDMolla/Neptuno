using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Configuration;

namespace AD
{
    public class EmpleadosAD
    {
        public static List<Empleados> BuscarTodos() 
        {
            List<Empleados> lista = new List<Empleados>();

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyBD"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select IdEmpleado,Nombre + ' ' + Apellidos As 'Nombre Completo' from Empleados", conexion);
            
            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read()) 
            {
                Empleados pEmpleados = new Empleados();

                pEmpleados.IdEmpleado = reader.GetInt32(0);
                pEmpleados.NombreCompleto = reader.GetString(1);

                lista.Add(pEmpleados);
            }
            conexion.Close();
            return lista;
        }

    }
}
