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
    public partial class SearchForm : Form
    {
        List<Articulo> filteredList = null;
        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //string code = txtCodigo.Text;
            string name = txtNombre.Text.ToUpper();
            //string description = txtDesc.Text;
            //decimal price = txtPrecio.Value;

            List<Articulo> list = new ArticuloNegocio().listar();

            try
            {
                if (!string.IsNullOrEmpty(name))
                    filteredList = list.FindAll(a => a.NombreArt.ToUpper().Contains(name));


                ////combinaciones codigo
                ////codigo solo
                //if (code != "" && name == "" && description == "" && price == 0)
                //{
                //    filteredList = list.FindAll(x => x.CodigoArt.ToUpper().Contains(code.ToUpper()));
                //}
                ////codigo y nombre
                //else if (code != "" && name != "" && description == "" && price == 0)
                //{
                //    filteredList = list.FindAll(x => x.CodigoArt.ToUpper().Contains(code.ToUpper()) && x.NombreArt.ToUpper().Contains(name.ToUpper()));
                //}
                ////codigo y desc
                //else if (code != "" && name == "" && description != "" && price == 0)
                //{
                //    filteredList = list.FindAll(x => x.NombreArt.ToUpper().Contains(name.ToUpper()) && x.DescripcionArt.ToUpper().Contains(description.ToUpper()));
                //}
                ////codigo y precio
                //else if (code != "" && name == "" && description == "" && price != 0)
                //{
                //    filteredList = list.FindAll(x => x.CodigoArt.ToUpper().Contains(code.ToUpper()) && x.PrecioArt.Equals(price));
                //}
                ////codigo nombre y descripcion
                //else if (code != "" && name != "" && description != "" && price == 0)
                //{
                //    filteredList = list.FindAll(x => x.CodigoArt.ToUpper().Contains(code.ToUpper()) && x.NombreArt.ToUpper().Contains(name.ToUpper()) && x.DescripcionArt.ToUpper().Contains(description.ToUpper()));
                //}
                ////codigo nombre y precio
                //else if (code != "" && name != "" && description == "" && price != 0)
                //{
                //    filteredList = list.FindAll(x => x.CodigoArt.ToUpper().Contains(code.ToUpper()) && x.NombreArt.ToUpper().Contains(name.ToUpper()) && x.PrecioArt.Equals(price));
                //}
                ////codigo desc y precio
                //else if (code != "" && name == "" && description != "" && price != 0)
                //{
                //    filteredList = list.FindAll(x => x.CodigoArt.ToUpper().Contains(code.ToUpper()) && x.DescripcionArt.ToUpper().Contains(description.ToUpper()) && x.PrecioArt.Equals(price));
                //}
                ////codigo nombre desc y precio
                //else if (code != "" && name != "" && description != "" && price != 0)
                //{
                //    filteredList = list.FindAll(x => x.CodigoArt.ToUpper().Contains(code.ToUpper()) && x.NombreArt.ToUpper().Contains(name.ToUpper()) && x.DescripcionArt.ToUpper().Contains(description.ToUpper()) && x.PrecioArt.Equals(price));
                //}


                ////combinaciones nombre
                ////nombre
                //else if (code == "" && name != "" && description == "" && price == 0)
                //{
                //    filteredList = list.FindAll(x => x.NombreArt.ToUpper().Contains(name.ToUpper()));
                //}
                ////nombre y desc
                //else if (code == "" && name != "" && description != "" && price == 0)
                //{
                //    filteredList = list.FindAll(x => x.NombreArt.ToUpper().Contains(name.ToUpper()) && x.DescripcionArt.ToUpper().Contains(description.ToUpper()));
                //}
                ////nombre desc y precio
                //else if (code == "" && name != "" && description != "" && price != 0)
                //{
                //    filteredList = list.FindAll(x => x.NombreArt.ToUpper().Contains(name.ToUpper()) && x.DescripcionArt.ToUpper().Contains(description.ToUpper()) && x.PrecioArt.Equals(price));
                //}


                ////combinaciones descripcion
                ////solo desc
                //else if (code == "" && name == "" && description != "" && price == 0)
                //{
                //    filteredList = list.FindAll(x => x.DescripcionArt.ToUpper().Contains(description.ToUpper()));
                //}
                ////desc y precio
                //else if (code == "" && name == "" && description != "" && price != 0)
                //{
                //    filteredList = list.FindAll(x => x.DescripcionArt.ToUpper().Contains(description.ToUpper()) && x.PrecioArt.Equals(price));
                //}


                //combinaciones precio 

                //AGREGAR OPCION DE BUSCAR POR PRECIO MAYOR O MENOR
                //solo precio
                //else if (code == "" && name == "" && description == "" && price != 0)
                //{
                //    filteredList = list.FindAll(x => x.PrecioArt.Equals(price));
                //}


                //else //si no ingresa nada la reestablece
                //{
                //    filteredList = list;
                //}
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        public List<Articulo> GetFilteredList()
        {
            return filteredList;
        }
    }
}
