using System.Linq;

namespace PromotionEngine
{
    public class OrderCalculator
    {
        public void CalculateTotal(Cart checkedoutCart)
        {
            foreach (var sku in checkedoutCart.Skus)
            {
                if (checkedoutCart.Promotions != null)
                    foreach (var promotion in checkedoutCart.Promotions)
                    {
                        if (sku.SkuId == promotion.SkuId && promotion.IsMutualExclusive == false)
                            CalculatePromotionTotal(sku, promotion);
                    }
                else
                    SkuFinalPrice(sku);
            }

            checkedoutCart.GrandTotal = checkedoutCart.Skus.Sum(s => s.FinalPrice);
            checkedoutCart.GrandPromotionTotal = checkedoutCart.Skus.Sum(s => s.PromoationTotal);

            checkedoutCart.OrderTotal = checkedoutCart.GrandTotal - checkedoutCart.GrandPromotionTotal;
        }


        private void SkuFinalPrice(Sku selectedSku)
        {
            selectedSku.FinalPrice = selectedSku.Quantity * selectedSku.UnitPrice;
        }

        private void CalculatePromotionTotal(Sku selectedSku, Promotion activePromotion)
        {
            int quotient = selectedSku.Quantity / activePromotion.PromotionQuantity;
            if (quotient > 0)
            {
                selectedSku.PromoationTotal = quotient * (activePromotion.PromotionPercentage * ((selectedSku.UnitPrice * activePromotion.PromotionQuantity) / 100));
            }
            selectedSku.FinalPrice = (selectedSku.UnitPrice * selectedSku.Quantity);
        }
    }
}
