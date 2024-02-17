using System;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace WinFormApp1
{
    public partial class CreateForm : Form
    {
        private Article article = new Article();

        public CreateForm()
        {
            InitializeComponent();
            Text = "AGREGAR ARTICULO";
        }
        public CreateForm(Article article)
        {
            InitializeComponent();
            this.article = article;
            Text = "MODIFICAR ARTICULO";
        }
        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                FillInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FillInputs()
        {
            LoadComboBoxBrand();
            LoadComboBoxCategory();

            if (article.Id != 0) //is modify action
                LoadArticleInformation();
        }
        private void LoadComboBoxCategory()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            cboCategoria.DataSource = categoryRepository.GetAll();
            cboCategoria.ValueMember = "IdCategoria";
            cboCategoria.DisplayMember = "DescripcionCategoria";
        }
        private void LoadComboBoxBrand()
        {
            BrandRepository brandRepository = new BrandRepository();
            cboMarca.DataSource = brandRepository.GetAll();
            cboMarca.ValueMember = "IdMarca";
            cboMarca.DisplayMember = "DescripcionMarca";
        }
        private void LoadArticleInformation()
        {
            txtnumeric.Text = article.Code;
            txtNombre.Text = article.Name;
            txtDescripcion.Text = article.Description;
            numericUpDown1.Value = article.Price;
            txtUrlImagen.Text = article.Image;
            cboMarca.SelectedValue = article.Brand.Id;
            cboCategoria.SelectedValue = article.Category.Id;
            LoadImage(article.Image);
        }
        private void LoadImage(string image)
        {
            try
            {
                pbxArticulo.Load(image);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://i.seadn.io/gae/OGpebYaykwlc8Tbk-oGxtxuv8HysLYKqw-FurtYql2UBd_q_-ENAwDY82PkbNB68aTkCINn6tOhpA8pF5SAewC2auZ_44Q77PcOo870?auto=format&dpr=1&w=1400&fr=1");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticleRepository repository = new ArticleRepository();
            try
            {
                SetArticle();

                if(article.Id != 0)
                {
                    repository.Modify(article);
                    MessageBox.Show("Articulo modificado");
                }
                else
                {
                    repository.Add(article);
                    MessageBox.Show("Articulo agregado");
                }                        
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
;           }
            finally
            {
                Close();
            }
        }
        private void SetArticle()
        {
            article.Code = txtnumeric.Text;
            article.Name = txtNombre.Text;
            article.Description = txtDescripcion.Text;
            article.Image = txtUrlImagen.Text;
            article.Brand = (Brand)cboMarca.SelectedItem;
            article.Category = (Category)cboCategoria.SelectedItem;
            article.Price = numericUpDown1.Value;
        }
        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            LoadImage(txtUrlImagen.Text);
        }
    }
}
