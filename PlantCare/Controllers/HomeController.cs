using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlantCare.Interfaces;
using PlantCare.Models;
using PlantCare.ViewModels;

namespace PlantCare.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //private readonly IPlantsTypeRepository _plantsTypesRepository;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        //_plantsTypesRepository = plantsTypeRepository;
    }

    public async Task<IActionResult> Index()
    {
        var homeVM = new HomeViewModel();

        //homeVM.plantsTypes = (IEnumerable<PlantsType>)await _plantsTypesRepository.GetAll();
        

        return View(homeVM);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

