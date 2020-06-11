using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class Sku
    {
        public char SkuId { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float FinalPrice { get; set; }
        public float PromoationTotal { get; set; }
    }
}