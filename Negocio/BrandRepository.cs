using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class BrandRepository
    {
        public List<Brand> GetAll()
        {
            List<Brand> brands = new List<Brand>();
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select Id, Descripcion FROM MARCAS");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Brand brand = new Brand();
                    brand.Id = (int)data.Reader["Id"];
                    brand.Description = (string)data.Reader["Descripcion"];

                    brands.Add(brand);
                }

                return brands;
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
