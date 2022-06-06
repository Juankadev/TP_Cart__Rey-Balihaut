﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="carritoweb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron" style="background-image: url(https://images.unsplash.com/photo-1580894894513-541e068a3e2b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80); background-attachment:fixed;background-size:cover; background-repeat:none">
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


 
       <div class="container-categorias" style="margin-bottom:50px">     
           <h3>Categorias</h3>
            <% foreach (Dominio.Categoria item in categorias)
            {%>           
               <a id="categorias-a" href="Default.aspx?<%=item.DescripcionCategoria%>"><%=item.DescripcionCategoria %></a>       
            <%}
            %>
       </div>


    <asp:GridView style="display:none" ID="dgvListado" runat="server"></asp:GridView>

     <div class="content-card">

        <% foreach (Dominio.Articulo item in catalogo)
        {%> 
                <div class="card">
                    <div class="card-img">
                        <img src="<%=item.ImagenArt%>" class="card-img-top" alt="...">
                    </div>
                    <div class="card-body">
                      <h2 class="card-title"><%=item.NombreArt %></h2>
                      <p class="card-text"><%=item.DescripcionArt %></p>
                      <p><strong>$<%=item.PrecioArt %></strong></p>                         
                        <a class="btn-add" href="Carrito.aspx?id=<%=item.Id %>&price=<%=item.PrecioArt %>">Añadir al Carrito</a>
                        <!--<asp:Button ID="Button1" PostBack="true" OnClick="Button1_Click" class="btn-add" runat="server" Text="Añadir al Carrito" />-->
                    </div>
                </div>
            <%}
        %>

      </div>

</asp:Content>
