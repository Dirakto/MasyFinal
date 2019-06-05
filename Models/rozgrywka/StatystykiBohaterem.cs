using System;
using System.ComponentModel.DataAnnotations;
using VSCode.Models.bohater;

namespace VSCode.Models.rozgrywka
{
    public class StatystykiBohaterem
    {

        [Key]
        public int Id { get; set; }

        public int RozgrywkaGraczaId { get; set; }
        private RozgrywkaGracza _RozgrywkaGracza;
        public RozgrywkaGracza RozgrywkaGracza {
            get
            {
                return _RozgrywkaGracza;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Incorrect argument");
                _RozgrywkaGracza = value;
                value.AddStatystykiBohaterem(this);
            }
        }

        public int BohaterId { get; set; }
        private Bohater _Bohater;
        public Bohater Bohater {
            get
            {
                return _Bohater;
            }
            set
            {
                if(value == null)
                    throw new ArgumentException("Incorrect argument");
                _Bohater = value;
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

        private StatystykiBohaterem(){}
        public StatystykiBohaterem(RozgrywkaGracza rozgrywkaGracza, Bohater bohater){
            RozgrywkaGracza = rozgrywkaGracza;
            Bohater = bohater;
        }
    }
}