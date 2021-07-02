using DPLRef.eCommerce.Common.Shared;
using DPLRef.eCommerce.Accessors.DataTransferObjects;
using System.Threading.Tasks;

// Cencept : Accessor
// Sub System : Catalog
namespace DPLRef.eCommerce.Accessors.Catalog
{
    public interface ICatalogAccessor : IServiceContractBase
    {
        WebStoreCatalog Find(int catalogId);
        Task<WebStoreCatalog> FindAsync(int catalogId);

        WebStoreCatalog SaveCatalog(WebStoreCatalog catalog);

        void DeleteCatalog(int id);

        WebStoreCatalog[] FindAllSellerCatalogs();

        Product[] FindAllProductsForCatalog(int catalogId);

        Task<Product[]> FindAllProductsForCatalogAsync(int catalogId);

        Product FindProduct(int id);

        Product SaveProduct(int catalogId, Product product);

        void DeleteProduct(int catalogId, int id);
    }
}
