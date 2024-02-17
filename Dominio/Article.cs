using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Article { 

        public int Id { get; set; }
    
        [DisplayName("Código")]
        public String Code { get; set; }

        [DisplayName("Nombre")]
        public String Name { get; set; }

        [DisplayName("Descripción")]
        public String Description { get; set; }

        public Brand Brand { get; set; }

        public Category Category { get; set; }

        public String Image  { get; set; }

        [DisplayName("Precio")]
        public Decimal Price { get; set; }
    }
}
