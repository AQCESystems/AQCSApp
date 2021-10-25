using AQCSApp.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AQCSApp.Web.Models
{
    public class FishViewModel : Fish
    {

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
              
    }
}
