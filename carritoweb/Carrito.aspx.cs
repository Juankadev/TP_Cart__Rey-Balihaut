using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace carritoweb
{
    public partial class Contact : Page
    {
        public List<Articulo> listaArticulos { get; set; }
        public List<Articulo> listaArticulosCarrito { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("listaCarrito", listaArticulosCarrito);

            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();

            string id = Request.QueryString["id"].ToString();
            Label1.Text = id;
            //listaArticulosCarrito
            //listaArticulosCarrito = Session["listaArticulos"].ToString();

        }
    }
}