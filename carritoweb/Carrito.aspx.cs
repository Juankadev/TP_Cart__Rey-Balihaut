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
            //Session.Add("listaCarrito", listaArticulosCarrito);
            //listaArticulosCarrito = Session["listaArticulos"].ToString();

            ArticuloNegocio negocio = new ArticuloNegocio();

            //obtengo ID
            string id_string = Request.QueryString["id"].ToString(); //validar null
            int id = Int32.Parse(id_string);
            //Busco ID
            //listaArticulosCarrito = negocio.listar();
            //listaArticulosCarrito.Add(negocio.busquedaId(id));

            listaArticulosCarrito = negocio.busquedalistaId(id);
        }
    }
}