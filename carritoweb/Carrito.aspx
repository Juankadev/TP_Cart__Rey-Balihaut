<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="carritoweb.Contact" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="width:70px;height:70px;border-radius:100%;background-color:#111; position:fixed; margin-top:40px; z-index:20">
        <h4 style="text-align:center">
            <span style="color:#6b31ff;font-size:40px;"  class="glyphicon glyphicon-shopping-cart"></span>
        </h4>
        <asp:Label ID="contador" style="font-size:20px;" class="badge" runat="server" Text="0"></asp:Label>
    </div>

    <h2 class="cart-title"><%: Title %>.</h2>

    <h3>Tus productos añadidos.</h3>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div class="content-cart">

        <div class="content-items">  

           <%if(listaArticulosCarrito!=null){%> 
 
            <% foreach (Dominio.Articulo item in listaArticulosCarrito)
            { %> 
               <div class="cart-item">
                     <img src="<%=item.ImagenArt%>" class="card-img-top" alt="...">
                     <h5 class="card-title"><%=item.NombreArt %></h5>
                     <p><strong>$<%=item.PrecioArt %></strong></p>
                     <a href="Carrito.aspx?delete=<%=item.Id%>" class="img-delete glyphicon glyphicon-remove" ></a>
               </div>
             <% 
             } %>
           <%}
            else{%> 
            <h3>Tu Carrito está Vacio</h3>
             <%}%> 
            
        </div>
    



    <div class="resumen">
        <h3>Resumen</h3>
        <div class="total">
            <h5>Total</h5>
            <asp:Label ID="price" runat="server" Text="$0"></asp:Label>
        </div>
        <asp:Button ID="comprar" OnClick="comprar_Click" class="btn btn-success" runat="server" Text="Comprar" />
        <asp:Label ID="success" class="lbl-comprar" runat="server" Text="Gracias por tu compra!."></asp:Label>
    </div>

    </div>


</asp:Content>

