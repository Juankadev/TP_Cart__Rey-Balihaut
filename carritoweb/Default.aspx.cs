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
    public partial class _Default : Page
    {
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvListado.DataSource = listaArticulos;
            dgvListado.DataBind();
            Session.Add("lista", listaArticulos);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label1.Text = "0";
            //Session.Add("cant", contador++);
            //Response.Redirect("Default.aspx?" + Session["lblCart"].ToString());
            //listaArticulosCarrito.Add();
            //Response.Redirect("Carrito.aspx?listaArticulos=" + listaArticulos, false);
        }
    }
}