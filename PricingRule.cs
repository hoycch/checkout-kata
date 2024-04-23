using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout
{
    public class PricingRule
    {
        public string SKU { get; }
        public int UnitPrice { get; }
        public SpecialPrice? SpecialPrice { get; }

        public PricingRule(string sku, int unitPrice, SpecialPrice? specialPrice = null)
        {
            SKU = sku;
            UnitPrice = unitPrice;
            SpecialPrice = specialPrice;
        }
    }
}
