using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carritoweb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateCartCount();
        }
        public void UpdateCartCount()
        {
            if (Session["listaArticulosCarrito"] == null)
            {
                contador.Text = "0";
                return;
            }

            contador.Text = ((List<Article>)Session["listaArticulosCarrito"]).Count.ToString();
        }
    }
}