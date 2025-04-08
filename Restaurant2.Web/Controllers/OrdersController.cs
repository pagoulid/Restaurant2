﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Web.Data;
using Restaurant.Web.Models.Entities;

namespace Restaurant.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public OrdersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await dbContext.Orders.ToListAsync();
            return View(orders);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewData["Customers"] = new SelectList(dbContext.Customers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(NewOrderViewModel viewModel)
        {

            var customer = await dbContext.Customers.FindAsync(viewModel.CustomerId);
            
            var order = new Order
            {

                CustomerId = viewModel.CustomerId,
                CustomerName = customer.Name,
                Products = viewModel.Products,
                TotalPrice = viewModel.TotalPrice,
                OrderDate= viewModel.OrderDate,
                Customer=customer
            };
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Orders");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var order = await dbContext.Orders.FindAsync(id);
            return View(order);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Order updateOrder)
        {



            var order = await dbContext.Orders.FindAsync(updateOrder.Id);

            //order.CustomerName = updateOrder.CustomerName;
            order.Products = updateOrder.Products;
            order.TotalPrice = updateOrder.TotalPrice;
            order.OrderDate = updateOrder.OrderDate;
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Orders");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Order toremoveOrder)
        {
            var customer = await dbContext.Customers.FindAsync(toremoveOrder.CustomerId);
            
            dbContext.Orders.Remove(toremoveOrder);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Orders");
        }




    }
}
