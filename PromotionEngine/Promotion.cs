using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
   public class Promotion
    {
        public char SkuId { get; set; }
        public int PromotionPercentage { get; set; }
        public int PromotionQuantity { get; set; }
        public bool IsMutualExclusive { get; set; }
    }
}
