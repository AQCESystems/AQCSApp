using AQCSApp.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace AQCSApp.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class FishesController : Controller
    {
        private readonly IFishRepository fishRepository;
        public FishesController(IFishRepository fishRepository)
        {
            this.fishRepository = fishRepository;
        }

        [HttpGet]
        public IActionResult GetFishes()
        {
            return Ok(this.fishRepository.GetAllWithUsers());
        }
    }
}
