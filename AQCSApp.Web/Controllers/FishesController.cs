using AQCSApp.Web.Data;
using AQCSApp.Web.Data.Entities;
using AQCSApp.Web.Helpers;
using AQCSApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
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

        // GET: Fishes
        public IActionResult Index()
        {
            return View(this.fishRepository.GetAll().OrderBy(p => p.Name));
        }

        // GET: Fishes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishes = await this.fishRepository.GetByIdAsync(id.Value);

            if (fishes == null)
            {
                return NotFound();
            }

            return View(fishes);
        }

        // GET: Fishes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fishes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FishViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Fishes",
                        file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Fishes/{file}";
                }
                var fish = this.ToFish(view, path);
                fish.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await this.fishRepository.CreateAsync(fish);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Fish ToFish(FishViewModel view, string path)
        {
            return new Fish
            {
                Id = view.Id,
                ImageUrl = path,
                Name = view.Name,
                //FishFamily = view.FishFamily,
                User = view.User
            };
        }

        // GET: Fishes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await this.fishRepository.GetByIdAsync(id.Value);
            if (fish == null)
            {
                return NotFound();
            }
            var view = this.ToFishViewModel(fish);
            return View(view);
        }

        private FishViewModel ToFishViewModel(Fish fish)
        {
            return new FishViewModel
            {
                Id = fish.Id,
                ImageUrl = fish.ImageUrl,
                Name = fish.Name,
                //FishFamily = fish.FishFamily,
                User = fish.User
            };
        }

        // POST: Fishes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FishViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Fishes",
                            file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Fishes/{file}";


                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Fishes/{view.ImageFile.FileName}";
                    }
                    var fish = this.ToFish(view, path);
                    fish.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await this.fishRepository.UpdateAsync(fish);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.fishRepository.ExistAsync(view.Id))
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
            return View(view);
        }

        // GET: Fishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await this.fishRepository.GetByIdAsync(id.Value);

            if (fish== null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // POST: Fishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fish = await this.fishRepository.GetByIdAsync(id);
            await this.fishRepository.DeleteAsync(fish);
            return RedirectToAction(nameof(Index));
        }

    }
}
