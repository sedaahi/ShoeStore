 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Product : BaseEntity
    {
        //Id zaten baseEntity'de var!
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int CategoryId { get; set; } // Bir productın Categorisi olur
        public Category Category { get; set; }
        public int BrandId { get; set; } // Bir productın Markası olur
        public Brand Brand { get; set; }


    }
}
