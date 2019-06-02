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


namespace vscode.Controllers
{
    public class HomeController : Controller
    {

        // private AppDbContext _context;

        // public HomeController(AppDbContext context){
        //     _context = context;
        // }

        public IActionResult Index()
        {
            Osiagniecie o1 = new OsiagniecieZaUmiejetnosc("Master of puppets", 20, "Get 20 kills");
            Gracz g1 = new Gracz("Jan", "Kowalski", "NoobSaibot");
            
            // OsiagniecieGracza og = new OsiagniecieGracza(g1, o1);

            return View();
        }

    }
}
