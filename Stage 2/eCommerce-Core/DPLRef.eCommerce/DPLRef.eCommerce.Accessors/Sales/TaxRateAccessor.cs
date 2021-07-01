

using DPLRef.eCommerce.Common.Contracts;

namespace DPLRef.eCommerce.Accessors.Sales
{
    class TaxRateAccessor : AccessorBase, ITaxRateAccessor
    {
        public decimal Rate(Address address) { 

            USATaxer.USATaxerLib taxer = new USATaxer.USATaxerLib();
            taxer.Init();
            return taxer.Rate(address.Postal);
        }

    }
}
