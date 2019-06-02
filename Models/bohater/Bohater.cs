using System;
using System.Collections.Generic;

namespace VSCode.Models.bohater
{
    public class Bohater
    {
        private static readonly int MAX_UMIEJETNOSC = 6;
        private static readonly int MIN_UMIEJETNOSC = 4;
        private static readonly string OFENSYWNY = "Ofensywny";
        private static readonly string POMOCNICZY = "Pomocniczy";
        private static readonly string DEFENSYWNY = "Defensywny";


        private Dictionary<string, Object> Podklasy = new Dictionary<string, Object>();
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

        public string Imie {
            get
            {
                return Imie;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Incorrect argument");
                Imie = value;
            }
        }

        private List<Umiejetnosc> Umiejetnosci { get; set; } = new List<Umiejetnosc>();
        public List<Umiejetnosc> GetUmiejetnosci(){ return new List<Umiejetnosc>(Umiejetnosci); }

        public Stan Stan { get; set; }

        private Bohater(string imie, List<Umiejetnosc> umiejetnosci){
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
            if(Umiejetnosci.Count <= MAX_UMIEJETNOSC)
                Umiejetnosci.Add(umiejetnosc);
            else
                throw new ArgumentException($"Field can only have {MAX_UMIEJETNOSC} elements");
        }

        public void UstawStatystyki(int? silaObrazenKrytycznych = null, int? przelicznikLeczenia = null, int? punktyWytrzymalosci = null){
            if(silaObrazenKrytycznych.HasValue && Podklasy.ContainsKey(OFENSYWNY))
                ((BohaterOfensywny)Podklasy[OFENSYWNY]).UstawStatystyki(silaObrazenKrytycznych.Value);
            if(punktyWytrzymalosci.HasValue && Podklasy.ContainsKey(DEFENSYWNY))
                ((BohaterDefensywny)Podklasy[DEFENSYWNY]).UstawStatystyki(punktyWytrzymalosci.Value);
            if(przelicznikLeczenia.HasValue && Podklasy.ContainsKey(POMOCNICZY))
                ((BohaterPomocniczy)Podklasy[POMOCNICZY]).UstawStatystyki(przelicznikLeczenia.Value);
        }

        class BohaterOfensywny{
            public int SilaObrazenKrytycznych { get; private set; }
        
            public BohaterOfensywny(int silaObrazenKrytycznych){
                UstawStatystyki(silaObrazenKrytycznych);
            }
            public void UstawStatystyki(int silaObrazenKrytycznych){
                if(silaObrazenKrytycznych < 0)
                        throw new ArgumentException("Incorrect argument");
                SilaObrazenKrytycznych = silaObrazenKrytycznych; 
            }
        }
        class BohaterDefensywny{
            public int PunktyWytrzymalosci { get; private set; }
        
            public BohaterDefensywny(int punktyWytrzymalosci){
                UstawStatystyki(punktyWytrzymalosci);
            }

            public void UstawStatystyki(int punktyWytrzymalosci){
                if(punktyWytrzymalosci < 0)
                    throw new ArgumentException("Incorrect argument");
                PunktyWytrzymalosci = punktyWytrzymalosci;
            }
        }
        class BohaterPomocniczy{
            public int PrzelicznikLeczenia { get; private set; }
           
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