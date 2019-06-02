using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using VSCode.Models;
using VSCode.Models.osiagniecie;
using VSCode.Models.sezon;

namespace vscode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            Osiagniecie o1 = new OsiagniecieZaUmiejetnosc("Master of puppets", 20, "Get 20 kills");
            Gracz g1 = new Gracz("Jan", "Kowalski", "NoobSaibot");

            OsiagniecieGracza og = new OsiagniecieGracza(g1, o1);

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
