using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class OrderItemContentComboBoxData
    {
        public List<Buyer> buyers { get; private set; } = new List<Buyer>();
        public List<Brand> brands { get; private set; } = new List<Brand>();
        public List<TeaProduct> teaProducts { get; private set; } = new List<TeaProduct>();
        public List<TeabagMaterial> teabagMaterials { get; private set; } = new List<TeabagMaterial>();

        public OrderItemContentComboBoxData(List<Buyer> buyers, List<Brand> brands, List<TeaProduct> teaProducts, List<TeabagMaterial> teabagMaterials)
        {
            this.buyers = buyers;
            this.brands = brands;
            this.teaProducts = teaProducts;
            this.teabagMaterials = teabagMaterials;
        }
    }
}
