<%@ Page Title="" Language="C#" MasterPageFile="~/Neptuno.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Neptuno.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous"/>
    <style>
      
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h3>Pedidos</h3>
        <hr />
    </div>
    
    <div class="container">
    
    <h5>Grilla de Pedidos</h5>
        <div class="form-group">
            <asp:GridView ID="grilla_pedidos" runat="server" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grilla_pedidos_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="IdPedido" OnSelectedIndexChanged="grilla_pedidos_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="IdCliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="IdEmpleado" HeaderText="Empleado" />
                    <asp:BoundField DataField="FechaPedido" HeaderText="Fecha" />
                    <asp:BoundField DataField="MontoTotal" HeaderText="Total" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#aeffa0" />
                <HeaderStyle BackColor="#28a745" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#aeffa0" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#aeffa0" />
                <SelectedRowStyle BackColor="#aeffa0" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#aeffa0" />
                <SortedAscendingHeaderStyle BackColor="#aeffa0" />
                <SortedDescendingCellStyle BackColor="#aeffa0" />
                <SortedDescendingHeaderStyle BackColor="#aeffa0" />
            </asp:GridView>
        </div>
    <hr />
    
    <h5>Nuevo Pedido</h5>
    <div class="form-group">
        <label>Empleado:</label>
        <asp:DropDownList CssClass="form-control" ID="ddl_empleado" AppendDataBoundItems="true" runat="server" AutoPostBack="True">
             <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
        </asp:DropDownList>
    </div>
            
    <div class="form-group">
        <label>Cliente:</label>
        <asp:DropDownList CssClass="form-control" ID="ddl_cliente" runat="server" AppendDataBoundItems="true" AutoPostBack="True">
            <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
        </asp:DropDownList>
    </div>

        <asp:Label ID="lbl_fechaHoy" runat="server" Text=""></asp:Label>
    
    <hr />

    <h5>Productos</h5>
    <div class="form-group">
        <label>Producto:</label>
        <asp:DropDownList CssClass="form-control" ID="ddl_producto" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddl_producto_SelectedIndexChanged">
            <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
        </asp:DropDownList>
    </div>

        <asp:Label ID="lbl_precioProducto" runat="server" Text=""></asp:Label>
    
    <div class="form-group">
        <label>Cantidad:</label>
        <asp:TextBox CssClass="form-control" ID="txt_cantidad" ValidationGroup="Login" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Login" runat="server" ErrorMessage="El campo cantidad es obligatorio" ControlToValidate="txt_cantidad" ForeColor="Red"></asp:RequiredFieldValidator>

    </div>
    
    <div class="form-group">
        <label>Descuento:</label>
        <asp:TextBox CssClass="form-control" ID="txt_descuento" runat="server" ValidationGroup="Login"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Login" ErrorMessage="El campo descuento es obligatorio" ControlToValidate="txt_descuento" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>        
   
        <asp:Button CssClass="btn btn-success" ID="btn_agregarProductos" ValidationGroup="Login" runat="server" Text="Agregar" OnClick="btn_agregarProductos_Click" />
   
    <hr />


    <h5>Grilla Detalles de Pedidos</h5>
        <div class="form-group">
                <asp:GridView ID="grilla_detallePedido" runat="server" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#aeffa0" />
                <HeaderStyle BackColor="#28a745" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#aeffa0" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#aeffa0" />
                <SelectedRowStyle BackColor="#aeffa0" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#aeffa0" />
                <SortedAscendingHeaderStyle BackColor="#aeffa0" />
                <SortedDescendingCellStyle BackColor="#aeffa0" />
                <SortedDescendingHeaderStyle BackColor="#aeffa0" />
            </asp:GridView>
        </div>

    <hr />
            
    <asp:Button CssClass="btn btn-success" ID="cmdGuardarPedido" runat="server" Text="Guardar" OnClick="cmdGuardarPedido_Click" /> <br />
        
    <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label>

    </div>
       

 <footer class="container-fluid text-center bg-lightgray">

        <div class="copyrights" style="margin-top:25px;">
            <p>Calchin © 2018, All Rights Reserved
                <br/>
                <span>Web Design By: Elias Molla</span></p>
            <p><a href="https://www.linkedin.com/in/elias-molla/" target="_blank">Linkedin <i class="fa fa-linkedin-square" aria-hidden="true"></i> </a></p>
        </div>
</footer>

</asp:Content>
