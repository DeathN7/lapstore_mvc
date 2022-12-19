using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using testmvc.Data;
using testmvc.Helpper;
using testmvc.Models;


namespace testmvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public INotyfService _notyfService { get; }
        public AdminCategoriesController(ApplicationDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminCategories
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var lsCategorys = _context.Categories
                .AsNoTracking()
                .OrderBy(x => x.CatID);
            PagedList<Category> models = new PagedList<Category>(lsCategorys, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CatID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/AdminCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatID,CatName,Description,ParentID,Levels,Ordering,Published,Thump,Title,Alias,Cover,Products")] Category category, Microsoft.AspNetCore.Http.IFormFile fThump)
        {
            if (ModelState.IsValid)
            {
                category.CatName = Utilities.ToTitleCase(category.CatName);
                if (fThump != null)
                {
                    string extension = Path.GetExtension(fThump.FileName);
                    string image = Utilities.SEOUrl(category.CatName) + extension;
                    category.Thump = await Utilities.UploadFile(fThump, @"categorys", image.ToLower());
                }
                if (string.IsNullOrEmpty(category.Thump)) category.Thump = "default.jpg";
                category.Alias = Utilities.SEOUrl(category.CatName);


                _context.Add(category);
                await _context.SaveChangesAsync();
                _notyfService.Success("Thêm mới thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/AdminCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatID,CatName,Description,ParentID,Levels,Ordering,Published,Thump,Title,Alias,Cover")] Category category, Microsoft.AspNetCore.Http.IFormFile fThump)
        {
            if (id != category.CatID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    category.CatName = Utilities.ToTitleCase(category.CatName);

                    if (fThump != null)
                    {
                        string extension = Path.GetExtension(fThump.FileName);
                        string image = Utilities.SEOUrl(category.CatName) + extension;
                        category.Thump = await Utilities.UploadFile(fThump, @"categorys", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(category.Thump)) category.Thump = "default.jpg";
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Chỉnh sửa thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CatID))
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
            return View(category);
        }

        // GET: Admin/AdminCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CatID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/AdminCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CatID == id);
        }
    }
}
