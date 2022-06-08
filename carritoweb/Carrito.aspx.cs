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
            string valor;

            listaArticulosCarrito = new List<Dominio.Articulo>();

            if (Request.QueryString["id"] != null)
            {
                string id_string = Request.QueryString["id"].ToString();
                int id = Int32.Parse(id_string);   
                
                if(Session["listaArticulosCarrito"]!=null)
                {
                    listaArticulosCarrito = (List<Articulo>)Session["listaArticulosCarrito"];
                }
    
                listaArticulosCarrito.Add(negocio.busquedaId(id));
                Session.Add("listaArticulosCarrito", listaArticulosCarrito);
            }





            //btn-comprar
            //success.Visible = false; //gracias por tu compra


            listaArticulosCarrito = (List<Articulo>)Session["listaArticulosCarrito"];
            //icon DELETE
            if (Request.QueryString["delete"] != null)
            {
                int id = Int32.Parse(Request.QueryString["delete"].ToString());
                int index = 0;
                foreach (Dominio.Articulo item in listaArticulosCarrito)
                {               
                    if(id==item.Id)
                    {
                        index = index;                   
                        break;
                    }
                    index++;
                }

                listaArticulosCarrito.RemoveAt(index);
                //listaArticulosCarrito = (List<Articulo>)Session["listaArticulosCarrito"];
                Session.Add("listaArticulosCarrito", listaArticulosCarrito);



                //descuento del total el producto eliminado

                //string nuevoprice = Session["price"].ToString();
                //decimal valor2 = Int32.Parse(nuevoprice);
                //valor2 = valor2 - item.PrecioArt;
                //string guardar = valor2.ToString();
                //Session.Add("price", guardar);
                //price.Text = "$" + guardar;
            }


            //cuento el producto agregado
            listaArticulosCarrito = (List<Articulo>)Session["listaArticulosCarrito"];
            if(listaArticulosCarrito != null)
            {
                Session.Add("contador", listaArticulosCarrito.Count);
                contador.Text = Session["contador"].ToString();
            }




            //price
            if (Request.QueryString["price"] != null)
            {
                valor = Request.QueryString["price"].ToString();

                if(Session["price"]!=null)
                {
                    string valorString = Session["price"].ToString();
                    decimal acumulado = decimal.Parse(valorString);
                    valor = (decimal.Parse(valor) + acumulado).ToString();
                    Session.Add("price", valor);
                }
                else
                {
                    Session.Add("price", valor);
                }

                //string format = Session["price"].ToString();
                //format = String.Format("{0:00}");
                price.Text = "$" + Session["price"].ToString();
            }
            else
            {
                listaArticulosCarrito = (List<Articulo>)Session["listaArticulosCarrito"];
                if (listaArticulosCarrito == null) //Funciona pero CHEQUEAR..., probar con session a futuro
                {
                    price.Text = "$0";
                }
                else
                {
                    price.Text = "$" + Session["price"].ToString();
                }
            }
        }



        protected void comprar_Click(object sender, EventArgs e)
        {
            //success.Visible = true; //gracias por tu compra
        }

}
}