using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using testmvc.Data;
using testmvc.Models;
using testmvc.ModelViews;

namespace testmvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    public INotyfService _notyfService { get; }


    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, INotyfService notyfService)
    {
        _logger = logger;
        _context = context;
        _notyfService = notyfService;
    }

    public IActionResult Index()
    {
        HomeViewVM model = new HomeViewVM();

        var lsProducts = _context.Products.AsNoTracking()
            .Where(x => x.Active == true && x.HomeFlag == true)
            .OrderByDescending(x => x.ProductID)
            .ToList();

        List<ProductHomeVM> lsProductViews = new List<ProductHomeVM>();
        var lsCats = _context.Categories
            .AsNoTracking()
            .Where(x => x.Published == true)
            .OrderByDescending(x => x.Ordering)
            .ToList();

        foreach (var item in lsCats)
        {
            ProductHomeVM productHome = new ProductHomeVM();
            productHome.Category = item;
            productHome.lsProducts = lsProducts.Where(x => x.CatID == item.CatID).ToList();
            lsProductViews.Add(productHome);
            model.Products = lsProductViews;
            ViewBag.AllProducts = lsProducts;
        }
        return View(model);
    }
}

