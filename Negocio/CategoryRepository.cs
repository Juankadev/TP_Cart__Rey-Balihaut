using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CategoryRepository
    {
        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select Id, Descripcion FROM CATEGORIAS");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Category category = new Category();
                    category.Id = (int)data.Reader["Id"];
                    category.Description = (string)data.Reader["Descripcion"];

                    categories.Add(category);
                }
                return categories;
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
