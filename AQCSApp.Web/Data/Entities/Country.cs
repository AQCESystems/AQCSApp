using System.ComponentModel.DataAnnotations;

namespace AQCSApp.Web.Data.Entities
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Required]
        [Display(Name = "Country")]
        public string Name { get; set; }

        public User User { get; set; }
    }
}
