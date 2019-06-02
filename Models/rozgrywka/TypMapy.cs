using System;
using System.Collections.Generic;

namespace VSCode.Models.rozgrywka
{
    public class TypMapy
    {

        private List<Mapa> mapy = new List<Mapa>();
        public List<Mapa> getMapy(){
            return mapy;
        }
        public void AddMapa(Mapa m){
            if(!mapy.Contains(m)){
                mapy.Add(m);
            }
        }

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
    
        public Typ Typ { get; private set; }

        public int? LiczbaCeli {
            get
            {
                return LiczbaCeli;
            }
            private set
            {
                if(value != null && value < 0)
                    throw new ArgumentException("Incorrect Argument");
                LiczbaCeli = value;
            }
        }
    
        public TypMapy(string nazwa, Typ typ, int? liczbaCeli = null){
            Nazwa = nazwa;
            Typ = typ;
            LiczbaCeli = liczbaCeli;
        }
    
    }

    public enum Typ{ KingOfTheHill, Payload }

}