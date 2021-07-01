using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Common.Contracts;
using DPLRef.eCommerce.Contracts.WebStore.Catalog;
using DPLRef.eCommerce.Engines;
using DPLRef.eCommerce.Managers;
using DPLRef.eCommerce.Utilities;
using Microsoft.AspNetCore.Mvc;


namespace WebStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        AmbientContext Context => new AmbientContext();
        UtilityFactory UtilityFactory => new UtilityFactory(Context);
        AccessorFactory AccessorFactory => new AccessorFactory(Context, UtilityFactory);
        EngineFactory EngineFactory => new EngineFactory(Context, AccessorFactory, UtilityFactory);
        ManagerFactory ManagerFactory => new ManagerFactory(Context, EngineFactory, AccessorFactory, UtilityFactory);

        IWebStoreCatalogManager CatalogManager => ManagerFactory.CreateManager<IWebStoreCatalogManager>();

        // GET api/<CatalogController>/1
        [HttpGet("{catalogId}")]
        public WebStoreCatalogResponse Get(int catalogId)
        {
            return CatalogManager.ShowCatalog(catalogId);
        }


        // GET api/<CatalogController>/1/1
        [HttpGet("{catalogId}/{productId}")]
        public WebStoreProductResponse Get(int catalogId, int productId)
        {
            return CatalogManager.ShowProduct(catalogId, productId);
        }
    }
}