using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSCode.Models.rozgrywka
{
    public class RozgrywkaGracza
    {
        private static readonly int MAX_PRZYROST_POZIOMU = 100;

        [Key]
        public int Id { get; set; }

        private List<StatystykiBohaterem> _StatystykiBohaterami = new List<StatystykiBohaterem>();
        public List<StatystykiBohaterem> StatystykiBohaterami {
            get
            {
                return _StatystykiBohaterami;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Value cannot be null");
                _StatystykiBohaterami = value;
            }
        }
        public void AddStatystykiBohaterem(StatystykiBohaterem sb){
            if(sb != null && !StatystykiBohaterami.Contains(sb))
                StatystykiBohaterami.Add(sb);
        }

        public int RozgrywkaId { get; set; }
        private Rozgrywka _Rozgrywka;
        public Rozgrywka Rozgrywka {
            get
            {
                return _Rozgrywka;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Incorrect argument");
                _Rozgrywka = value;
            }
        }

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
                    throw new ArgumentException("Incorrect argument");
                _Gracz = value;
                value.AddRozgrywkaGracza(this);
            }
        }

        private string _Wynik;
        public string Wynik {
            get
            {
                return _Wynik;
            }
            set
            {
                if(value == null || !value.Contains(':'))
                    throw new ArgumentException("Incorrect argument");
                _Wynik = value;
            }
        }

        private int _PrzyrostPoziomu;
        public int PrzyrostPoziomu {
            get
            {
                return _PrzyrostPoziomu;
            }
            set
            {
                if(value > MAX_PRZYROST_POZIOMU || value < -MAX_PRZYROST_POZIOMU)
                    throw new ArgumentException("Incorrect argument");
                _PrzyrostPoziomu = value;
            }
        }

        private RozgrywkaGracza(){}
        public RozgrywkaGracza(Gracz gracz, Rozgrywka rozgrywka){
            Rozgrywka = rozgrywka;
            Gracz = gracz;
        }

        // public void ZmienBohatera(Bohater b){

        // }

    }
}