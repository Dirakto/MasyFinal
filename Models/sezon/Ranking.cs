using System;
using System.ComponentModel.DataAnnotations;

namespace VSCode.Models.sezon
{
    public class Ranking
    {
        [Key]
        public int Id { get; set; }

        public int GraczId { get; set; }
        private Gracz _Gracz;
        public Gracz Gracz {
            get
            {
                return _Gracz;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Gracz reference not set to an instance of an object");
                _Gracz = value;
                value.AddRanking(this);
            }
        }

        public int SezonId { get; set; }
        private Sezon _Sezon;
        public Sezon Sezon {
            get
            {
                return _Sezon;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Sezon reference not set to an instance of an object");
                _Sezon = value;
                value.AddRanking(this);
            }
        }

        public int Poziom { get; set; }

        public int PozycjaRankingowa { get; private set; }

        private Ranking(){}
        public Ranking(Gracz gracz, Sezon sezon){
            Gracz = gracz;
            Sezon = sezon;
        }

        public static void WyswietlRankingWszystkichGraczy(Sezon sezon){
            
        }


    }
}