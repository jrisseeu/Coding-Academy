using DPLRef.eCommerce.Accessors.Catalog;
using DPLRef.eCommerce.Accessors.Sales;
using DPLRef.eCommerce.Contracts.WebStore.Sales;
using System;

namespace DPLRef.eCommerce.Engines.Sales
{
    class TaxCalculationEngine : EngineBase, ITaxCalculationEngine
    {
        public override string TestMe(string input)
        {
            input = base.TestMe(input);
            return input;
        }

        public WebStoreCart CalculateCartTax(WebStoreCart cart) {

            if (cart != null && cart.BillingAddress != null && !string.IsNullOrWhiteSpace(cart.BillingAddress.Postal)) {
                var taxRate = AccessorFactory.CreateAccessor<ITaxRateAccessor>().Rate(cart.BillingAddress);

                foreach (var item in cart.CartItems) {

                    bool download = AccessorFactory.CreateAccessor<ICatalogAccessor>().FindProduct(item.ProductId).IsDownloadable;

                    if (!download) {
                        cart.TaxAmount += Math.Round(item.ExtendedPrice * taxRate, 2);
                    } else {
                        cart.TaxAmount += Decimal.Zero;
                    }
                }
            }
            // update the cart total with the tax amount
            cart.Total += Math.Round(cart.TaxAmount, 2);

            return cart;
        }
    }
}
