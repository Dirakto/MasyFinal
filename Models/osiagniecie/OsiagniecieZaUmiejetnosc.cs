using System;

namespace VSCode.Models.osiagniecie
{
    public class OsiagniecieZaUmiejetnosc : Osiagniecie {

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

        public int MaksymalnyWynik { 
            get
            {
                return MaksymalnyWynik;
            }
            set
            {
                if(value <= 0)
                    throw new ArgumentException("Incorrect argument");
                MaksymalnyWynik = value;
            }
        }

        private OsiagniecieZaUmiejetnosc(){}
        public OsiagniecieZaUmiejetnosc(string nazwa, int maksymalnyWynik, string opis) : base(nazwa){
            MaksymalnyWynik = maksymalnyWynik;
            Opis = opis;
        }

    }
}