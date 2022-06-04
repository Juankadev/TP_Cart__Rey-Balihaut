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
    public partial class frmEliminar : Form
    {
        public frmEliminar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //btnEliminar
        {
            ArticuloNegocio negocio= new ArticuloNegocio();
            string codigo;
            try
            {
                codigo = txtEliminar.Text; //validar para que sea solo numeros
                if(codigo != "")
                {
                    bool existe = negocio.eliminar(codigo);

                    if(existe==true)
                    {
                        MessageBox.Show("Articulo eliminado");
                    }
                    else
                    {
                        MessageBox.Show("No existe el Articulo");
                    }
                }

                else
                {
                    MessageBox.Show("Debe ingresar un valor");
                }

                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
