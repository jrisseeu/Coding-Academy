﻿using DPLRef.eCommerce.Common.Shared;
using DPLRef.eCommerce.Utilities;

namespace DPLRef.eCommerce.Accessors {
    abstract class AccessorBase : ServiceContractBase {
        public UtilityFactory UtilityFactory { get; set; }
    }
}