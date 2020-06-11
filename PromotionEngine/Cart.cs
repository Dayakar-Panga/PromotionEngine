using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class Cart
    {
        public IList<Sku> Skus { get; set; }

        public IList<Promotion> Promotions { get; set; }

        public float GrandTotal { get; set; }

        public float GrandPromotionTotal { get; set; }

        public float OrderTotal { get; set; }
    }
}
