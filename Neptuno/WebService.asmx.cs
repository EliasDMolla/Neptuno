using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entidades;
using LN;
using System.Data;
using System.Web.Script.Services;

namespace Neptuno
{
    /// <summary>
    /// Descripción breve de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<Entidades.Pedidos> GetPedidos()
        {
            return WebServiceLN.ListaPedidos();
        }

        [WebMethod]
        public DataTable GetPedidosDT()
        {
            DataSet ds = WebServiceLN.PedidosDT();
            return ds.Tables[0];
        }
    }
}
