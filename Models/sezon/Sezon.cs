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

        private int _MaxIloscPunktow;
        public int MaxIloscPunktow {
            get
            {
                return _MaxIloscPunktow;
            }
            private set
            {
                if(value <= 0)
                    throw new ArgumentException("Incorrect argument");
                _MaxIloscPunktow = value;
            }
        }

        private int _MinIloscPunktow;
        public int MinIloscPunktow {
            get
            {
                return _MinIloscPunktow;
            }
            set
            {
                if(value <= 0)
                    throw new ArgumentException("Incorrect argument");
                _MinIloscPunktow = value;
            }
        }

        public DateTime DataRozpoczecia { get; private set; }

        private Sezon(){}
        public Sezon(int minIloscPunktow, int maxIloscPunktow){
            if(maxIloscPunktow <= minIloscPunktow)
                throw new ArgumentException("MaxIloscPunktow should be greater than MinIlosPunktow");
            MaxIloscPunktow = maxIloscPunktow;
            MinIloscPunktow = minIloscPunktow;
            DataRozpoczecia = DateTime.Now;
        }

    }
}