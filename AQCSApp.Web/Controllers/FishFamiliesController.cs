using AQCSApp.Web.Data;
using AQCSApp.Web.Data.Entities;
using AQCSApp.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AQCSApp.Web.Controllers
{
    public class FishFamiliesController : Controller
    {

        public readonly IFishFamilyRepository fishFamilyRepository;
        public readonly IUserHelper userHelper;

        public FishFamiliesController(IFishFamilyRepository fishFamilyRepository, IUserHelper userHelper)
        {
            this.fishFamilyRepository = fishFamilyRepository;
            this.userHelper = userHelper;
        }

        // GET: FishesFamilies
        public IActionResult Index()
        {
            return View(this.fishFamilyRepository.GetAll());
        }

        // GET: FishesFamilies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishesFamily = await this.fishFamilyRepository.GetByIdAsync(id.Value);

            if (fishesFamily == null)
            {
                return NotFound();
            }

            return View(fishesFamily);
        }

        // GET: FishesFamilies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FishesFamilies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FishFamily fishFamily)
        {
            if (ModelState.IsValid)
            {
                //TODO: Cambiarlo por el usuario del login
                fishFamily.User = await this.userHelper.GetUserByEmailAsync("pablomartinezros@gmail.com");
                await this.fishFamilyRepository.CreateAsync(fishFamily);
                return RedirectToAction(nameof(Index));
            }
            return View(fishFamily);
        }

        // GET: FishesFamilies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishfamily = await this.fishFamilyRepository.GetByIdAsync(id.Value);
            if (fishfamily == null)
            {
                return NotFound();
            }
            return View(fishfamily);
        }

        // POST: FishesFamilies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FishFamily fishFamily)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: Cambiarlo por el usuario del login
                    fishFamily.User = await this.userHelper.GetUserByEmailAsync("pablomartinezros@gmail.com");
                    await this.fishFamilyRepository.UpdateAsync(fishFamily);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.fishFamilyRepository.ExistAsync(fishFamily.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fishFamily);
        }

        // GET: FishesFamilies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishFamily = await this.fishFamilyRepository.GetByIdAsync(id.Value);

            if (fishFamily == null)
            {
                return NotFound();
            }

            return View(fishFamily);
        }

        // POST: FishesFamilies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fishFamily = await this.fishFamilyRepository.GetByIdAsync(id);
            await this.fishFamilyRepository.DeleteAsync(fishFamily);
            return RedirectToAction(nameof(Index));
        }

    }
}
