using BestBuySampleAPI.Model;
using BestBuySampleAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BestBuySampleAPI.Controllers
{

    [ApiController]
    [Route("api")]
    public class HomeController : Controller
    {

         private readonly IFizzBuzzService _fizzBuzzService;

         public HomeController(IFizzBuzzService fizzBuzzService)
         {
             _fizzBuzzService = fizzBuzzService;
         }


       
        [HttpPost]
        [Route("FizzorBuzz")]
        public IActionResult GetFizzBuzz([FromBody] List<object> values)
        {
            var fizzBuzzResult = _fizzBuzzService.GetFizzBuzz(values);
                      
            return Content(fizzBuzzResult, "text/html");
        }

        [HttpGet]
        [Route("TestAPI")]
        public IActionResult Hello()
        {
            return Content("Hello, welcome to our Lambda!");
        }


    }
}


