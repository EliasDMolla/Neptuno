using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
   public class Clientes
    {
        public String IdCliente { get; set; }
        public string NombreContacto { get; set; }
        
       public Clientes(String idCliente,string nombreContacto)
        {
            NombreContacto = nombreContacto;
            IdCliente = idCliente;
        }

       public Clientes(){}

      }
}

