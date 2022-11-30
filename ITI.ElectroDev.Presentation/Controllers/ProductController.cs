using ITI.ElectroDev.Models;
using ITI.ElectroDev.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

namespace ITI.ElectroDev.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private Context context;
        IConfiguration con;
        public ProductController(Context _context , IConfiguration _con)
        {
            context = _context;
            con = _con;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var product = await context.Product.ToListAsync();
            ViewBag.ImagesPath = con.GetSection("ImagesPath").Value.ToString();
            return View(product);
        }

        [HttpGet]
        public  IActionResult Create()
        {
            //ViewBag.brands = context.Brands.Select(i => new SelectListItem(i.Name, i.Id.ToString()));
            return View();
        }


        [HttpPost]
        public IActionResult Create(ProductCreateModel createModel)
        {

            if (ModelState.IsValid == false)
            {
                var errors =
                    ModelState.SelectMany(i => i.Value.Errors.Select(x => x.ErrorMessage));

                foreach (string err in errors)
                    ModelState.AddModelError("", err);


                //ViewBag.brands = context.Brands.Select(i => new SelectListItem(i.Name, i.Id.ToString()));

                return View();
            }
            else
            {
                List<ProductImages> productImages = new List<ProductImages>();
                foreach (IFormFile file in createModel.Images)
                {
                    // Change file Name by Generated Unigue Identifier , because when add in
                    // Images Folder perhaps is Name File The Same Name and This is not good  
                    string newName = Guid.NewGuid().ToString() + file.FileName;
                    productImages.Add(new ProductImages()
                    {
                        Path = newName
                    });


                    // to collect object in Memory
                    FileStream fs = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", newName), FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    // to Transfer from stream to hard disk
                    file.CopyTo(fs);

                    // To Close Stream 
                    fs.Position = 0;
                }

                context.Product.Add(new Product()
                {
                    Name = createModel.Name,
                    Description = createModel.Description,
                    BrandId = createModel.BrandId,
                    OrderId = createModel.OrderId,
                    ProductImages = productImages,
                });




                context.SaveChanges();

                return RedirectToAction("Index");

            }



        }

    }
}
