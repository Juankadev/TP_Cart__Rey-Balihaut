<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="carritoweb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="width:100px;height:100px;border-radius:100%;background-color:#111; position:fixed; margin-top:300px; z-index:20">
        <h4 style="text-align:center">
            <img style="width:60px; position:relative;top:20px" src="https://i.pinimg.com/originals/eb/da/b9/ebdab98415d1cfe99877d909412acdfa.png"/>
        </h4>
        <asp:Label ID="contador" style="color:#fff;font-size:25px;" class="badge" runat="server" Text="0"></asp:Label>
    </div>


    <div class="jumbotron" style="background-image: url(https://images.unsplash.com/photo-1580894894513-541e068a3e2b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80); background-attachment:fixed;background-size:cover; background-repeat:none">
        <div style="background-color:rgba(0,0,0,0.5); width:500px; padding:20px; border-radius:5px">
            <h1>Tienda Online</h1>
            <p style="color:#fff" class="lead">Añade los productos de tu interés al #Carrito.</p>
            <p>
                <a runat="server" class="btn btn-primary btn-lg" href="~/Carrito">
                    <span class="glyphicon glyphicon-shopping-cart"></span>
                    Mi Carrito &raquo;
                </a>
            </p>
        </div>
    </div>


 
           <h3 id="titulo">Categorias</h3>
       <div class="container-filtro" style="margin-bottom:50px">     
            <% foreach (Dominio.Categoria item in categorias)
            {%>           
               <a id="filtro-a" href="Default.aspx?categoria=<%=item.IdCategoria%>"><%=item.DescripcionCategoria %></a>       
            <%}
            %>
       </div>



           <h3 id="titulo">Marcas</h3>
    <div class="container-filtro" style="margin-bottom:50px">     
            <% foreach (Dominio.Marca item in marcas)
            {%>           
               <a id="filtro-a" href="Default.aspx?marca=<%=item.IdMarca%>"><%=item.DescripcionMarca %></a>       
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
                        <a class="btn-add" href="Carrito.aspx?id=<%=item.Id %>&price=<%=item.PrecioArt %>">
                            Añadir al Carrito
                        </a>
                    </div>
                </div>
            <%}
        %>

      </div>

</asp:Content>
