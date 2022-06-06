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
            if(!IsPostBack)
            {
                ArticuloNegocio art_negocio = new ArticuloNegocio();
                CategoriaNegocio cat_negocio = new CategoriaNegocio();
                catalogo = art_negocio.listar();
                categorias = cat_negocio.listar();
                Session.Add("catalogo", catalogo);
                Session.Add("categorias", categorias);
            }

            dgvListado.DataSource = catalogo;
            dgvListado.DataBind();
            //filtro_categorias.DataSource = categorias;
            /*Categoria i = new Categoria();
            i.IdCategoria = 2;
            i.DescripcionCategoria = "prueba";
            filtro_categorias.Items.Add(i.ToString());*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}