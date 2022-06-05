<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="carritoweb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron" style="background-image: url(https://ideakreativa.net/wp-content/uploads/2021/11/mejores-all-in-one-para-disen%CC%83o.jpg); background-attachment:fixed;background-size:contain">
        <div style="background-color:rgba(0,0,0,0.5); width:500px; padding:20px; border-radius:5px">
            <h1 style="color:#6b31ff">Tienda Online</h1>
            <p style="color:#fff" class="lead">Añade los productos de tu interés al #Carrito.</p>
            <p>
                <a runat="server" class="btn btn-primary btn-lg" href="~/Carrito">
                    <span class="glyphicon glyphicon-shopping-cart"></span>
                    Mi Carrito &raquo;
                </a>
            </p>
        </div>
    </div>

    <asp:GridView style="display:none" ID="dgvListado" runat="server"></asp:GridView>
    

     <div class="content-card">

         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <% foreach (Dominio.Articulo item in listaArticulos)
        {%> 
                <div class="card">
                    <div class="card-img">
                        <img src="<%=item.ImagenArt%>" class="card-img-top" alt="...">
                    </div>
                    <div class="card-body">
                      <h2 class="card-title"><%=item.NombreArt %></h2>
                      <p class="card-text"><%=item.DescripcionArt %></p>
                      <p><strong>$<%=item.PrecioArt %></strong></p>  
                        <a class="btn-add" href="Carrito.aspx?id=<%=item.Id %>">Añadir al Carrito</a>
                        <!--<asp:Button ID="Button1" PostBack="true" OnClick="Button1_Click" class="btn-add" runat="server" Text="Añadir al Carrito" />-->
                    </div>
                </div>
            <%}
        %>

      </div>

</asp:Content>
