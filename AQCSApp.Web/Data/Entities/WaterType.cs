using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AQCSApp.Web.Data.Entities
{
    public class WaterType : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "La longitud Máxima del campo {0} es de {1} caracteres")]
        [Required]
        public string Name { get; set; }
        public User User { get; set; }
    }
}
