using System.ComponentModel.DataAnnotations;

namespace AQCSApp.Web.Data.Entities
{
    public class FishFamily : ModelBase
    {
        [MaxLength(50,ErrorMessage ="La longitud Máxima del campo {0} es de {1} caracteres")]
        [Required]
        public string Name { get; set; }
    }
}
