using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Web.Data;
using Restaurant.Web.Models.Entities;

namespace Restaurant.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await dbContext.Products.ToListAsync();
            return View(products);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(NewProductViewModel viewModel)
        {
            var product = new Product
            {

                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                Availability = viewModel.Availability,
            };


            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Product updateProduct)
        {



            var product = await dbContext.Products.FindAsync(updateProduct.Id);

            product.Name = updateProduct.Name;
            product.Description = updateProduct.Description;
            product.Price = updateProduct.Price;
            product.Availability = updateProduct.Availability;
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Product toremoveProduct)
        {

            dbContext.Products.Remove(toremoveProduct);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Products");
        }
    }
}

