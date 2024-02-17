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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = txtEliminar.Text; //validar para que sea solo numeros
            ArticuloNegocio repository = new ArticuloNegocio();

            try
            {
                if (string.IsNullOrEmpty(code))
                    MessageBox.Show("Debe ingresar un valor");

                if (repository.eliminar(code))
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
