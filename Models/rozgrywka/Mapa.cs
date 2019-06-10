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

        private List<MapToMap> _PowiazaneMapy = new List<MapToMap>();
        public List<MapToMap> PowiazaneMapy {
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
            if(this.PowiazaneMapy.Count == MAX_POWIAZANYCH_MAP || m.InnePowiazaneMapy.Count == MAX_POWIAZANYCH_MAP)
                throw new ArgumentException($"There are already {MAX_POWIAZANYCH_MAP} relationships with one of the maps");
            MapToMap mTm = new MapToMap(this, m);
            if(!this.PowiazaneMapy.Contains(mTm))
                this.PowiazaneMapy.Add(mTm);
            if(!m.InnePowiazaneMapy.Contains(mTm))
                m.InnePowiazaneMapy.Add(mTm);

            // MapToMap mTmReverse = new MapToMap(m, this);
            // if(!this.InnePowiazaneMapy.Contains(mTmReverse))
            //     this.InnePowiazaneMapy.Add(mTmReverse);
            // if(!m.PowiazaneMapy.Contains(mTmReverse))
            //     m.PowiazaneMapy.Add(mTmReverse);
        }

        private List<MapToMap> _InnePowiazaneMapy = new List<MapToMap>();
        public List<MapToMap> InnePowiazaneMapy {
            get
            {
                return _InnePowiazaneMapy;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Value cannot be null");
                _InnePowiazaneMapy = value;
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
            // SezonDodania = Sezon.AKTUALNY_SEZON.Id; // SEZON DODANIA !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }

    public class MapToMap{
        public int Mapa1Id { get; private set; }
        public Mapa Mapa1 { get;  private set; }
        public int Mapa2Id { get; private set; }
        public Mapa Mapa2 { get; private set; }

        private MapToMap(){}
        public MapToMap(Mapa m1, Mapa m2){
            Mapa1 = m1;
            Mapa2 = m2;
        }
        override public bool Equals(object obj){
            if(obj == null)
                return false;
            if(this.Mapa2 == (obj as MapToMap).Mapa2)
                return true;
            else
                return false;
        }


    }


}