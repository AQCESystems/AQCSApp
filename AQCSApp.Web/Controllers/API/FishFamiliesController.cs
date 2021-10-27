using AQCSApp.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace AQCSApp.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class FishFamiliesController : Controller
    {
        private readonly IFishFamilyRepository fishFamilyRepository;
        public FishFamiliesController(IFishFamilyRepository fishFamilyRepository)
        {
            this.fishFamilyRepository = fishFamilyRepository;
        }

        [HttpGet]
        public IActionResult GetFishFamilies()
        {
            return Ok(this.fishFamilyRepository.GetAllWithUsers());
        }
    }
}