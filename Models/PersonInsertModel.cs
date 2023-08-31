
using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class PersonInsertModel
    {

        [MaxLength(20, ErrorMessage = "{firstName}, max 20")]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = "{lastName}, max 20")]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "{password} min 10")]
        public string Password { get; set; }
    }
}