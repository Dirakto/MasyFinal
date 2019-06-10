using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSCode.Models.bohater
{
    public class Bohater
    {
        private static readonly int MAX_UMIEJETNOSC = 6;
        private static readonly int MIN_UMIEJETNOSC = 4;
        private static readonly string OFENSYWNY = "Ofensywny";
        private static readonly string POMOCNICZY = "Pomocniczy";
        private static readonly string DEFENSYWNY = "Defensywny";

        [Key]
        public int Id { get; set; }

        private Dictionary<string, Object> _Podklasy = new Dictionary<string, Object>();
        public Dictionary<string, Object> Podklasy {
            get
            {
                return _Podklasy;
            }
            private set
            {
                _Podklasy = value;
            }
        } 
        public void AddOfensywny(int silaObrazenKrytycznych){
            Podklasy.Add(OFENSYWNY, new BohaterOfensywny(silaObrazenKrytycznych));
        }
        public int GetSilaObrazenKrytycznych(){
            if(Podklasy.ContainsKey(OFENSYWNY))
                return ((BohaterOfensywny)Podklasy[OFENSYWNY]).SilaObrazenKrytycznych;
            throw new FieldAccessException("No attribute for this instance");
        }
        public void AddDefensywny(int punktyWytrzymalosci){
            Podklasy.Add(DEFENSYWNY, new BohaterDefensywny(punktyWytrzymalosci));
        }
        public int GetPunktyWytrzymalosci(){
            if(Podklasy.ContainsKey(DEFENSYWNY))
                return ((BohaterDefensywny)Podklasy[DEFENSYWNY]).PunktyWytrzymalosci;
            throw new FieldAccessException("No attribute for this instance");
        }
        public void AddPomocniczy(int przelicznikLeczenia){
            Podklasy.Add(POMOCNICZY, new BohaterPomocniczy(przelicznikLeczenia));
        }
        public int GetPrzelicznikLeczenia(){
            if(Podklasy.ContainsKey(POMOCNICZY))
                return ((BohaterPomocniczy)Podklasy[POMOCNICZY]).PrzelicznikLeczenia;
            throw new FieldAccessException("No attribute for this instance");
        }

        private string _Imie;
        public string Imie {
            get
            {
                return _Imie;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Incorrect argument");
                _Imie = value;
            }
        }

        private List<Umiejetnosc> _Umiejetnosci = new List<Umiejetnosc>();
        public List<Umiejetnosc> Umiejetnosci {
            get
            {
                return _Umiejetnosci;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Incorrect argument");
                _Umiejetnosci = value;
            }
        }

        public Stan Stan { get; set; }

        private Bohater(){}
        private Bohater(string imie, List<Umiejetnosc> umiejetnosci){
            Podklasy = new Dictionary<string, object>();
            Imie = imie;
            foreach(Umiejetnosc u in umiejetnosci)
                DodajUmiejetnosc(u);

            Stan = Stan.Gotowy;
        }
        public static Bohater GetInstance(string imie, List<Umiejetnosc> umiejetnosci){
            if(umiejetnosci.Count >= MIN_UMIEJETNOSC && umiejetnosci.Count <= MAX_UMIEJETNOSC)
                return new Bohater(imie, umiejetnosci);
            else
                throw new ArgumentException($"You need to have at least {MIN_UMIEJETNOSC} umiejetnosci");
        }

        public void DodajUmiejetnosc(Umiejetnosc umiejetnosc){
            if(Umiejetnosci.Count <= MAX_UMIEJETNOSC && !Umiejetnosci.Contains(umiejetnosc)){
                Umiejetnosci.Add(umiejetnosc);
                umiejetnosc.AddBohatera(this);
            }
            // else
                // throw new ArgumentException($"Field can only have {MAX_UMIEJETNOSC} elements");
        }

        public void UstawStatystyki(int? silaObrazenKrytycznych = null, int? przelicznikLeczenia = null, int? punktyWytrzymalosci = null){
            if(silaObrazenKrytycznych.HasValue && Podklasy.ContainsKey(OFENSYWNY))
                ((BohaterOfensywny)Podklasy[OFENSYWNY]).UstawStatystyki(silaObrazenKrytycznych.Value);
            if(punktyWytrzymalosci.HasValue && Podklasy.ContainsKey(DEFENSYWNY))
                ((BohaterDefensywny)Podklasy[DEFENSYWNY]).UstawStatystyki(punktyWytrzymalosci.Value);
            if(przelicznikLeczenia.HasValue && Podklasy.ContainsKey(POMOCNICZY))
                ((BohaterPomocniczy)Podklasy[POMOCNICZY]).UstawStatystyki(przelicznikLeczenia.Value);
        }


        public class BohaterOfensywny{

                private int _SilaObrazenKrytycznych;
                public int SilaObrazenKrytycznych {
                    get
                    {
                        return _SilaObrazenKrytycznych;
                    }
                    private set
                    {
                        if(value < 0)
                            throw new ArgumentException("Incorrect argument");
                        _SilaObrazenKrytycznych = value;
                    }
                }

                public BohaterOfensywny(int silaObrazenKrytycznych){
                    UstawStatystyki(silaObrazenKrytycznych);
                }
                public void UstawStatystyki(int silaObrazenKrytycznych){
                    if(silaObrazenKrytycznych < 0)
                            throw new ArgumentException("Incorrect argument");
                    SilaObrazenKrytycznych = silaObrazenKrytycznych; 
                }
        }
        public class BohaterDefensywny{

                private int _PunktyWytrzymalosci;
                public int PunktyWytrzymalosci {
                    get
                    {
                        return _PunktyWytrzymalosci;
                    }
                    private set
                    {
                        if(value < 0)
                            throw new ArgumentException("Incorrect argument");
                        _PunktyWytrzymalosci = value;
                    }
                }
            
                public BohaterDefensywny(int punktyWytrzymalosci){
                    UstawStatystyki(punktyWytrzymalosci);
                }

                public void UstawStatystyki(int punktyWytrzymalosci){
                    if(punktyWytrzymalosci < 0)
                        throw new ArgumentException("Incorrect argument");
                    PunktyWytrzymalosci = punktyWytrzymalosci;
                }
            }
        public class BohaterPomocniczy{

            private int _PrzelicznikLeczenia;
            public int PrzelicznikLeczenia {
                get
                {
                    return _PrzelicznikLeczenia;
                }
                private set
                {
                    if(value < 0)
                        throw new ArgumentException("Incorrect argument");
                    _PrzelicznikLeczenia = value;
                }
            }
           
            public BohaterPomocniczy(int przelicznikLeczenia){
                UstawStatystyki(przelicznikLeczenia);
            }

            public void UstawStatystyki(int przelicznikLeczenia){
                if(przelicznikLeczenia < 0)
                    throw new ArgumentException("Incorrect argument");
                PrzelicznikLeczenia = przelicznikLeczenia;
            }
        }

    }

    public enum Stan{ Gotowy, Dostepny, Niedostepny, Modyfikowany }
}