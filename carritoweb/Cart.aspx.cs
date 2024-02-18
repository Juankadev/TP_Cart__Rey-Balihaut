using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Dominio;
using MailKit.Net.Smtp;
using MimeKit;

namespace carritoweb
{
    public partial class Contact : Page
    {
        public List<Article> articlesCart { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadArticlesCart();
            if (CheckIfAnArticleWasDeleted()) DeleteArticle();
            SetResume();
        }
        private void SetResume()
        {
            SetResumeTotalCart();
            SetResumeButtonsVisibility();
        }
        private void SetResumeButtonsVisibility()
        {
            if (Session["listaArticulosCarrito"] == null)
                buy.Visible = false;
            else buy.Visible = true;

            success.Visible = false;
        }
        private void LoadArticlesCart()
        {
            if (Session["listaArticulosCarrito"] == null)
                return;

            articlesCart = new List<Article>();
            articlesCart = (List<Article>)Session["listaArticulosCarrito"];
        }
        private bool CheckIfAnArticleWasDeleted()
        {
            return Request.QueryString["delete"] != null;
        }
        private void DeleteArticle()
        {
            if (int.TryParse(Request.QueryString["delete"], out int selectedId))
            {
                int index = articlesCart.FindIndex(a => a.Id == selectedId);
                articlesCart.RemoveAt(index);

                if (articlesCart.Count <= 0) Session.Remove("listaArticulosCarrito");
                else Session.Add("listaArticulosCarrito", articlesCart);

                LoadArticlesCart();
            }
        }
        private void SetResumeTotalCart()
        {
            if (articlesCart != null)
            {
                decimal sumTotal = (from a in articlesCart select a.Price).Sum();
                price.Text = "$" + sumTotal.ToString();
            }
        }
        protected void buy_Click(object sender, EventArgs e)
        {
            buy.Visible = false;
            success.Visible = true; //gracias por tu compra
            SendEmail();
            Session.Add("listaArticulosCarrito", null);
            //Response.Redirect(Request.Url.AbsoluteUri);
        }
        private void SendEmail()
        {
            if (articlesCart == null) return;

            const string User = "juanrey3d@gmail.com";
            const string DisplayName = "E-commerce";
            const string Password = "gryj qfxu birg ainc";

            string host = "smtp.gmail.com";
            int port = 587;

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(DisplayName, User));
            message.To.Add(new MailboxAddress("Destino", "juancruzrey1@hotmail.com"));
            message.Subject = "Venta Realizada";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody += "Felicidades, se ha realizado una venta exitosa en tu e-commerce !! <br> <br> <br>";

            foreach (Article article in articlesCart)
            {
                bodyBuilder.HtmlBody +=
                    "<div style='display:flex;'>" +
                        $"<img src={article.Image} style='width:8rem'>" +

                        "<div> " +
                            //$"<p>Codigo: {article.Code}</p>" +
                            $"<p>Articulo: {article.Name}</p>" +
                            $"<p>${article.Price} </p>" +
                        "</div> " +

                    "</div>" +

                    "<br><br>" +

                    "<div> " +
                        $"<strong style='font-size:1.4rem'>Total: {price.Text} " +
                        $"</strong>" +
                    "</div> ";

                //< div class="cart-item" id="item">
                //        <img src = "<%=item.Image%>" class="card-img-top" alt="...">
                //        <h5 class="cart-item-title" id="cart-item-title"><%=item.Name%></h5>
                //        <p class="cart-item-price">$<%=item.Price%></p>
                //        <div class="icon-delete">
                //            <a href = "Cart.aspx?delete=<%=item.Id%>" class="img-delete bi bi-x-circle"></a>

                //        </div>

                //    </div>

            }
            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient smtp = new SmtpClient();
            smtp.CheckCertificateRevocation = false;
            smtp.Connect(host, port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(User, Password);
            smtp.Send(message);
            smtp.Disconnect(true);
        }

        //private bool CheckIfAnArticleWasAdded()
        //{
        //    return Request.QueryString["id"] != null;
        //}

        //private void AddNewArticleToCart()
        //{
        //    ArticleRepository repository = new ArticleRepository();
        //    if (int.TryParse(Request.QueryString["id"], out int articleId))
        //    {
        //        articlesCart.Add(repository.GetById(articleId));
        //        Session.Add("listaArticulosCarrito", articlesCart);
        //    }
        //}
    }
}