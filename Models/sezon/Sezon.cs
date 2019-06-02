using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VSCode.Models.sezon
{
    public class Sezon
    {
        [Key]
        public int Id { get; set; }

        private ICollection<Ranking> Rankingi = new List<Ranking>();
        public List<Ranking> GetRankingi(){ return new List<Ranking>(Rankingi); }
        public void AddRanking(Ranking r){
            if(r != null && Rankingi.Contains(r))
                Rankingi.Add(r);
        }

        public int MaxIloscPunktow {
            get
            {
                return MaxIloscPunktow;
            }
            private set
            {
                if(value <= 0)
                    throw new ArgumentException("Incorrect argument");
                MaxIloscPunktow = value;
            }
        }

        public int MinIloscPunktow {
            get
            {
                return MinIloscPunktow;
            }
            set
            {
                if(value <= 0)
                    throw new ArgumentException("Incorrect argument");
                MinIloscPunktow = value;
            }
        }

        public DateTime DataRozpoczecia { get; private set; }

        private Sezon(){}
        public Sezon(int maxIloscPunktow, int minIloscPunktow){
            MaxIloscPunktow = maxIloscPunktow;
            MinIloscPunktow = minIloscPunktow;
            DataRozpoczecia = DateTime.Now;
        }

    }
}