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
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio art_negocio = new ArticuloNegocio();
            CategoriaNegocio cat_negocio = new CategoriaNegocio();

            if (!IsPostBack)
            {
                //catalogo = art_negocio.listar();
                categorias = cat_negocio.listar();
                //Session.Add("catalogo", catalogo);
                Session.Add("categorias", categorias);
            }
         
            if (Request.QueryString["categoria"] != null)
            {
                string id_string = Request.QueryString["categoria"].ToString();
                int id = Int32.Parse(id_string);
                catalogo = art_negocio.listarFiltro(id);
            }
            else{catalogo = art_negocio.listar();}


            dgvListado.DataSource = catalogo;
            dgvListado.DataBind();

            //filtro_categorias.DataSource = categorias;
            /*Categoria i = new Categoria();
            i.IdCategoria = 2;
            i.DescripcionCategoria = "prueba";
            filtro_categorias.Items.Add(i.ToString());*/
        }
    }
}