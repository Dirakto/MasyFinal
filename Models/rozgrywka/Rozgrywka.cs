using System;
using System.Collections.Generic;
using VSCode.Models.sezon;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace VSCode.Models.rozgrywka
{
    public class Rozgrywka
    {

        [Key]
        public int Id { get; set; }

        public int SezonId { get; set; }
        private Sezon Sezon { get; set; }

        private List<Mapa> _Mapy = new List<Mapa>();
        public List<Mapa> Mapy {
            get
            {
                return _Mapy;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Value cannot be null");
                _Mapy = value;
            }
        }
        private void AddMapy(List<Mapa> mapy){
            if(mapy == null || mapy.Count == 0 || mapy.Count > Mapa.MAX_POWIAZANYCH_MAP+1)
                throw new ArgumentException("Incorrect argument");
            foreach(Mapa m in mapy)
                Mapy.Add(m);
        }

        private List<RozgrywkaGracza> _RozgrywkiGraczy = new List<RozgrywkaGracza>();
        public List<RozgrywkaGracza> RozgrywkiGraczy {
            get
            {
                return _RozgrywkiGraczy;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Value cannot be null");
                _RozgrywkiGraczy = value;
            }
        }
        private void AddRozgrywkiGraczy(List<Gracz> gracze){
            if(gracze == null || gracze.Distinct().ToList().Count != 12)
                throw new ArgumentException("Incorrect argument");
            foreach(Gracz g in gracze){
                RozgrywkiGraczy.Add(new RozgrywkaGracza(g, this));
            }
        }

        private Rozgrywka(){}
        public Rozgrywka(List<Gracz> gracze, List<Mapa> mapy){
            AddRozgrywkiGraczy(gracze);
            AddMapy(mapy);
            Sezon = Sezon.AKTUALNY_SEZON; // AKTUALNY SEZON !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        // public static void WyswietlRozgrywki(Gracz, sezon);
        // public void WyswtietlUzywanychBohaterow(Gracz)
        
    }
}