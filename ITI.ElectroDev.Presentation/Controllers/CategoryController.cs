using ITI.ElectroDev.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ITI.ElectroDev.Presentation
{
    public class CategoryController : Controller
    {
        private Context db;
        public CategoryController(Context _db)
        {
            db = _db; 
        }
        [HttpGet]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2)
        {
            var categories = db.Category.ToList();
            return View(categories);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryCreateModel model)
        {

            if (ModelState.IsValid == false)
            {
                var errors =
                     ModelState.SelectMany(i => i.Value.Errors.Select(x => x.ErrorMessage));

                foreach (string err in errors)
                    ModelState.AddModelError("", err);

                return View();
            }
            else
            {
                db.Category.Add(new Category { Name = model.Name });
                db.SaveChanges();
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id, string name)
        {
            
            dynamic category = new ExpandoObject();
            category.Name = name;
            category.Id = id;
            return View(category);
        }
        [HttpGet]
        public IActionResult SaveEdit(int id,string name)
        {
            var category = db.Category.FirstOrDefault(i => i.Id == id);
            category.Name = name;
            category.Id = id;
            db.Category.Update(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id, string name)
        {
            ViewBag.Title = "Delete Category";
            dynamic category = new ExpandoObject();
            category.Name = name;
            category.Id = id;
            return View(category);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = db.Category.FirstOrDefault(i => i.Id == id);
            db.Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
