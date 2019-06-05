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
using VSCode.Models.bohater;
using VSCode.Models.rozgrywka;

namespace vscode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run();
            // AppDbContext context = new AppDbContext();
            // Osiagniecie o1 = new OsiagniecieZaUmiejetnosc("Master of puppets", 20, "Get 20 kills");
            // Gracz g1 = new Gracz("Jan", "Kowalski", "NoobSaibot");
            // Gracz g2 = new Gracz("Jan", "Kowalski2", "NoobSaibot2");
            // Gracz g3 = new Gracz("Jan", "Kowalski3", "NoobSaibot3");
            // Gracz g4 = new Gracz("Jan", "Kowalski4", "NoobSaibot4");
            // Gracz g5 = new Gracz("Jan", "Kowalski5", "NoobSaibot5");
            // Gracz g6 = new Gracz("Jan", "Kowalski6", "NoobSaibot6");
            // Gracz g7 = new Gracz("Jan", "Kowalski7", "NoobSaibot7");
            // Gracz g8 = new Gracz("Jan", "Kowalski8", "NoobSaibot8");
            // Gracz g9 = new Gracz("Jan", "Kowalski9", "NoobSaibot9");
            // Gracz g10 = new Gracz("Jan", "Kowalski10", "NoobSaibot10");
            // Gracz g11 = new Gracz("Jan", "Kowalski11", "NoobSaibot11");
            // Gracz g12 = new Gracz("Jan", "Kowalski12", "NoobSaibot12");
            // OsiagniecieGracza og = new OsiagniecieGracza(g1, o1);
            // Umiejetnosc u1 = new Umiejetnosc("Um1", "XDDDD", Klawisz.E, 20, punktyLeczenia: 30);
            // Umiejetnosc u2 = new Umiejetnosc("Um1", "XDDDD", Klawisz.E, 20, punktyLeczenia: 30);
            // Umiejetnosc u3 = new Umiejetnosc("Um1", "XDDDD", Klawisz.E, 20, punktyLeczenia: 30);
            // Umiejetnosc u4 = new Umiejetnosc("Um1", "XDDDD", Klawisz.E, 20, punktyLeczenia: 30);
            // Bohater b1 = Bohater.GetInstance("Aleksander", new List<Umiejetnosc>(){u1, u2, u3, u4});
            // Sezon s1 = new Sezon(1000, 5000);
            // Ranking r1 = new Ranking(g1, s1);
            // TypMapy tm1 = new TypMapy(Typ.KingOfTheHill, 3);
            // Mapa m1 = new Mapa("Arabic", tm1, 3);
            // Rozgrywka roz1 = new Rozgrywka(
            //     new List<Gracz>(){g1, g2, g3, g4, g5, g6, g7, g8, g9, g10, g11, g12},
            //     new List<Mapa>(){m1}
            // );
            // StatystykiBohaterem sb1 = new StatystykiBohaterem(roz1.GetGracze().Where(s => s.Gracz == g1).First(), b1);

            // AppDbContext.Context.Gracze.Add(g1);
            // AppDbContext.Context.Rankingi.Add(g1.Rankingi[0]);
            // USUWANIE BOHATERA
            // Umiejetnosc u1 = new Umiejetnosc("Um1", "XDDDD", Klawisz.E, 20, punktyLeczenia: 30);
            // Umiejetnosc u2 = new Umiejetnosc("Um1", "XDDDD", Klawisz.E, 20, punktyLeczenia: 30);
            // Umiejetnosc u3 = new Umiejetnosc("Um1", "XDDDD", Klawisz.E, 20, punktyLeczenia: 30);
            // Umiejetnosc u4 = new Umiejetnosc("Um1", "XDDDD", Klawisz.E, 20, punktyLeczenia: 30);
            // Bohater b1 = Bohater.GetInstance("Aleksander", new List<Umiejetnosc>(){u1, u2, u3, u4});
            // b1.AddDefensywny(20);
            // b1.AddOfensywny(50);
            // b1.Stan = Stan.Dostepny;
            // var b = context.Bohaterowie.ToList()[2];
            // context.Remove(b);
            // context.Bohaterowie.Add(b1);
            // AppDbContext.Context.SaveChanges();
            Console.WriteLine(AppDbContext.Context.Gracze.ToList()[0].AktualnyPoziom);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
