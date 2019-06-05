using System;
using System.ComponentModel.DataAnnotations;

namespace VSCode.Models.bohater
{
    public class Umiejetnosc
    {

        [Key]
        public int Id { get; set; }

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
    
        private string _Opis;
        public string Opis { 
            get
            {
                return _Opis;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Incorrect argument");
                _Opis = value;
            }
        }

        private int _PunktyObrazen;
        public int PunktyObrazen { 
            get
            {
                return _PunktyObrazen;
            }
            set
            {
                if(value < 0)
                    throw new ArgumentException("Incorrect argument");
                _PunktyObrazen = value;
            }
        }

        private int _PunktyLeczenia;
        public int PunktyLeczenia { 
            get
            {
                return _PunktyLeczenia;
            }
            set
            {
                if(value < 0)
                    throw new ArgumentException("Incorrect argument");
                _PunktyLeczenia = value;
            }
        }
    
        private int _PunktyTarczy;
        public int PunktyTarczy {
            get
            {
                return _PunktyTarczy;
            }
            set
            {
                if(value < 0)
                    throw new ArgumentException("Incorrect argument");
                _PunktyTarczy = value;
            }
        }
    
        public Klawisz Klawisz { get; set; }

        public int BohaterId { get; private set; }
        public Bohater Bohater { get; private set; }
        public void AddBohatera(Bohater b){
            if(b == null)
                throw new ArgumentException("Incorrect argument");
            Bohater = b;
            b.DodajUmiejetnosc(this);
        }

        private Umiejetnosc(){}
        public Umiejetnosc(string nazwa, string opis, Klawisz klawisz, int punktyObrazen = 0, int punktyLeczenia = 0, int punktyTarczy = 0){
            Nazwa = nazwa;
            Opis = opis;
            Klawisz = klawisz;
            PunktyObrazen = punktyObrazen;
            PunktyLeczenia = punktyLeczenia;
            PunktyTarczy = punktyTarczy;
        }

    }

    public enum Klawisz { Q, E, Shift, Passive, RightClick, LeftCtrl }
}