using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AQCSApp.Web.Data;
using AQCSApp.Web.Data.Entities;

namespace AQCSApp.Web.Controllers
{
    public class FishFamiliesController : Controller
    {
        public IRepository repository;

        public FishFamiliesController(IRepository repository)
        {
           this.repository = repository;
        }

        // GET: FishesFamilies
        public IActionResult Index()
        {
            return View(this.repository.GetFishFamilies());
        }

        // GET: FishesFamilies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishesFamily = this.repository.GetFishFamilies(id.Value);
               
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
        public async Task<IActionResult> Create(FishFamily fishesFamily)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddFishFamily(fishesFamily);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fishesFamily);
        }

        // GET: FishesFamilies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishfamily = this.repository.GetFishFamilies(id.Value);
            if (fishfamily == null)
            {
                return NotFound();
            }
            return View(fishfamily);
        }

        // POST: FishesFamilies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FishFamily fishFamily)
        {
            if (id != fishFamily.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdateFishFamily(fishFamily);
                   
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.FishFamilyExists(fishFamily.Id))
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishFamily = this.repository.GetFishFamilies(id.Value);
                
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
            var fishFamily = this.repository.GetFishFamilies(id);
            this.repository.RemoveFishFamily(fishFamily);
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool FishFamilyExists(int id)
        //{
        //    return this.repository.GetFishFamilies.Any(e => e.Id == id);
        //}
    }
}
