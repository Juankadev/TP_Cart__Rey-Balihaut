using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
   public class ArticleRepository
    {
        public List<Article> GetAll()
        {
            List<Article> articles = new List<Article>();
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select Codigo, Nombre, A.Descripcion, Precio, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, A.IdMarca, A.IdCategoria, A.Id FROM ARTICULOS AS A, MARCAS as M, CATEGORIAS as C WHERE IdMarca = M.Id and IdCategoria = C.Id");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Article article = new Article();
                    article.Id = (int)data.Reader["Id"];
                    article.Code = (string)data.Reader["Codigo"];
                    article.Name = (string)data.Reader["Nombre"];
                    article.Description = (string)data.Reader["Descripcion"];
                    article.Price = (decimal)data.Reader["Precio"];
                    article.Brand = new Brand();
                    article.Brand.Id = (int)data.Reader["IdMarca"];
                    article.Brand.Description = (string)data.Reader["Marca"];
                    article.Category = new Category();
                    article.Category.Id = (int)data.Reader["IdCategoria"];
                    article.Category.Description = (string)data.Reader["Categoria"];
                    if(!(data.Reader["ImagenUrl"] is DBNull))
                        article.Image = (string)data.Reader["ImagenUrl"];

                    articles.Add(article);
                }
                return articles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        public List<Article> GetAllByCategory(int categoryId)
        {
            List<Article> articles = new List<Article>();
            DataAccess data = new DataAccess();

            try
            {
                //datos.setearConsulta("select Codigo, Nombre, A.Descripcion, Precio, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, A.IdMarca, A.IdCategoria, A.Id FROM ARTICULOS AS A, MARCAS as M, CATEGORIAS as C WHERE IdMarca = M.Id and IdCategoria = C.Id");
                data.SetQuery("select * from ARTICULOS where IdCategoria=@IDbuscado");
                data.AddParameter("@IDbuscado", categoryId);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Article aux = new Article();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Code = (string)data.Reader["Codigo"];
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.Description = (string)data.Reader["Descripcion"];
                    aux.Price = (decimal)data.Reader["Precio"];
                    aux.Brand = new Brand();
                    aux.Brand.Id = (int)data.Reader["IdMarca"];
                    //aux.Marca.DescripcionMarca = (string)datos.Lector["Marca"];
                    aux.Category = new Category();
                    aux.Category.Id = (int)data.Reader["IdCategoria"];
                    //aux.Categoria.DescripcionCategoria = (string)datos.Lector["Categoria"];
                    if (!(data.Reader["ImagenUrl"] is DBNull))
                        aux.Image = (string)data.Reader["ImagenUrl"];

                    articles.Add(aux);
                }
                return articles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        public List<Article> GetAllByBrand(int brandId)
        {
            List<Article> articles = new List<Article>();
            DataAccess data = new DataAccess();

            try
            {
                //datos.setearConsulta("select Codigo, Nombre, A.Descripcion, Precio, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, A.IdMarca, A.IdCategoria, A.Id FROM ARTICULOS AS A, MARCAS as M, CATEGORIAS as C WHERE IdMarca = M.Id and IdCategoria = C.Id");
                data.SetQuery("select * from ARTICULOS where IdMarca=@IDbuscado");
                data.AddParameter("@IDbuscado", brandId);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Article aux = new Article();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Code = (string)data.Reader["Codigo"];
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.Description = (string)data.Reader["Descripcion"];
                    aux.Price = (decimal)data.Reader["Precio"];
                    aux.Brand = new Brand();
                    aux.Brand.Id = (int)data.Reader["IdMarca"];
                    //aux.Marca.DescripcionMarca = (string)datos.Lector["Marca"];
                    aux.Category = new Category();
                    aux.Category.Id = (int)data.Reader["IdCategoria"];
                    //aux.Categoria.DescripcionCategoria = (string)datos.Lector["Categoria"];
                    if (!(data.Reader["ImagenUrl"] is DBNull))
                        aux.Image = (string)data.Reader["ImagenUrl"];

                    articles.Add(aux);
                }
                return articles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        public void Add(Article article)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.SetQuery("INSERT INTO ARTICULOS " +
                    "(Codigo,Nombre,Descripcion, IdMarca, IdCategoria,ImagenUrl, Precio) " +
                    "VALUES (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenUrl,@Precio)");

                data.AddParameter("@Codigo", article.Code);
                data.AddParameter("@Nombre", article.Name);
                data.AddParameter("@Descripcion", article.Description);                
                data.AddParameter("@IdMarca",article.Brand.Id);
                data.AddParameter("@IdCategoria", article.Category.Id);
                data.AddParameter("@Precio", article.Price);
                data.AddParameter("@ImagenUrl", article.Image);
                data.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        public void Modify(Article article)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.SetQuery("update ARTICULOS SET Codigo = @CodigoArt, Nombre = @NombreArt, Descripcion = @DescripcionArt, Precio = @PrecioArt, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenArt where Id = @Id");
                data.AddParameter("@CodigoArt", article.Code);
                data.AddParameter("@NombreArt", article.Name);
                data.AddParameter("@DescripcionArt", article.Description);
                data.AddParameter("@PrecioArt", article.Price);
                data.AddParameter("@IdMarca", article.Brand.Id);
                data.AddParameter("@IdCategoria", article.Category.Id);
                data.AddParameter("@ImagenArt", article.Image);
                data.AddParameter("@Id", article.Id);

                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        public bool Delete(string code)
        {
            try
            {
                DataAccess data = new DataAccess();
                data.SetQuery("delete from ARTICULOS where Codigo = @Codigo");
                data.AddParameter("@Codigo", code);
                data.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Article GetById(int id)
        {
            Article article = new Article();
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select Id,Codigo,Nombre,Precio,ImagenUrl from ARTICULOS where Id = @Id");
                data.AddParameter("@Id", id);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    article.Id = (int)data.Reader["Id"];
                    article.Code = (string)data.Reader["Codigo"];
                    article.Name = (string)data.Reader["Nombre"];
                    article.Price = (decimal)data.Reader["Precio"];
                    if (!(data.Reader["ImagenUrl"] is DBNull))
                        article.Image = (string)data.Reader["ImagenUrl"];
                }
                return article;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
    }
}

