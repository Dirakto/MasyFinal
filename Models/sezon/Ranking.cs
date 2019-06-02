using System;
using System.ComponentModel.DataAnnotations;

namespace VSCode.Models.sezon
{
    public class Ranking
    {
        [Key]
        public int Id { get; set; }

        public int GraczId { get; set; }
        public Gracz Gracz {
            get
            {
                return Gracz;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Gracz reference not set to an instance of an object");
                Gracz = value;
                value.AddRanking(this);
            }
        }

        public int SezonId { get; set; }
        public Sezon Sezon {
            get
            {
                return Sezon;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Sezon reference not set to an instance of an object");
                Sezon = value;
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