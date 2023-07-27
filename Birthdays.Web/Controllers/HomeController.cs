using System.Diagnostics;
using Birthdays.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Birthdays.Web.Models;

namespace Birthdays.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPersonService _personService;

    public HomeController(ILogger<HomeController> logger, IPersonService service)
    {
        _personService = service;
        _logger = logger;
    }
    
    
    [HttpGet]
    public IActionResult Index()
    {
        return View(_personService.GetUpcoming());
    }

    [HttpPost]
    public IActionResult Index(int method)
    {
        if (method == 1) return View(_personService.GetAll());
        if (method == 2) return View(_personService.GetUpcoming());
        else return View(_personService.GetUpcoming());
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}