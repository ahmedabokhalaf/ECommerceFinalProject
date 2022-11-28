using ITI.ElectroDev.Models;
using ITI.ElectroDev.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Dynamic;
using X.PagedList;

namespace ITI.ElectroDev.Presentation.Controllers
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
            ViewBag.Title = "Category  | Index";
            var categories = db.Category.ToPagedList(pageIndex, pageSize);
            return View(categories);
        }
        [HttpGet]
        public IActionResult PartialCategory(int pageIndex = 1, int pageSize = 2)
        {
            var pagedCategories = db.Category.ToPagedList(pageIndex, pageSize);
            return PartialView("_PagedCategories", pagedCategories);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryCreateModel model)
        {
            db.Category.Add(new Category { Name = model.Name});
             db.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id, string name)
        {
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
