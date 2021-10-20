using AQCSApp.Web.Data;
using AQCSApp.Web.Data.Entities;
using AQCSApp.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AQCSApp.Web.Controllers
{
    public class FishesController : Controller
    {
        public readonly IFishRepository fishRepository;
        public readonly IUserHelper userHelper;

        public FishesController(IFishRepository fishRepository, IUserHelper userHelper)
        {
            this.fishRepository = fishRepository;
            this.userHelper = userHelper;
        }

        // GET: FishesFamilies
        public IActionResult Index()
        {
            return View(this.fishRepository.GetAll());
        }

        // GET: FishesFamilies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishesFamily = await this.fishRepository.GetByIdAsync(id.Value);

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
        public async Task<IActionResult> Create(Fish fish)
        {
            if (ModelState.IsValid)
            {
                //TODO: Cambiarlo por el usuario del login
                fish.User = await this.userHelper.GetUserByEmailAsync("pablomartinezros@gmail.com");
                await this.fishRepository.CreateAsync(fish);
                return RedirectToAction(nameof(Index));
            }
            return View(fish);
        }

        // GET: FishesFamilies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishfamily = await this.fishRepository.GetByIdAsync(id.Value);
            if (fishfamily == null)
            {
                return NotFound();
            }
            return View(fishfamily);
        }

        // POST: FishesFamilies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fish fish)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: Cambiarlo por el usuario del login
                    fish.User = await this.userHelper.GetUserByEmailAsync("pablomartinezros@gmail.com");
                    await this.fishRepository.UpdateAsync(fish);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.fishRepository.ExistAsync(fish.Id))
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
            return View(fish);
        }

        // GET: FishesFamilies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishFamily = await this.fishRepository.GetByIdAsync(id.Value);

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
            var fishFamily = await this.fishRepository.GetByIdAsync(id);
            await this.fishRepository.DeleteAsync(fishFamily);
            return RedirectToAction(nameof(Index));
        }

    }
}
