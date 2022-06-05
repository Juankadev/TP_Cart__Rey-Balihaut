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
        public List<Articulo> listaArticulosCarrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();


            if (!IsPostBack)
            {
                listaArticulosCarrito = new List<Dominio.Articulo>();
                Session.Add("listaArticulosCarrito", listaArticulosCarrito);
            }

            listaArticulosCarrito = Session["listaArticulosCarrito"] as List<Articulo>;

            if (Request.QueryString["id"] != null)
            {
                string id_string = Request.QueryString["id"].ToString();
                int id = Int32.Parse(id_string);
                listaArticulosCarrito.Add(negocio.busquedaId(id));
            }





        }
    }
}