using System;
using System.Windows.Forms;
using Negocio;

namespace WinFormApp1
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = txtEliminar.Text; //validar para que sea solo numeros
            ArticleRepository repository = new ArticleRepository();

            try
            {
                if (string.IsNullOrEmpty(code))
                    MessageBox.Show("Debe ingresar un valor");

                if (repository.Delete(code))
                    MessageBox.Show("Articulo eliminado");
                else
                    MessageBox.Show("No existe el Articulo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }
        }
    }
}
