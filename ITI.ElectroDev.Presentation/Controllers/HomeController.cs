using ITI.ElectroDev.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITI.ElectroDev.Presentation
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Admin Dashboard";
            return View();
        }

    }
}