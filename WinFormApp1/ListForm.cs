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
    public partial class ListForm : Form
    {
        private List<Articulo> productsList;
        public ListForm()
        {
            InitializeComponent();
        }
        private void frmListado_Load(object sender, EventArgs e)
        {
            SetGridView();
        }
        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            Articulo selected = (Articulo)dgvListado.CurrentRow.DataBoundItem;
            LoadImage(selected.ImagenArt);
        }
        private void LoadImage(string Imagen)
        {
            try
            {
                pbArticulo.LoadAsync(Imagen);
            }
            catch (Exception)
            {
                pbArticulo.LoadAsync("https://i.seadn.io/gae/OGpebYaykwlc8Tbk-oGxtxuv8HysLYKqw-FurtYql2UBd_q_-ENAwDY82PkbNB68aTkCINn6tOhpA8pF5SAewC2auZ_44Q77PcOo870?auto=format&dpr=1&w=1400&fr=1");
            }
        }
        private void SetGridView(List<Articulo> list = null)
        {
            try
            {
                dgvListado.DataSource = 
                    list == null 
                    ? productsList = new ArticuloNegocio().listar() 
                    : productsList = list;

                HiddenColumns();

                if (dgvListado.RowCount > 0)
                    LoadImage(productsList[0].ImagenArt);                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void HiddenColumns()
        {
            dgvListado.Columns["ImagenArt"].Visible = false;
            dgvListado.Columns["Id"].Visible = false;
        }
        private void toolAgregar_Click(object sender, EventArgs e)
        {
            CreateForm form = new CreateForm();
            form.ShowDialog();
            SetGridView(); //se setea aunque no se haya agregado nada, ver
        }
        private void toolEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.RowCount <= 0)
            {
                MessageBox.Show("No hay articulos existentes, agregue un articulo");
                return;
            }

            DeleteForm form = new DeleteForm();
            form.ShowDialog();
            SetGridView();
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            if (dgvListado.RowCount <= 0)
            {
                MessageBox.Show("No hay articulos existentes, agregue un articulo");
                return;
            }

            SearchForm form = new SearchForm();
            form.ShowDialog();
            List<Articulo> newProductsList = form.GetFilteredList();
            SetGridView(newProductsList);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListado.RowCount <= 0)
                {
                    MessageBox.Show("No hay articulos existentes, agregue un articulo");
                    return;
                }

                Articulo selected = (Articulo)dgvListado.CurrentRow.DataBoundItem;
                CreateForm form = new CreateForm(selected);
                form.ShowDialog();
                SetGridView();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
