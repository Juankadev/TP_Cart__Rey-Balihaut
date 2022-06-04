using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo { 

        public int Id { get; set; }
    
        [DisplayName("Código")]
        public String CodigoArt { get; set; }
        [DisplayName("Nombre")]
        public String NombreArt { get; set; }
        [DisplayName("Descripción")]
        public String DescripcionArt { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public String ImagenArt  { get; set; }
        [DisplayName("Precio")]
        public Decimal PrecioArt { get; set; }





    }
}
