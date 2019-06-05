using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSCode.Models.rozgrywka
{
    public class TypMapy
    {

        [Key]
        public int Id { get; set; }

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

        public void AddMapa(Mapa m){
            if(!Mapy.Contains(m)){
                Mapy.Add(m);
            }
        }

        // private string _Nazwa;
        // public string Nazwa {
        //     get
        //     {
        //         return _Nazwa;
        //     }
        //     set
        //     {
        //         if(value == null || value.Length == 0)
        //             throw new ArgumentException("Incorrect argument");
        //         _Nazwa = value;
        //     }
        // }
    
        public Typ Typ { get; private set; }

        private int? _LiczbaCeli;
        public int? LiczbaCeli {
            get
            {
                return _LiczbaCeli;
            }
            private set
            {
                if(value != null && value < 0)
                    throw new ArgumentException("Incorrect Argument");
                _LiczbaCeli = value;
            }
        }
    
        private TypMapy(){}
        public TypMapy(/*string nazwa, */Typ typ, int? liczbaCeli = null){
            // Nazwa = nazwa;
            Typ = typ;
            LiczbaCeli = liczbaCeli;
        }
    
    }

    public enum Typ{ KingOfTheHill, Payload }

}