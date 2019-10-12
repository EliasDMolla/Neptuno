using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LN;

namespace Neptuno
{
    public partial class Pedidos : System.Web.UI.Page
    {
        PedidosLN Gestor;
        protected void Page_Load(object sender, EventArgs e)
        {

            this.MaintainScrollPositionOnPostBack = true;
            
            if (!IsPostBack)
            {
                Gestor = new PedidosLN();

                cmdGuardarPedido.Enabled = false;
                CargarGrillaPedidos();
                CargarEmpleados();
                CargarClientes();
                CargarEmpleados();
                CargarProductos();

                lbl_fechaHoy.Text = DateTime.Today.ToString();

                Session["Gestor"] = Gestor;
            }
            else
            {
                Gestor = (PedidosLN)Session["Gestor"];
            }
        }

        protected void btn_agregarProductos_Click(object sender, EventArgs e)
        {
            Gestor.AgregarProductos(int.Parse(ddl_producto.SelectedValue), 
                int.Parse(txt_cantidad.Text), int.Parse(txt_descuento.Text));

            grilla_detallePedido.DataSource = Gestor.NuevoPedido.ListaDetallePedidos;
            grilla_detallePedido.DataBind();

            cmdGuardarPedido.Enabled = true;

            ddl_empleado.Enabled = false;
            ddl_cliente.Enabled = false;
           
            decimal descuento = int.Parse(txt_descuento.Text);
            
            decimal cantidad = int.Parse(txt_cantidad.Text);

            decimal suma = 0;
            
            foreach (DetalleDePedidos item in Gestor.NuevoPedido.ListaDetallePedidos)
            {

                suma = suma + (item.PrecioUnidad * item.Cantidad - item.Descuento);

            }

            string total = suma.ToString();

            lbl_total.Text = "$ " + total;

            Session["Gestor"] = Gestor;

            txt_cantidad.Text = "";
            txt_descuento.Text = "";
            lbl_precioProducto.Text = "";

        }
        protected void ddl_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            foreach (var item in Gestor.ListaProductos)
            {
                if (item.IdProducto.ToString() == ddl_producto.SelectedValue.ToString())
                {
                    lbl_precioProducto.Text = item.PrecioUnidad.ToString("$ 0.00");
                    Gestor.ProductoSeleccionado = item;
                }
            }
        }

        protected void cmdGuardarPedido_Click(object sender, EventArgs e)
        {
            Gestor.NuevoPedido.IdCliente = ddl_cliente.SelectedValue;
            Gestor.NuevoPedido.IdEmpleado = ddl_empleado.SelectedValue;
            Gestor.NuevoPedido.FechaPedido = (DateTime.Today).ToString();

            Gestor.GuardarPedido();
            
            //Session["Gestor"] = Gestor;

            // vaya a saber porque no actualiza 
            grilla_pedidos.DataSource = Gestor.ListaPedidos;
            grilla_pedidos.DataBind();

            lbl_total.Text = "Pedido guardado correctamente!";
            
            // provisoriamente que se carge de nuevo la pag jaja
            Response.Redirect("Pedidos.aspx");
        }

        void CargarEmpleados()
        {
            ddl_empleado.DataSource = Gestor.ListaEmpleados;
            ddl_empleado.DataValueField = "IdEmpleado";
            ddl_empleado.DataTextField = "NombreCompleto";
            ddl_empleado.DataBind();
        }
        void CargarClientes() 
        {
            ddl_cliente.DataSource = Gestor.ListaClientes;
            ddl_cliente.DataValueField = "IdCliente";
            ddl_cliente.DataTextField = "NombreContacto";
            ddl_cliente.DataBind();
        }
        void CargarProductos() 
        {
            ddl_producto.DataSource = Gestor.ListaProductos;
            ddl_producto.DataValueField = "IdProducto";
            ddl_producto.DataTextField = "NombreProducto";
            ddl_producto.DataBind();
        }
        void CargarGrillaPedidos() 
        {
            grilla_pedidos.DataSource = Gestor.ListaPedidos;
            grilla_pedidos.DataBind();      
        }

        protected void grilla_pedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grilla_pedidos.PageIndex = e.NewPageIndex;
            CargarGrillaPedidos();

            Session["Gestor"] = Gestor;
        }

        protected void grilla_pedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_fechaHoy.Text = grilla_pedidos.SelectedDataKey.Value.ToString();
        }
    }
}