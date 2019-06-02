using System;
using System.Collections.Generic;

namespace VSCode.Models.rozgrywka
{
    public class RozgrywkaGracza
    {
        private static readonly int MAX_PRZYROST_POZIOMU = 100;

        private List<StatystykiBohaterem> StatystykiBohaterami = new List<StatystykiBohaterem>();
        public List<StatystykiBohaterem> GetStatystykiBohaterami(){ return new List<StatystykiBohaterem>(StatystykiBohaterami); }
        public void AddStatystykiBohaterem(StatystykiBohaterem sb){
            if(sb != null && !StatystykiBohaterami.Contains(sb))
                StatystykiBohaterami.Add(sb);
        }

        public Rozgrywka Rozgrywka {
            get
            {
                return Rozgrywka;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Incorrect argument");
                Rozgrywka = value;
            }
        }

        public Gracz Gracz {
            get
            {
                return Gracz;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Incorrect argument");
                Gracz = value;
                Gracz.AddRozgrywkaGracza(this);
            }
        }

        public string Wynik {
            get
            {
                return Wynik;
            }
            set
            {
                if(value == null || !value.Contains(':'))
                    throw new ArgumentException("Incorrect argument");
                Wynik = value;
            }
        }

        public int PrzyrostPoziomu {
            get
            {
                return PrzyrostPoziomu;
            }
            set
            {
                if(value > MAX_PRZYROST_POZIOMU || value < -MAX_PRZYROST_POZIOMU)
                    throw new ArgumentException("Incorrect argument");
                PrzyrostPoziomu = value;
            }
        }

        public RozgrywkaGracza(Gracz gracz, Rozgrywka rozgrywka){
            Rozgrywka = rozgrywka;
            Gracz = gracz;
        }



    }
}