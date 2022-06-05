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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                catalogo = negocio.listar();              
                Session.Add("catalogo", catalogo);
            }

            dgvListado.DataSource = catalogo;
            dgvListado.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}