using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess.Data;
using MVC.Models;

namespace MVC.DataAccess.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.tblCategory.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category obj)
        {
            //Property validation from Model
            if (obj.fldName == obj.fldDisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Both the values should not be the same.");
                return View();
            }

            //Mode Only validation
            //if (obj.fldName.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "Invalid value Test");
            //}
            if (ModelState.IsValid)
            {
                _db.tblCategory.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(string? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            //Category cat = _db.tblCategory.Find(id);//works only on primary key.
            Category cat1 = _db.tblCategory.FirstOrDefault(u => u.fldName == id);
         
            if (cat1 == null)
            {
                return NotFound();
            }
            return View(cat1);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                // Make sure the entity exists in the database before updating it
                var existingCategory = _db.tblCategory.FirstOrDefault(c => c.fldName == obj.fldName);

                if (existingCategory != null)
                {
                    existingCategory.fldName = obj.fldName;
                    existingCategory.fldDisplayOrder = obj.fldDisplayOrder;

                    _db.tblCategory.Update(existingCategory);
                    _db.SaveChanges();
                    TempData["success"] = "Category updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(obj);
        }
        public IActionResult Delete(string? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            //Category cat = _db.tblCategory.Find(id);//works only on primary key.
            Category cat1 = _db.tblCategory.FirstOrDefault(u => u.fldName == id);
            Category cat2 = _db.tblCategory.Where(u => u.fldName == id).FirstOrDefault();
            if (cat1 == null)
            {
                return NotFound();
            }
            return View(cat1);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(string? id)
        {
            Category? cat = _db.tblCategory.FirstOrDefault(u => u.fldName == id);
            if (cat is null)
            {
                return NotFound();
            }
            _db.tblCategory.Remove(cat);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
