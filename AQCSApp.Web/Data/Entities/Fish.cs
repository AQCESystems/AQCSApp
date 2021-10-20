using System.ComponentModel.DataAnnotations;

namespace AQCSApp.Web.Data.Entities
{
    public class Fish : IEntity
    {

        public int Id { get; set; }

        [Display( Name = "Common Name")]
        [MaxLength(50, ErrorMessage = "La longitud Máxima del campo {0} es de {1} caracteres")]
        [Required]
        public string Name { get; set; }

        public FishFamily Family { get; set; }

        public User User { get; set; }
    }
}
