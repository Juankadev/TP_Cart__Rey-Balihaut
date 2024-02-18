using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace carritoweb
{
    public partial class _Default : Page
    {
        public List<Article> articles { get; set; }
        public List<Category> categories { get; set; }
        public List<Brand> brands { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categories = new CategoryRepository().GetAll();
                brands = new BrandRepository().GetAll();
                Session.Add("categorias", categories);
                Session.Add("marcas", brands);
            }

            if (CheckIfAnArticleWasAdded())
                AddArticleToCart();

            SetArticles();
            dgvListado.DataSource = articles;
            dgvListado.DataBind();
        }
        private bool CheckIfAnArticleWasAdded()
        {
            return Request.QueryString["id"] != null;
        }
        private void SetArticles()
        {
            ArticleRepository articleRepository = new ArticleRepository();

            //Filter categories
            if (int.TryParse(Request.QueryString["categoria"], out int categoryId))
                articles = articleRepository.GetAllByCategory(categoryId);

            //Filter brands
            else if (int.TryParse(Request.QueryString["marca"],out int brandId))
                articles = articleRepository.GetAllByBrand(brandId);

            //Filter All
            else 
                articles = articleRepository.GetAll();
        }

        private void AddArticleToCart()
        {
            if (int.TryParse(Request.QueryString["id"], out int articleId))
            {
                Article newArticle = new ArticleRepository().GetById(articleId);
                List<Article> articles = new List<Article>();

                if (Session["listaArticulosCarrito"] != null)
                    articles = (List<Article>)Session["listaArticulosCarrito"];

                articles.Add(newArticle);
                Session.Add("listaArticulosCarrito", articles);
            }
        }
    }
}