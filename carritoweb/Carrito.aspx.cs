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
        //public List<Articulo> listaAux { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            string suma="";

            //se resetea, por eso no cargan todos los productos
            listaArticulosCarrito = new List<Dominio.Articulo>();


            if (Request.QueryString["id"] != null)
            {
                string id_string = Request.QueryString["id"].ToString();
                int id = Int32.Parse(id_string);

                listaArticulosCarrito.Add(negocio.busquedaId(id));
                Session.Add("listaArticulosCarrito", listaArticulosCarrito);
            } 
            listaArticulosCarrito = (List<Articulo>)Session["listaArticulosCarrito"];


            //price
            if (Request.QueryString["price"] != null)
            {
                suma = Request.QueryString["price"].ToString();
                Session.Add("price", suma);
            }

            price.Text = "$" + Session["price"].ToString();


            //btn-comprar
            success.Visible = false;        
        }

        protected void comprar_Click(object sender, EventArgs e)
        {
            success.Visible = true;
        }

    }
}