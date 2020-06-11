using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using System.Collections.Generic;

namespace PromotionEngineTest
{
    [TestClass]
    public class OrderCalculatorTest
    {
        [TestMethod]
        public void CalculateOrder_WithOut_Promotion()
        {
            ///Arrange
            List<Sku> selectedSkus = new List<Sku>
            {
                new Sku{ SkuId='A', UnitPrice=50, Quantity=3},
                new Sku{ SkuId='B', UnitPrice=30, Quantity=3},
                new Sku{ SkuId='C', UnitPrice=20, Quantity=2},
                new Sku{ SkuId='D', UnitPrice=15, Quantity=2}
            };

            Cart checkoutCart = new Cart { Skus = selectedSkus };
            OrderCalculator orderCalculator = new OrderCalculator();

            ///Act
            orderCalculator.CalculateTotal(checkoutCart);

            ///Assert
            Assert.IsTrue(checkoutCart.OrderTotal.ToString().Equals("310"));
        }


        [TestMethod]
        public void CalculateOrder_With_Promotion_Without_Quotient()
        {
            ///Arrange
            List<Sku> selectedSkus = new List<Sku>
            {
                new Sku{ SkuId='A', UnitPrice=50, Quantity=3},
                new Sku{ SkuId='B', UnitPrice=30, Quantity=2},
                new Sku{ SkuId='C', UnitPrice=20, Quantity=1},
                new Sku{ SkuId='D', UnitPrice=15, Quantity=1}
            };

            List<Promotion> activePromotions = new List<Promotion>
            {
               new Promotion{SkuId='A',  IsMutualExclusive=false, PromotionPercentage=10, PromotionQuantity=3},
               new Promotion{SkuId='B', IsMutualExclusive=false, PromotionPercentage=5, PromotionQuantity=2},
               new Promotion{SkuId='C', IsMutualExclusive=false, PromotionPercentage=2, PromotionQuantity=1},
               new Promotion{SkuId='D', IsMutualExclusive=false, PromotionPercentage=0, PromotionQuantity=1}
            };

            Cart checkoutCart = new Cart { Skus = selectedSkus, Promotions = activePromotions };
            OrderCalculator orderCalculator = new OrderCalculator();

            ///Act
            orderCalculator.CalculateTotal(checkoutCart);

            ///Assert
            Assert.AreEqual(checkoutCart.GrandPromotionTotal.ToString(), "18.4");
            Assert.AreEqual(checkoutCart.GrandTotal.ToString(), "245");
            Assert.AreEqual(checkoutCart.OrderTotal.ToString(), "226.6");
        }


        [TestMethod]
        public void CalculateOrder_With_Promotion_With_Quotient()
        {
            ///Arrange
            List<Sku> selectedSkus = new List<Sku>
            {
                new Sku{ SkuId='A', UnitPrice=50, Quantity=10},
                new Sku{ SkuId='B', UnitPrice=30, Quantity=4},
                new Sku{ SkuId='C', UnitPrice=20, Quantity=13},
                new Sku{ SkuId='D', UnitPrice=15, Quantity=1}
            };

            List<Promotion> activePromotions = new List<Promotion>
            {
               new Promotion{SkuId='A',  IsMutualExclusive=false, PromotionPercentage=13, PromotionQuantity=3},
               new Promotion{SkuId='B', IsMutualExclusive=false, PromotionPercentage=4, PromotionQuantity=2},
               new Promotion{SkuId='C', IsMutualExclusive=false, PromotionPercentage=20, PromotionQuantity=10},
               new Promotion{SkuId='D', IsMutualExclusive=false, PromotionPercentage=0, PromotionQuantity=1}
            };

            Cart checkoutCart = new Cart { Skus = selectedSkus, Promotions = activePromotions };
            OrderCalculator orderCalculator = new OrderCalculator();

            ///Act
            orderCalculator.CalculateTotal(checkoutCart);

            ///Assert
            Assert.AreEqual(checkoutCart.GrandPromotionTotal.ToString(), "103.3");
            Assert.AreEqual(checkoutCart.GrandTotal.ToString(), "895");
            Assert.AreEqual(checkoutCart.OrderTotal.ToString(), "791.7");
        }
    }
}
