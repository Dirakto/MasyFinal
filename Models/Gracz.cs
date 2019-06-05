using System;
using System.Collections.Generic;
using VSCode.Models.osiagniecie;
using VSCode.Models.sezon;
using VSCode.Models.rozgrywka;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VSCode.Models
{
    public class Gracz
    {
        [Key]
        public int Id { get; set; }

        private List<RozgrywkaGracza> _RozgrywkiGracza = new List<RozgrywkaGracza>();
        public List<RozgrywkaGracza> RozgrywkiGracza {
            get
            {
                return _RozgrywkiGracza;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Value cannot be null");
                _RozgrywkiGracza = value;
            }
        }
        public void AddRozgrywkaGracza(RozgrywkaGracza rg){
            if(rg != null && !RozgrywkiGracza.Contains(rg)){
                if(rg.Gracz == this)
                    RozgrywkiGracza.Add(rg);
            }
        }

        private List<OsiagniecieGracza> _OsiagnieciaGracza = new List<OsiagniecieGracza>();
        public List<OsiagniecieGracza> OsiagnieciaGracza {
            get
            {
                return _OsiagnieciaGracza;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Value cannot be null");
                _OsiagnieciaGracza = value;
            }
        }
        public void AddOsiagniecieGracza(OsiagniecieGracza og){
            if(og != null && !OsiagnieciaGracza.Contains(og)){
                if(og.Gracz == this)
                    OsiagnieciaGracza.Add(og);
            }
        }

        private List<Ranking> _Rankingi = new List<Ranking>();
        public List<Ranking> Rankingi {
            get
            {
                return _Rankingi;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Value cannot be null");
                _Rankingi = value;
            }
        }
        public void AddRanking(Ranking r){
            if(r != null && !Rankingi.Contains(r)){
                if(r.Gracz == this)
                    _Rankingi.Add(r);
            }
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
                    throw new ArgumentException("Value cannot be null nor 0 length");
                _Imie = value;
            }
        }

        private string _Nazwisko;
        public string Nazwisko { 
            get
            {
                return _Nazwisko;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Value cannot be null nor 0 length");
                _Nazwisko = value;
            }
        }

        // !!!!!!!!!!!! A nie baza danych?
        private static Dictionary<string, List<int>> PseudonimBattleTagDictionary = new Dictionary<string, List<int>>();

        private string _Pseudonim;
        public string Pseudonim { 
            get
            {
                return _Pseudonim;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Value cannot be null nor 0 length");
                _Pseudonim = value;

                if(!PseudonimBattleTagDictionary.ContainsKey(value)){
                    BattleTag = GenerateBattleTag();
                    List<int> tmp = new List<int>();
                    tmp.Add(BattleTag);
                    PseudonimBattleTagDictionary.Add(value, tmp);
                }else{
                    List<int> list = PseudonimBattleTagDictionary[value];
                    int newBattleTag = GenerateBattleTag();
                    while(list.Contains(newBattleTag))
                        newBattleTag = GenerateBattleTag();

                    list.Add(newBattleTag);
                    BattleTag = newBattleTag;
                }
            }
        }

        public int BattleTag { get; private set; }

        // AKTUALNY POZIOM GRACZA !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public int AktualnyPoziom {
            get
            {
                return AppDbContext.Context.Rankingi.Where(s => s.SezonId == Sezon.AKTUALNY_SEZON.Id).First().Poziom;
            }
        }
 
        public GraczStatus Status { get; set; }

        private Gracz(){}
        public Gracz(string imie, string nazwisko, string pseudonim){
            Imie = imie;
            Nazwisko = nazwisko;
            Pseudonim = pseudonim;
            Status = GraczStatus.Nieaktywny;
            AddRanking(new Ranking(this, Sezon.AKTUALNY_SEZON));
        }




        private int GenerateBattleTag(){
            return new Random().Next(1000, 10000);
        }

        // public void WyswietlPoziom(Sezon sezon);


    }

    public enum GraczStatus{ Aktywny, Nieaktywny, Zablokowany }

}