using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VSCode.Models;
using VSCode.Models.bohater;
using VSCode.Models.osiagniecie;
using VSCode.Models.sezon;


namespace VSCode.Controllers
{
    public class HomeController : Controller
    {
        private IAppRepository repo;

        public HomeController(IAppRepository appRep) {
            repo = appRep;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(repo.Bohaterowie);
        }

        // [HttpPost]
        // public IActionResult ChangeStan(string data){
            // var boh = repo.Bohaterowie.Where(b => b.Imie == data).First();
            // if(boh != null && boh.Stan == Stan.Dostepny)
            //     boh.Stan = Stan.Niedostepny;
            // else
            //     boh.Stan = Stan.Dostepny;

            // return Json(data);
        // }

        [HttpGet]
        public IActionResult ChangeStan(string name){
            var boh = repo.Bohaterowie.Where(b => b.Imie == name).FirstOrDefault();
            if(boh != null && boh.Stan == Stan.Dostepny)
                boh.Stan = Stan.Niedostepny;
            else
                boh.Stan = Stan.Dostepny;
            repo.SaveAsync();

            return Json(boh.Stan.ToString());
        }

        [HttpGet]
        public IActionResult GetBohater(string name){
            var boh = repo.Bohaterowie.Where(b => b.Imie == name).FirstOrDefault();
            if(boh != null){
                return Json(boh);
            }
            return Json("Error");
        }

    }
}
