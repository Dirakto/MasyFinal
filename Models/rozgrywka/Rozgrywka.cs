using System;
using System.Collections.Generic;
using VSCode.Models.sezon;
using System.Linq;

namespace VSCode.Models.rozgrywka
{
    public class Rozgrywka
    {
        public int SezonId { get; set; }
        private Sezon Sezon { get; set; }

        private List<Mapa> Mapy = new List<Mapa>();
        public List<Mapa> GetMapy(){
            return new List<Mapa>(Mapy);
        }
        private void AddMapy(List<Mapa> mapy){
            if(mapy == null || mapy.Count == 0 || mapy.Count > Mapa.MAX_POWIAZANYCH_MAP+1)
                throw new ArgumentException("Incorrect argument");
            foreach(Mapa m in mapy)
                Mapy.Add(m);
        }

        private List<RozgrywkaGracza> RozgrywkiGraczy = new List<RozgrywkaGracza>();
        public List<RozgrywkaGracza> GetGracze(){
            return new List<RozgrywkaGracza>(RozgrywkiGraczy);
        }
        private void AddRozgrywkiGraczy(List<Gracz> gracze){
            if(gracze == null || gracze.Distinct().ToList().Count != 12)
                throw new ArgumentException("Incorrect argument");
            foreach(Gracz g in gracze){
                RozgrywkiGraczy.Add(new RozgrywkaGracza(g, this));
            }
        }

        public Rozgrywka(List<Gracz> gracze, List<Mapa> mapy){
            AddRozgrywkiGraczy(gracze);
            AddMapy(mapy);
            // CURRENT SEZON   !!!
        }

        // public static void WyswietlRozgrywki(Gracz, sezon);
        // public void WyswtietlUzywanychBohaterow(Gracz)
        
    }
}