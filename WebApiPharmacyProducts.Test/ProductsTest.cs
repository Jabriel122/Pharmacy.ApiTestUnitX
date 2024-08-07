using Moq;
using WebApiPharamcyProducts.Domains;
using WebApiPharamcyProducts.Interface;
using WebApiPharamcyProducts.Repository;

namespace WebApiPharmacyProducts.Test
{
    public class ProductsTest
    {
        [Fact]
        public void Get()
        {
            //Arrange : Cenario

            //Lista de produtos
            var products = new List<ProductsDomain>
            {
                new ProductsDomain {IdProduct = Guid.NewGuid(), Name="Produto 1", Price=10},
                new ProductsDomain {IdProduct = Guid.NewGuid(), Name="Produto 2", Price=20},
                new ProductsDomain {IdProduct = Guid.NewGuid(), Name="Produto 3", Price=30},
            };

            //Cria um boj de simulacao do tipo IProductsRepository
            var mockRepository = new Mock<ProductsInterface>();

            //Configura o metodo Get para retornar a lista de produtos "mock"
            mockRepository.Setup(x => x.Get()).Returns(products);


            //Act : Agir
            //Chama o metodo Get() e armazena o resultado em result
            var result = mockRepository.Object.Get();


            //Assert : Provar

            //Prova se o resultado esperado e igual ao resultado obtido atraves da busca
            Assert.Equal(3, result.Count);


        }


        //Post
        [Fact]
        public void Post()
        {
            ProductsDomain product = new ProductsDomain { IdProduct = Guid.NewGuid(), Price = 10, Name = "Kiwi" };
            var productList = new List<ProductsDomain>();

            var mockRepository = new Mock<ProductsInterface>();

            mockRepository.Setup(x => x.Post(product)).Callback<ProductsDomain>(x => productList.Add(product));

            mockRepository.Object.Post(product);

            Assert.Contains(product, productList);

            //Desafio : Update
        }
        //GetById
        [Fact]
        public void GetById()
        {
            //Arrange : Cenario

            //Lista de produtos
            var products = new List<ProductsDomain>
            {
                new ProductsDomain {IdProduct = Guid.NewGuid(), Name="Produto 1", Price=10},
                new ProductsDomain {IdProduct = Guid.NewGuid(), Name="Produto 2", Price=20},
                new ProductsDomain {IdProduct = Guid.NewGuid(), Name="Produto 3", Price=30},
            };

            //Cria um boj de simulacao do tipo IProductsRepository
            var mockRepository = new Mock<ProductsInterface>();

            //Configura o metodo GetById para retornar o produto "mock"
            mockRepository.Setup(x => x.GetById(products[0].IdProduct)).Returns(products[0]);

            //Act : Agir

            //Chama o metodo GetById() e armazena o resultado em result
            var result = mockRepository.Object.GetById(products[0].IdProduct);

            //Assert : Provar

            //Prova se o resultado esperado e igual ao resultado obtido atraves da busca
            Assert.Equal(products[0], result);
        }

        //Delete
        [Fact]
        public void Delete()
        {
            //Arrange : Cenario

            //Lista de produtos
            var products = new List<ProductsDomain>
            {
                new ProductsDomain {IdProduct = Guid.NewGuid(), Name="Produto 1", Price=10},
                new ProductsDomain {IdProduct = Guid.NewGuid(), Name="Produto 2", Price=20},
                new ProductsDomain {IdProduct = Guid.NewGuid(), Name="Produto 3", Price=30},
            };

            //Cria um boj de simulacao do tipo IProductsRepository
            var mockRepository = new Mock<ProductsInterface>();
            mockRepository.Setup(x => x.Get()).Returns(products);

            //Act : Agir
            mockRepository.Object.Delete(products[2].IdProduct);
            products.RemoveAt(2);

            mockRepository.Setup(x => x.Get()).Returns(products);


            //Chama o metodo GetAll() e armazena o resultado em result
            var result = mockRepository.Object.Get();

            //Assert : Provar

            //Prova se o resultado esperado e igual ao resultado obtido atraves da busca
            Assert.Equal(2, result.Count);
        }
        //Desafio : Update

    }
}