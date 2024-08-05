using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPharamcyProducts.Domains
{
    [Table(nameof(ProductsDomain))]
    public class ProductsDomain
    {
        [Key]
        public Guid IdProduct { get; set; } = Guid.NewGuid();   

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome de Produto Obrigatório")]
        public string Name { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]
        [Required(ErrorMessage ="Preço do produto Obrigatório")]
        public decimal Price { get; set; }

    }
}
