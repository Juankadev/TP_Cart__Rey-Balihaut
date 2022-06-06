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
        public List<Articulo> catalogo { get; set; }
        public List<Categoria> categorias { get; set; }
        public List<Marca> marcas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio art_negocio = new ArticuloNegocio();
            CategoriaNegocio cat_negocio = new CategoriaNegocio();
            MarcaNegocio marca_negocio = new MarcaNegocio();

            if (!IsPostBack)
            {
                //catalogo = art_negocio.listar();
                //Session.Add("catalogo", catalogo);
                categorias = cat_negocio.listar();
                Session.Add("categorias", categorias);
                marcas = marca_negocio.listar();
                Session.Add("marcas", marcas);
   
                //List<Articulo> listaArticulosCarrito = new List<Articulo>();
                //listaArticulosCarrito = (List<Articulo>)Session["listaArticulosCarrito"];
                //Session.Add("contador", listaArticulosCarrito.Count);
                //contador.Text = Session["contador"].ToString();
            }

            //FILTRO CATEGORIAS
            if (Request.QueryString["categoria"] != null)
            {
                string id_string = Request.QueryString["categoria"].ToString();
                int id = Int32.Parse(id_string);
                catalogo = art_negocio.listarFiltroCat(id);
            }
            else{catalogo = art_negocio.listar();}


            //FILTRO MARCAS
            if (Request.QueryString["marca"] != null)
            {
                string id_string = Request.QueryString["marca"].ToString();
                int id = Int32.Parse(id_string);
                catalogo = art_negocio.listarFiltroMarca(id);
            }
            else { catalogo = art_negocio.listar(); }


            dgvListado.DataSource = catalogo;
            dgvListado.DataBind();

        }
    }
}