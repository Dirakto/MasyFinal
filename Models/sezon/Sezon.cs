using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VSCode.Models;
using System.Linq;

namespace VSCode.Models.sezon
{
    public class Sezon
    {
        [Key]
        public int Id { get; set; }

        private ICollection<Ranking> _Rankingi = new List<Ranking>();
        public ICollection<Ranking> Rankingi {
            get
            {
                return _Rankingi;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Value cannot be null");
                _Rankingi = value;
            }
        }
        public void AddRanking(Ranking r){
            if(r != null && Rankingi.Contains(r)){
                if(r.Sezon == this)
                    Rankingi.Add(r);
            }
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

        // private static Sezon _AKTUALNY_SEZON = null;
        // public static Sezon AKTUALNY_SEZON {
        //     get{
        //         if(_AKTUALNY_SEZON == null)
        //             _AKTUALNY_SEZON = AppDbContext.Context.Sezony.OrderByDescending(s => s.Id).First();
        //         return _AKTUALNY_SEZON;
        //     }
        // }

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