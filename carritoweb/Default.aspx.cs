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
        public List<Article> catalogo { get; set; }
        public List<Category> categorias { get; set; }
        public List<Brand> marcas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleRepository art_negocio = new ArticleRepository();
            CategoryRepository cat_negocio = new CategoryRepository();
            BrandRepository marca_negocio = new BrandRepository();

            if (!IsPostBack)
            {
                //catalogo = art_negocio.listar();
                //Session.Add("catalogo", catalogo);
                categorias = cat_negocio.GetAll();
                Session.Add("categorias", categorias);
                marcas = marca_negocio.GetAll();
                Session.Add("marcas", marcas);
    
                if(Session["listaArticulosCarrito"]!=null) {
                    List<Article> listaArticulosCarrito = new List<Article>();
                    listaArticulosCarrito = (List<Article>)Session["listaArticulosCarrito"];
                    Session.Add("contador", listaArticulosCarrito.Count);
                    contador.Text = Session["contador"].ToString();
                }
            }

            //FILTRO CATEGORIAS
            if (Request.QueryString["categoria"] != null)
            {
                string id_string = Request.QueryString["categoria"].ToString();
                int id = Int32.Parse(id_string);
                catalogo = art_negocio.GetAllByCategory(id);
            }           
            //FILTRO MARCAS
            else if (Request.QueryString["marca"] != null)
            {
                string id_string = Request.QueryString["marca"].ToString();
                int id = Int32.Parse(id_string);
                catalogo = art_negocio.GetAllByBrand(id);
            }
            else { catalogo = art_negocio.GetAll(); }

            dgvListado.DataSource = catalogo;
            dgvListado.DataBind();

        }
    }
}