

using System.ComponentModel.DataAnnotations;

namespace meuapp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio")]
        [MaxLength(60, ErrorMessage = "Deve te 60 caracteres")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Categoria invalida")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}