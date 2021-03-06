using AQCSApp.Web.Data;
using AQCSApp.Web.Data.Entities;
using AQCSApp.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AQCSApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    
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
                return new NotFoundViewResult("ProductNotFound");
            }

            var fishesFamily = await this.fishFamilyRepository.GetByIdAsync(id.Value);

            if (fishesFamily == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(fishesFamily);
        }

        // GET: FishesFamilies/Create
        [Authorize(Roles = "Admin")] //Este parámetro indica que solo se puede accder si estas logado y tienes Rol Admin

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
                
                fishFamily.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await this.fishFamilyRepository.CreateAsync(fishFamily);
                return RedirectToAction(nameof(Index));
            }
            return View(fishFamily);
        }

        // GET: FishesFamilies/Edit/5
        [Authorize(Roles = "Admin")] //Este parámetro indica que solo se puede accder si estas logado y tienes Rol Admin
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
                    fishFamily.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
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
        [Authorize(Roles = "Admin")] //Este parámetro indica que solo se puede accder si estas logado y tienes Rol Admin
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
        public IActionResult ProductNotFound()
        {
            return this.View();
        }

    }
}
