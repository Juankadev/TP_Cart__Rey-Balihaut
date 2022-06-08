<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="carritoweb.Contact" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="width:100px;height:100px;border-radius:100%;background-color:#111; position:fixed; margin-top:240px; z-index:20">
        <h4 style="text-align:center">
            <img style="width:60px; position:relative;top:20px" src="https://i.pinimg.com/originals/eb/da/b9/ebdab98415d1cfe99877d909412acdfa.png"/>
        </h4>
        <asp:Label ID="contador" style="color:#fff;font-size:25px;" class="badge" runat="server" Text="0"></asp:Label>
    </div>

    <h2 class="cart-title" id="titulo"><%: Title %>.</h2>

    <h3 id="titulo">Tus productos añadidos.</h3>
  
    <div class="content-cart">

        <div class="content-items">  

           <%if(listaArticulosCarrito!=null || listaArticulosCarrito.Count()==0){%> 
 
            <% foreach (Dominio.Articulo item in listaArticulosCarrito)
            { %> 
               <div class="cart-item" id="titulo">
                     <img src="<%=item.ImagenArt%>" class="card-img-top" alt="...">
                     <h5 class="card-title" id="titulo"><%=item.NombreArt %></h5>
                     <p id="titulo"><strong>$<%=item.PrecioArt %></strong></p>
                     <a href="Carrito.aspx?delete=<%=item.Id%>" class="img-delete glyphicon glyphicon-remove" ></a>
               </div>
             <% 
             } %>
           <%}
            else{%> 
            <h3 id="titulo">Tu Carrito está Vacio</h3>
             <%}%> 
            
        </div>
    



    <div class="resumen">
        <h3 id="titulo">Resumen</h3>
        <div class="total">
            <h5 id="titulo">Total</h5>
            <asp:Label ID="price" style="color:#fff" runat="server" Text="$0"></asp:Label>
        </div>
        <!--<asp:Button ID="comprar" OnClick="comprar_Click" class="btn btn-success" runat="server" Text="Comprar" />-->
        <!--<asp:Label ID="success" class="lbl-comprar" runat="server" Text="Gracias por tu compra!."></asp:Label>-->
    </div>

    </div>


</asp:Content>

