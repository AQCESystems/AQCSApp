using System.ComponentModel.DataAnnotations;

namespace AQCSApp.Web.Data.Entities
{
    public class Province : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "La longitud Máxima del campo {0} es de {1} caracteres")]
        [Required]
        public string Name { get; set; }

        public Country Country { get; set; }
        public User User { get; set; }
    }
}
