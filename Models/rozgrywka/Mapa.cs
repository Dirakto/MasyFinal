using System;
using System.Collections.Generic;

namespace VSCode.Models.rozgrywka
{
    public class Mapa
    {
        public static readonly int MAX_POWIAZANYCH_MAP = 2;

        public TypMapy Typ { 
            get
            {
                return Typ;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Incorrect argument");
                Typ = value;
                value.AddMapa(this);
            }
        }

        private List<Mapa> PowiazaneMapy = new List<Mapa>();
        public List<Mapa> GetPowiazaneMapy(){
            return PowiazaneMapy;
        }
        public void AddPowiazanaMapa(Mapa m){
            if(PowiazaneMapy.Count == MAX_POWIAZANYCH_MAP)
                throw new ArgumentException($"Field can only have {MAX_POWIAZANYCH_MAP} elements");
            if(!PowiazaneMapy.Contains(m)){
                PowiazaneMapy.Add(m);
                m.AddPowiazanaMapa(this);
            }
        }

        private static int MAX_RUND = 3;
        public string Nazwa {
            get
            {
                return Nazwa;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Incorrect argument");
                Nazwa = value;
            }
        }
    
        private readonly int _sezonDodania;
        public int getSezonDodania(){
            return _sezonDodania;
        }



    
        public int IloscRund {
            get
            {
                return IloscRund;
            }
            set
            {
                if(value < 0 || value > MAX_RUND)
                    throw new ArgumentException("Incorrect argument");
                IloscRund = value;
            }
        }
    
        public Mapa(string nazwa, TypMapy typ, int iloscRund){
            Nazwa = nazwa;
            Typ = typ;
            IloscRund = iloscRund;
            // _sezonDodania = ???;
        }
    }
}