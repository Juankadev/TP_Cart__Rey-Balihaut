<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="carritoweb.Contact" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
                     <asp:ImageButton ID="ImageButton1" class="img-delete" runat="server" />
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

