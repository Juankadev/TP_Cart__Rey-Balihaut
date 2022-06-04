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
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
            Text = "AGREGAR ARTICULO";
        }

        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "MODIFICAR ARTICULO";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           /// Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {

                if (articulo == null)
                {
                    articulo = new Articulo();
                }

                articulo.CodigoArt = txtnumeric.Text;
                articulo.NombreArt = txtNombre.Text;
                articulo.DescripcionArt = txtDescripcion.Text;
                articulo.ImagenArt = txtUrlImagen.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.PrecioArt = numericUpDown1.Value;

                if(articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Articulo modificado");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Articulo agregado");
                }
                

               

                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
;           }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "IdMarca";
                cboMarca.DisplayMember = "DescripcionMarca";
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "IdCategoria";
                cboCategoria.DisplayMember = "DescripcionCategoria";


                if(articulo != null)
                {
                    txtnumeric.Text = articulo.CodigoArt;
                    txtNombre.Text = articulo.NombreArt;
                    txtDescripcion.Text = articulo.DescripcionArt;
                    numericUpDown1.Value = articulo.PrecioArt;
                    txtUrlImagen.Text = articulo.ImagenArt;
                    CargarImagen(articulo.ImagenArt);
                    cboMarca.SelectedValue = articulo.Marca.IdMarca;
                    cboCategoria.SelectedValue = articulo.Categoria.IdCategoria;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrlImagen.Text);
        }

        private void CargarImagen(string Imagen)
        {
            try
            {
                pbxArticulo.Load(Imagen);
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://www.agora-gallery.com/advice/wp-content/uploads/2015/10/image-placeholder.png");
            }


        }


        /*private void txtnumeric_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                tilde1.Visible = true;
            }
            else
            {
                tilde1.Visible = false;
            }
        }*/
    }
}
