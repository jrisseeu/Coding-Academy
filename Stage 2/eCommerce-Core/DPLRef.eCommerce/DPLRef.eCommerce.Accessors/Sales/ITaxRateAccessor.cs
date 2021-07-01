using DPLRef.eCommerce.Common.Contracts;
using DPLRef.eCommerce.Common.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPLRef.eCommerce.Accessors.Sales {
    public interface ITaxRateAccessor : IServiceContractBase {
        decimal Rate(Address address);
    }

}
