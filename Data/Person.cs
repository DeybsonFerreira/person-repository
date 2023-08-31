using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Data
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "{firstName}, max 20")]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = "{lastName}, max 20")]
        public string LastName { get; set; }

        public int? LoginId { get; set; }
        public Login Login { get; set; }

    }
}