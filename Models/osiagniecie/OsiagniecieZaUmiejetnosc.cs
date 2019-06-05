using System;

namespace VSCode.Models.osiagniecie
{
    public class OsiagniecieZaUmiejetnosc : Osiagniecie {

        private string _Opis;
        public string Opis {
            get
            {
                return _Opis;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Value cannot be null nor 0 length");
                _Opis = value;
            }
        }
        
        private int _MaksymalnyWynik;
        public int MaksymalnyWynik { 
            get
            {
                return _MaksymalnyWynik;
            }
            set
            {
                if(value <= 0)
                    throw new ArgumentException("Value cannot be less or equal to 0");
                _MaksymalnyWynik = value;
            }
        }

        private OsiagniecieZaUmiejetnosc() : base(){}
        public OsiagniecieZaUmiejetnosc(string nazwa, int maksymalnyWynik, string opis) : base(nazwa){
            MaksymalnyWynik = maksymalnyWynik;
            Opis = opis;
        }

    }
}