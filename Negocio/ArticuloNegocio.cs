using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
   public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Codigo, Nombre, A.Descripcion, Precio, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, A.IdMarca, A.IdCategoria, A.Id FROM ARTICULOS AS A, MARCAS as M, CATEGORIAS as C WHERE IdMarca = M.Id and IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArt = (string)datos.Lector["Codigo"];
                    aux.NombreArt = (string)datos.Lector["Nombre"];
                    aux.DescripcionArt = (string)datos.Lector["Descripcion"];
                    aux.PrecioArt = (decimal)datos.Lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.DescripcionMarca = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.DescripcionCategoria = (string)datos.Lector["Categoria"];
                    if(!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenArt = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregar(Articulo nuevoArt)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion, IdMarca, IdCategoria, Precio, ImagenUrl) VALUES ('" + nuevoArt.CodigoArt + "', '" + nuevoArt.NombreArt + "', '" + nuevoArt.DescripcionArt + "', @IdMarca, @IdCategoria," + nuevoArt.PrecioArt + ", '" + nuevoArt.ImagenArt + "' )");
                datos.setearParametro("@IdMarca",nuevoArt.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", nuevoArt.Categoria.IdCategoria);   
                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo mod)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS SET Codigo = @CodigoArt, Nombre = @NombreArt, Descripcion = @DescripcionArt, Precio = @PrecioArt, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenArt where Id = @Id");
                datos.setearParametro("@CodigoArt", mod.CodigoArt);
                datos.setearParametro("@NombreArt", mod.NombreArt);
                datos.setearParametro("@DescripcionArt", mod.DescripcionArt);
                datos.setearParametro("@PrecioArt", mod.PrecioArt);
                datos.setearParametro("@IdMarca", mod.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", mod.Categoria.IdCategoria);
                datos.setearParametro("@ImagenArt", mod.ImagenArt);
                datos.setearParametro("@Id", mod.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool eliminar(string code)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where Codigo = @Codigo");
                datos.setearParametro("@Codigo", code);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                return false; //probar
                throw ex;
            }
        }
    }
}

