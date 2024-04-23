// Define pricing rules
using SupermarketCheckout;

var pricingRules = new List<PricingRule>
{
    new PricingRule("A", 50, new SpecialPrice(3, 130)),
    new PricingRule("B", 30, new SpecialPrice(2, 45)),
    new PricingRule("C", 20, null),
    new PricingRule("D", 15, null)
};

// Create a new checkout instance
var checkout = new Checkout(pricingRules);

// Scan items
checkout.Scan("A");
checkout.Scan("A");
checkout.Scan("B");
checkout.Scan("A");
checkout.Scan("C");

// Get the total price
int totalPrice = checkout.GetTotalPrice();
Console.WriteLine($"Total price: {totalPrice}");