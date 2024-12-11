
using System.ComponentModel.DataAnnotations;

namespace meuapp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio")]
        [MaxLength(20, ErrorMessage = "deve conter 20 caracteres")]
        public string Username { get; set; }
        public string Password { get; set; }
       
       public string Role  { get; set; }
    
    }
}