using AQCSApp.Web.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AQCSApp.Web.Controllers.API
{
    [Route("api/[Controller]")]

    //Esta línea indica que tienes que estar autorizado para acceder a las familias.
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

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