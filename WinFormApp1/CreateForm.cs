using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace WinFormApp1
{
    public partial class CreateForm : Form
    {
        private Articulo article = new Articulo();

        public CreateForm()
        {
            InitializeComponent();
            Text = "AGREGAR ARTICULO";
        }
        public CreateForm(Articulo article)
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
            CategoriaNegocio categoryRepository = new CategoriaNegocio();
            cboCategoria.DataSource = categoryRepository.listar();
            cboCategoria.ValueMember = "IdCategoria";
            cboCategoria.DisplayMember = "DescripcionCategoria";
        }
        private void LoadComboBoxBrand()
        {
            MarcaNegocio brandRepository = new MarcaNegocio();
            cboMarca.DataSource = brandRepository.listar();
            cboMarca.ValueMember = "IdMarca";
            cboMarca.DisplayMember = "DescripcionMarca";
        }
        private void LoadArticleInformation()
        {
            txtnumeric.Text = article.CodigoArt;
            txtNombre.Text = article.NombreArt;
            txtDescripcion.Text = article.DescripcionArt;
            numericUpDown1.Value = article.PrecioArt;
            txtUrlImagen.Text = article.ImagenArt;
            cboMarca.SelectedValue = article.Marca.IdMarca;
            cboCategoria.SelectedValue = article.Categoria.IdCategoria;
            LoadImage(article.ImagenArt);
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
            ArticuloNegocio repository = new ArticuloNegocio();
            try
            {
                SetArticle();

                if(article.Id != 0)
                {
                    repository.modificar(article);
                    MessageBox.Show("Articulo modificado");
                }
                else
                {
                    repository.agregar(article);
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
            article.CodigoArt = txtnumeric.Text;
            article.NombreArt = txtNombre.Text;
            article.DescripcionArt = txtDescripcion.Text;
            article.ImagenArt = txtUrlImagen.Text;
            article.Marca = (Marca)cboMarca.SelectedItem;
            article.Categoria = (Categoria)cboCategoria.SelectedItem;
            article.PrecioArt = numericUpDown1.Value;
        }
        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            LoadImage(txtUrlImagen.Text);
        }
    }
}
