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
    public partial class frmBusqueda : Form
    {
        List<Articulo> listaFiltrada;
        public frmBusqueda()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> ListaArticulos;
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listar();

            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string desc = txtDesc.Text;
            decimal precio = txtPrecio.Value;

            //alternativa, preguntar cuales son los que tienen texto

            /*if (codigo != "")
            {
            }*/

            try
            {
                //combinaciones codigo
                //codigo solo
                if (codigo != "" && nombre == "" && desc == "" && precio == 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.CodigoArt.ToUpper().Contains(codigo.ToUpper()));
                }
                //codigo y nombre
                else if (codigo != "" && nombre != "" && desc == "" && precio == 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.CodigoArt.ToUpper().Contains(codigo.ToUpper()) && x.NombreArt.ToUpper().Contains(nombre.ToUpper()));
                }
                //codigo y desc
                else if (codigo != "" && nombre == "" && desc != "" && precio == 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.NombreArt.ToUpper().Contains(nombre.ToUpper()) && x.DescripcionArt.ToUpper().Contains(desc.ToUpper()));
                }
                //codigo y precio
                else if (codigo != "" && nombre == "" && desc == "" && precio != 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.CodigoArt.ToUpper().Contains(codigo.ToUpper()) && x.PrecioArt.Equals(precio));
                }
                //codigo nombre y descripcion
                else if (codigo != "" && nombre != "" && desc != "" && precio == 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.CodigoArt.ToUpper().Contains(codigo.ToUpper()) && x.NombreArt.ToUpper().Contains(nombre.ToUpper()) && x.DescripcionArt.ToUpper().Contains(desc.ToUpper()));
                }
                //codigo nombre y precio
                else if (codigo != "" && nombre != "" && desc == "" && precio != 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.CodigoArt.ToUpper().Contains(codigo.ToUpper()) && x.NombreArt.ToUpper().Contains(nombre.ToUpper()) && x.PrecioArt.Equals(precio));
                }
                //codigo desc y precio
                else if (codigo != "" && nombre == "" && desc != "" && precio != 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.CodigoArt.ToUpper().Contains(codigo.ToUpper()) && x.DescripcionArt.ToUpper().Contains(desc.ToUpper()) && x.PrecioArt.Equals(precio));
                }
                //codigo nombre desc y precio
                else if (codigo != "" && nombre != "" && desc != "" && precio != 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.CodigoArt.ToUpper().Contains(codigo.ToUpper()) && x.NombreArt.ToUpper().Contains(nombre.ToUpper()) && x.DescripcionArt.ToUpper().Contains(desc.ToUpper()) && x.PrecioArt.Equals(precio));
                }


                //combinaciones nombre
                //nombre
                else if (codigo == "" && nombre != "" && desc == "" && precio == 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.NombreArt.ToUpper().Contains(nombre.ToUpper()));
                }
                //nombre y desc
                else if (codigo == "" && nombre != "" && desc != "" && precio == 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.NombreArt.ToUpper().Contains(nombre.ToUpper()) && x.DescripcionArt.ToUpper().Contains(desc.ToUpper()));
                }
                //nombre desc y precio
                else if (codigo == "" && nombre != "" && desc != "" && precio != 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.NombreArt.ToUpper().Contains(nombre.ToUpper()) && x.DescripcionArt.ToUpper().Contains(desc.ToUpper()) && x.PrecioArt.Equals(precio));
                }


                //combinaciones descripcion
                //solo desc
                else if (codigo == "" && nombre == "" && desc != "" && precio == 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.DescripcionArt.ToUpper().Contains(desc.ToUpper()));
                }
                //desc y precio
                else if (codigo == "" && nombre == "" && desc != "" && precio != 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.DescripcionArt.ToUpper().Contains(desc.ToUpper()) && x.PrecioArt.Equals(precio));
                }


                //combinaciones precio 

                //AGREGAR OPCION DE BUSCAR POR PRECIO MAYOR O MENOR
                //solo precio
                else if (codigo == "" && nombre == "" && desc == "" && precio != 0)
                {
                    listaFiltrada = ListaArticulos.FindAll(x => x.PrecioArt.Equals(precio));
                }


                else //si no ingresa nada la reestablece
                {
                    listaFiltrada = ListaArticulos;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            Close();

        }

        public List<Articulo> getListaFiltrada()
        {
            return listaFiltrada;
        }
    }
}
