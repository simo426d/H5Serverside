using H5ServersideSHS.Code;
using H5ServersideSHS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace H5ServersideSHS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Class1 _class1;

        private readonly HashingExample1 _hashingExample1;

        public HomeController(ILogger<HomeController> logger, Class1 class1, HashingExample1 hashingExample1)
        {
            _logger = logger;
            _class1 = class1;
            _hashingExample1 = hashingExample1;
        }

        public IActionResult Index()
        {
            
            string mytext = _class1.GetText();
            string mytext2 = _class1.GetText2();
            string txt = "Hello World";
            string myHashedText = _hashingExample1.GetHashedText_MD5(txt);


            IndexModel myModel = new IndexModel() { Text1 = mytext, Text2 = mytext2 };

            return View(model: myModel);
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
}
