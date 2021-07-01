using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Accessors.Sales;
using DPLRef.eCommerce.Common.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DPLRef.eCommerce.Tests.AccessorTests {

    [TestClass]
    public class TaxAccessorTests
    {
        private ITaxRateAccessor CreateAccessor()
        {
            var context = new Common.Contracts.AmbientContext();
            var factory = new AccessorFactory(context,  new Utilities.UtilityFactory(context));
            return factory.CreateAccessor<ITaxRateAccessor>();
        }

        [TestMethod]
        [TestCategory("Accessor Tests")]
        public void TaxAccessor_LincolnNe()  {
            var accessor = CreateAccessor();
            var lincoln = new Address()
            {
                Postal = "68512"
            };

            var rate = accessor.Rate(lincoln);
            Assert.IsNotNull(rate);
            Assert.AreEqual(0.072500m, rate);
        }

        [TestMethod]
        [TestCategory("Accessor Tests")]
        public void TaxAccessor_NotInList()
        {
            var accessor = CreateAccessor();
            var sunPrairie = new Address() {
                Postal = "53590"
            };

            var rate = accessor.Rate(sunPrairie);
            Assert.IsNotNull(rate);
            Assert.AreEqual(0.00m, rate);
        }

    }
}
