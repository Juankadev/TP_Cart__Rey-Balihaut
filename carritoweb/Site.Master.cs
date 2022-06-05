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
        //public string carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblCart.Text = Session["cant"].ToString();

            //Session.Add("lblCart", lblCart);
            //Response.Redirect("Default.aspx");
        }
    }
}