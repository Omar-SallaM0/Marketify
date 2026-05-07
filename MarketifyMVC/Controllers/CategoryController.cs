using Marketify.DataAccess.Data;
using Marketify.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketifyMVC.Controllers
{
    public class CategoryController(ApplicationDbContext _db) : Controller
    {
        public IActionResult Index()
        {
            List<Category> categoriesObj = _db.Categories.ToList();
            return View(categoriesObj);
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Title == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cannot exactly match the Name");
            }
            if(category.Title != null && category.Title.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is Invalid Value");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            Category category = _db.Categories.Find(id);
            if (category == null) { 
              return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            Category category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _db.Categories.Find(id);
            if (category == null) { 
            return NotFound();
            }
                _db.Categories.Remove(category);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
