﻿using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
