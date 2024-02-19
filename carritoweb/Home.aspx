<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="carritoweb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <img class="banner" src="https://www.hardgamers.com.ar/public/images/country/ar/stores/acuarioInsumos/banner-top.gif" alt="Alternate Text" />

    <asp:GridView style="display:none" ID="dgvListado" runat="server"></asp:GridView>

    <div class="container-general">

        <div class="container-filters">
            <div class="" style="margin-bottom: 50px">
                <h3 id="titulo">Categorias</h3>
                <% foreach (Dominio.Category item in categories)
                    {%>
                <a id="filtro-a" href="Home.aspx?categoria=<%=item.Id%>"><%=item.Description %></a>
                <%}
                %>
            </div>

            <div class="" style="margin-bottom: 50px">
                <h3 id="titulo">Marcas</h3>
                <% foreach (Dominio.Brand item in brands)
                    {%>
                <a id="filtro-a" href="Home.aspx?marca=<%=item.Id%>"><%=item.Description %></a>
                <%}
                %>
            </div>
        </div>

        <div class="content-card">
            <% foreach (Dominio.Article item in articles)
                {%>
            <div class="card">
                <div class="card-img">
                    <img src="<%=item.Image%>" class="card-img-top" alt="...">
                </div>
                <div class="card-body">
                    <h2 class="card-title"><%=item.Name %></h2>
                    <%--   <p class="card-text"><%=item.Description %></p>--%>
                    <p><strong>$<%=item.Price %></strong></p>
                    <a style="font-weight:bold" class="btn-add" href="Home.aspx?id=<%=item.Id %>">
                        <i class="bi bi-cart-plus-fill"></i> Agregar
                    </a>
                </div>
            </div>
            <%}
            %>
        </div>

    </div>
</asp:Content>
