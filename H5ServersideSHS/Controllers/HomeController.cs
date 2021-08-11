﻿using H5ServersideSHS.Areas.Identity.Code;
using H5ServersideSHS.Code;
using H5ServersideSHS.Models;
using Microsoft.AspNetCore.Authorization;
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

        private readonly BcryptExample2 _bcryptExample2;


        private readonly IServiceProvider _serviceProvider;
        private readonly MyUserRoleHandler _myUserRoleHandler;

        public HomeController(ILogger<HomeController> logger, Class1 class1, HashingExample1 hashingExample1, 
            BcryptExample2 bcryptExample2, IServiceProvider serviceProvider, MyUserRoleHandler myUserRoleHandler)
        {
            _logger = logger;
            _class1 = class1;
            _hashingExample1 = hashingExample1;
            _bcryptExample2 = bcryptExample2;

            _serviceProvider = serviceProvider;
            _myUserRoleHandler = myUserRoleHandler;
        }

        // RequiredAuthenticateUser kommer fra min policy der er sat op inde i min Area/Identity/Hostingstartup. Som selv er navngivet.
        [Authorize("RequiredAuthenticateUser")]
        public async Task<IActionResult> Index()
        {
            // Bruges til at oprette brugerrollen 1 enkelt gang. 
            //await _myUserRoleHandler.CreateRole("simon131975@hotmail.com", "Admin", _serviceProvider);


            string mytext = _class1.GetText();
            string mytext2 = _class1.GetText2();
            string txt = "Hello World";
            string myHashedText = _hashingExample1.GetHashedText_MD5(txt);
            string txt2 = "Jawha";
            string myEncryptetText = _bcryptExample2.GetEncryptetText(txt2);
            string myEncryptetText2 = _bcryptExample2.GetEncryptetText(txt);

            // txt = myEncryptetText2 & txt2 = myEncryptetText

            // txt2 kan erstattes med txt for at se om den udskriver sandt eller falsk for at afprøve BCrypt.
            string myDecryptetText = _bcryptExample2.GetDecryptetText(txt2, myEncryptetText);
            

            IndexModel myModel = new IndexModel() { Text1 = mytext, Text2 = mytext2, Text3 = myHashedText, Text4 = myEncryptetText, 
                Text5 = myDecryptetText};

            return View(model: myModel);
        }

        [Authorize(Policy = "RequireAdminUser")]
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
