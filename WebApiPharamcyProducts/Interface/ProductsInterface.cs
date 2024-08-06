using WebApiPharamcyProducts.Domains;

namespace WebApiPharamcyProducts.Interface
{
    public interface ProductsInterface
    {
        public void Post(ProductsDomain productsDomain);

        public ProductsDomain GetById(Guid id);

        public List<ProductsDomain> Get();

        public void Delete(Guid id);

        public void Update(ProductsDomain productsDomain, Guid id);

    }
}
