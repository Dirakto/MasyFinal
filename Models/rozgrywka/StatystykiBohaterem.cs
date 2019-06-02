using System;
using VSCode.Models.bohater;

namespace VSCode.Models.rozgrywka
{
    public class StatystykiBohaterem
    {
        public RozgrywkaGracza RozgrywkaGracza {
            get
            {
                return RozgrywkaGracza;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Incorrect argument");
                RozgrywkaGracza = value;
                value.AddStatystykiBohaterem(this);
            }
        }

        public Bohater Bohater {
            get
            {
                return Bohater;
            }
            set
            {
                if(value == null)
                    throw new ArgumentException("Incorrect argument");
                Bohater = value;
            }
        }

        private int _LiczbaZabojstw = 0;
        public int LiczbaZabojstw {
            get
            {
                return _LiczbaZabojstw;
            }
            set
            {
                if(value < 0 || value < _LiczbaZabojstw)
                    throw new ArgumentException("Incorrect argument");
                _LiczbaZabojstw = value;
            }
        }
    
        private int _LiczbaZgonow = 0;
        public int LiczbaZgonow {
            get
            {
                return _LiczbaZgonow;
            }
            set
            {
                if(value < 0 || value < _LiczbaZgonow)
                    throw new ArgumentException("Incorrect argument");
                _LiczbaZgonow = value;
            }
        }
    
        private int _LiczbaAsyst = 0;
        public int LiczbaAsyst {
            get
            {
                return _LiczbaAsyst;        
            }
            set
            {
                if(value < 0 || value < _LiczbaAsyst)
                    throw new ArgumentException("Incorrect argument");
                _LiczbaAsyst = value;
            }
        }
    
        public long CzasGry { get; set; } = 0;

        public StatystykiBohaterem(RozgrywkaGracza rozgrywkaGracza, Bohater bohater){
            RozgrywkaGracza = rozgrywkaGracza;
            Bohater = bohater;
        }
    }
}