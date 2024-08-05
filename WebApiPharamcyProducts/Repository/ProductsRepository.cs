using WebApiPharamcyProducts.Context;
using WebApiPharamcyProducts.Domains;
using WebApiPharamcyProducts.Interface;

namespace WebApiPharamcyProducts.Repository
{
    public class ProductsRepository : ProductsInterface
    {

        private readonly PharmacyContext _pharmacyContext;

        public ProductsRepository()
        {
            _pharmacyContext = new PharmacyContext();
        }


        public void Post(ProductsDomain productsDomain)
        {
            try
            {
                _pharmacyContext.ProductsDomain.Add(productsDomain);
                _pharmacyContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public ProductsDomain GetById(Guid id)
        {
            try
            {
                ProductsDomain products = _pharmacyContext.ProductsDomain
                    .Select(u => new ProductsDomain
                    {
                        IdProduct = u.IdProduct,
                        Name = u.Name,
                        Price = u.Price
                    }).FirstOrDefault(u => u.IdProduct == id)!;
                    
                if (products != null)
                {
                    return products;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ProductsDomain> Get()
        {
            return _pharmacyContext.ProductsDomain.ToList();
        }

        public void Delete(Guid id)
        {
            ProductsDomain productsBuscar = _pharmacyContext.ProductsDomain.Find(id);
            _pharmacyContext.ProductsDomain.Remove(productsBuscar);
            _pharmacyContext.SaveChanges();
        }
    }
}
