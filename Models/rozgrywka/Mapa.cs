using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VSCode.Models.sezon;

namespace VSCode.Models.rozgrywka
{
    public class Mapa
    {
        public static readonly int MAX_POWIAZANYCH_MAP = 2;
        private static int MAX_RUND = 3;

        [Key]
        public int Id { get; set; }

        public int TypId { get; set; }
        private TypMapy _Typ;
        public TypMapy Typ { 
            get
            {
                return _Typ;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Incorrect argument");
                _Typ = value;
                value.AddMapa(this);
            }
        }

        private List<Mapa> _PowiazaneMapy = new List<Mapa>();
        public List<Mapa> PowiazaneMapy {
            get
            {
                return _PowiazaneMapy;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Value cannot be null");
                _PowiazaneMapy = value;
            }
        }
        public void AddPowiazanaMapa(Mapa m){
            if(PowiazaneMapy.Count == MAX_POWIAZANYCH_MAP)
                throw new ArgumentException($"Field can only have {MAX_POWIAZANYCH_MAP} elements");
            if(!PowiazaneMapy.Contains(m)){
                PowiazaneMapy.Add(m);
                m.AddPowiazanaMapa(this);
            }
        }

        private string _Nazwa;
        public string Nazwa {
            get
            {
                return _Nazwa;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Incorrect argument");
                _Nazwa = value;
            }
        }
    
        private readonly int SezonDodania;

        private int _IloscRund;
        public int IloscRund {
            get
            {
                return _IloscRund;
            }
            set
            {
                if(value < 0 || value > MAX_RUND)
                    throw new ArgumentException("Incorrect argument");
                _IloscRund = value;
            }
        }

        private Mapa(){}    
        public Mapa(string nazwa, TypMapy typ, int iloscRund){
            Nazwa = nazwa;
            Typ = typ;
            IloscRund = iloscRund;
            SezonDodania = Sezon.AKTUALNY_SEZON.Id; // SEZON DODANIA !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }
}