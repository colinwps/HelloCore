using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloCore.Services;

namespace HelloCore.Controllers
{
    public class HomeController:Controller
    {
        public HomeController(IClock clock)
        { 
        }
    }
}
