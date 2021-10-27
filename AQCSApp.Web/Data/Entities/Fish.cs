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

        [Required]
        public FishGenus FishGenus { get; set; }

         public string ImageUrl { get; set; }

        public User User { get; set; }

        public string ImageFullPath
        { 
            get
            {
                if(string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }

                return $"http://azurexxxxxxxx{this.ImageUrl.Substring(1)}";

            }
        }
    }
}
