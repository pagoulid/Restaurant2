using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Web.Data;
using Restaurant.Web.Models.Entities;

namespace Restaurant.Web.Controllers
{
    public class CustomersController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public CustomersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await dbContext.Customers.ToListAsync();
            return View(customers);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(NewCustomerViewModel viewModel)
        {
            var customer = new Customer {

                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
            };


            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Customers");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            


            var customer = await dbContext.Customers.FindAsync(id);
            
            return View(customer);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Customer updateCustomer)
        {



            var customer = await dbContext.Customers.FindAsync(updateCustomer.Id);

            customer.Name = updateCustomer.Name;
            customer.Surname = updateCustomer.Surname;
            customer.Email = updateCustomer.Email;
            customer.Phone = updateCustomer.Phone;
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index","Customers");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Customer toremoveCustomer)
        {

            dbContext.Customers.Remove(toremoveCustomer);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Customers");
        }
    }
}
