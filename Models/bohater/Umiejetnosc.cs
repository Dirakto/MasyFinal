using System;

namespace VSCode.Models.bohater
{
    public class Umiejetnosc
    {
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
    
        public string Opis { 
            get
            {
                return Opis;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Incorrect argument");
                Opis = value;
            }
        }

        public int PunktyObrazen { 
            get
            {
                return PunktyObrazen;
            }
            set
            {
                if(value < 0)
                    throw new ArgumentException("Incorrect argument");
                PunktyObrazen = value;
            }
        }

        public int PunktyLeczenia { 
            get
            {
                return PunktyLeczenia;
            }
            set
            {
                if(value < 0)
                    throw new ArgumentException("Incorrect argument");
                PunktyLeczenia = value;
            }
        }
    
        public int PunktyTarczy {
            get
            {
                return PunktyTarczy;
            }
            set
            {
                if(value < 0)
                    throw new ArgumentException("Incorrect argument");
                PunktyTarczy = value;
            }
        }
    
        public Klawisz Klawisz { get; set; }

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