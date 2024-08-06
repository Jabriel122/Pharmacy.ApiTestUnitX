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
        [Theory]
        [MemberData(new ProductsDomain { IdProduct=Guid.NewGuid(), Name="Dipirona" , Price=15})]
        [InlineData("garibaldo@gmail.com")]
        [InlineData("garibaldo@gmail.com")]

        public void Post(ProductsDomain products)
        {
            //Arrange
            ProductsDomain product = new ProductsDomain { IdProduct = Guid.NewGuid(), Name = "Diporona", Price = 14 };
            
            var productList = new List<ProductsDomain>();
            //Cria um boj de simulacao do tipo IProductsRepository
            var mockRepository = new Mock<ProductsInterface>();

            //Configura o metodo Post para retornar a lista de produtos "mock"
            mockRepository.Setup(x => x.Post(product)).Callback<ProductsDomain>(x => productList.Add(product));

            //Act
            //Chama o metodo Post() e armazena o resultado em result
            mockRepository.Object.Post(product);
            //Assert
            Assert.Contains(product, productList);

        }
        //GetById
        //Delete
        //Desafio : Update
    }
}