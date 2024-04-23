using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout
{
    public class Checkout : ICheckout
    {
        private readonly List<PricingRule> _pricingRules;
        private readonly Basket _basket;

        public Checkout(IEnumerable<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules.ToList();
            _basket = new Basket();
        }

        public void Scan(string item)
        {
            _basket.AddItem(item);
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in _basket.GetItems())
            {
                var pricingRule = _pricingRules.FirstOrDefault(r => r.SKU == item.Key);

                if (pricingRule == null)
                {
                    throw new NullReferenceException($"Pricing rule not found for item '{item.Key}'");
                }

                int quantityWithoutSpecialPrice = item.Value;
                int quantityWithSpecialPrice = 0;

                if (pricingRule.SpecialPrice != null)
                {
                    quantityWithSpecialPrice = item.Value / pricingRule.SpecialPrice.Quantity;
                    quantityWithoutSpecialPrice = item.Value % pricingRule.SpecialPrice.Quantity;
                    totalPrice += quantityWithSpecialPrice * pricingRule.SpecialPrice.Price;
                }
                totalPrice += quantityWithoutSpecialPrice * pricingRule.UnitPrice;
            }

            return totalPrice;
        }
    }
}
