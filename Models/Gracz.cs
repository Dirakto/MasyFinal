using System;
using System.Collections.Generic;
using VSCode.Models.osiagniecie;
using VSCode.Models.sezon;
using VSCode.Models.rozgrywka;
using System.ComponentModel.DataAnnotations;

namespace VSCode.Models
{
    public class Gracz
    {
        [Key]
        public int Id { get; set; }

        private List<RozgrywkaGracza> RozgrywkiGracza = new List<RozgrywkaGracza>();
        public List<RozgrywkaGracza> GetRozgrywkiGracza(){ return new List<RozgrywkaGracza>(RozgrywkiGracza); }
        public void AddRozgrywkaGracza(RozgrywkaGracza rg){
            if(rg != null && !RozgrywkiGracza.Contains(rg))
                RozgrywkiGracza.Add(rg);
        }

        private List<OsiagniecieGracza> OsiagnieciaGracza = new List<OsiagniecieGracza>();
        public List<OsiagniecieGracza> getOsiagnieciaGracza(){ return new List<OsiagniecieGracza>(OsiagnieciaGracza); }
        public void AddOsiagniecieGracza(OsiagniecieGracza og){
            if(og != null && !OsiagnieciaGracza.Contains(og))
                OsiagnieciaGracza.Add(og);
        }

        private List<Ranking> Rankingi = new List<Ranking>();
        public List<Ranking> getRankingi(){ return new List<Ranking>(Rankingi); }
        public void AddRanking(Ranking r){
            if(r != null && !Rankingi.Contains(r))
                Rankingi.Add(r);
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

        private string _Nazwisko;
        public string Nazwisko { 
            get
            {
                return _Nazwisko;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Incorrect argument");
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
                    throw new ArgumentException("Incorrect argument");
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

        // AKTUALNY POZIOM GRACZA

 
        public GraczStatus Status { get; set; }

        private Gracz(){}
        public Gracz(string imie, string nazwisko, string pseudonim){
            Imie = imie;
            Nazwisko = nazwisko;
            Pseudonim = pseudonim;
            Status = GraczStatus.Nieaktywny;
        }




        private int GenerateBattleTag(){
            return new Random().Next(1000, 10000);
        }

        // public void WyswietlPoziom(Sezon sezon);


    }

    public enum GraczStatus{ Aktywny, Nieaktywny, Zablokowany }

}