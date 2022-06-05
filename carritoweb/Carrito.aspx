<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="carritoweb.Contact" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="cart-title"><%: Title %>.</h2>
    <h3>Tus productos añadidos.</h3>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div class="content-cart">
        <div class="content-items">  

           
            <% foreach (Dominio.Articulo item in listaArticulosCarrito)
            { %> 
               <div class="cart-item">
                     <img src="<%=item.ImagenArt%>" class="card-img-top" alt="...">
                     <h5 class="card-title"><%=item.NombreArt %></h5>
                     <p><strong>$<%=item.PrecioArt %></strong></p>                    
                     <span class="glyphicon glyphicon-remove"></span>
               </div>
             <% 
             } %>

            
        </div>
    



    <div class="resumen">
        <h3>Resumen</h3>
        <div class="total">
            <h5>Total</h5>
            <p>$123.123</p>
        </div>
        <button type="button" class="btn btn-success">Comprar</button>
    </div>

    </div>


</asp:Content>

