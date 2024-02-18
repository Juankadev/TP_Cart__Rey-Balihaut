<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="carritoweb.Contact" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="cart-title">Carrito de compras</h2>

    <h4 class="cart-subtitle">Tus productos añadidos.</h4>

    <div class="content-cart">

        <div class="content-items">

            <%if (articlesCart != null)
                {%>

            <% foreach (Dominio.Article item in articlesCart)
                { %>
            <div class="cart-item" id="item">
                <img src="<%=item.Image%>" class="card-img-top" alt="...">
                <h5 class="cart-item-title" id="cart-item-title"><%=item.Name%></h5>
                <p class="cart-item-price">$<%=item.Price%></p>
                <div class="icon-delete">
                    <a href="Cart.aspx?delete=<%=item.Id%>" class="img-delete bi bi-x-circle"></a>

                </div>

            </div>
            <% 
                } %>
            <%}
                else
                {%>
            <h3 id="titulo">Tu Carrito está Vacio</h3>
            <%}%>
        </div>


        <div class="resume-container">
            <h3 id="resume-title" class="resume-title">Resumen</h3>
            <div class="total">
                <h5 class="resume-total-title">Total: </h5>
                <asp:Label ID="price" CssClass="resume-total-price" runat="server" Text="$0"></asp:Label>
            </div>
            <asp:Button ID="buy" OnClick="buy_Click" class="btn btn-success" runat="server" Text="Comprar" />
            <asp:Label ID="success" class="lbl-comprar" runat="server" Text="Gracias por tu compra!."></asp:Label>
        </div>

    </div>


</asp:Content>

