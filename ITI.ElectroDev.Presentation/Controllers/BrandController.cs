using ITI.ElectroDev.Models;
using ITI.ElectroDev.Presentation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.Xml.Linq;
using X.PagedList;

namespace ITI.ElectroDev.Presentation
{
    public class BrandController : Controller
    {
        Context dbcontext;
        public BrandController(Context _dbContext)
        {
            dbcontext = _dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewBrand()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddNewBrand(BrandModel brand)
        {
            //string image;

            //if (ModelState.IsValid == false)
            //{
            //    var errors =
            //        ModelState.SelectMany(i => i.Value.Errors.Select(x => x.ErrorMessage));

            //    foreach (string err in errors)
            //        ModelState.AddModelError("", err);

            //    ViewBag.Success = false;
            //    return View();

            //}
            //else
            //{
            //    ViewBag.Sucess = true;

            //}

                //IFormFile file = brand.Image as IFormFile;

                //string BinaryPath = Guid.NewGuid().ToString() + file.FileName;
                //image = BinaryPath;

                //FileStream fs = new FileStream(
                //    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BrandImages", BinaryPath)
                //    , FileMode.OpenOrCreate, FileAccess.ReadWrite);

                //file.CopyTo(fs);
                //fs.Position = 0;


                var Brand = new Brand();
                Brand.Name = brand.Name;
                Brand.CategoryId = brand.CategoryId;
                
                    //Name = brand.Name,

                    //CategoryId = brand.CategoryId,

                
                dbcontext.Brands.Add(Brand);
                dbcontext.SaveChanges();

              


            
           
            return View();
        }

        public IActionResult AllBrand()
        {
            var Brands = dbcontext.Brands.AsNoTracking().ToList();
            return View(Brands);
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id, string name)
        {
            ViewBag.Title = "Delete Brand";
            dynamic brand = new ExpandoObject();
            brand.Name = name;
            brand.Id = id;
            return View(brand);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var brand = dbcontext.Brands.FirstOrDefault(i => i.Id == id);
            dbcontext.Brands.Remove(brand);
            dbcontext.SaveChanges();
            return RedirectToAction("AllBrand");
        }

        [HttpGet]
        public async Task<IActionResult> Edite( int id,int categoryId ,string name )
        {
            dynamic brand = new ExpandoObject();
            brand.Id = id;
            brand.Name = name;
            brand.CategoryId = categoryId;
            return View(brand);
        }

        
        [HttpGet]
        public IActionResult ConfirmEdite(int id,int categoryId, string name)
        {
            var brand = dbcontext.Brands.FirstOrDefault(i => i.Id == id);
            brand.Id = id;
            brand.Name = name;
            //brand.CategoryId = categoryId;
            dbcontext.Brands.Update(brand);
            dbcontext.SaveChanges();
            return RedirectToAction("AllBrand");

            
        }

    }
}
