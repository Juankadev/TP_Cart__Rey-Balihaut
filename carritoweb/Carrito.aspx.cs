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
            string val="";

            //se resetea, por eso no cargan todos los productos
            listaArticulosCarrito = new List<Dominio.Articulo>();


            if (Request.QueryString["id"] != null)
            {
                string id_string = Request.QueryString["id"].ToString();
                int id = Int32.Parse(id_string);

                listaArticulosCarrito.Add(negocio.busquedaId(id));
                Session.Add("listaArticulosCarrito", listaArticulosCarrito);
            } 
            


            //price

            if (Request.QueryString["price"] != null)
            {
                val = Request.QueryString["price"].ToString();
                Session.Add("price", val);
                price.Text = "$" + Session["price"].ToString();
            }
            else
            {
                if(listaArticulosCarrito != null)
                    price.Text = "$" + Session["price"].ToString();
            }
            

            //btn-comprar
            success.Visible = false; //gracias por tu compra


            //icon DELETE
            if (Request.QueryString["delete"] != null)
            {
                string id_string = Request.QueryString["delete"].ToString();
                int id = Int32.Parse(id_string);
                //Articulo aux = new Articulo();
                //aux = negocio.busquedaId(id);
                foreach(Dominio.Articulo item in listaArticulosCarrito)
                {
                    if(item.Id==id)
                    {
                        listaArticulosCarrito.Remove(item);
                    }               
                }

                Session.Add("listaArticulosCarrito", listaArticulosCarrito);              
            }


            listaArticulosCarrito = (List<Articulo>)Session["listaArticulosCarrito"];
        }

        protected void comprar_Click(object sender, EventArgs e)
        {
            success.Visible = true; //gracias por tu compra
        }

}
}