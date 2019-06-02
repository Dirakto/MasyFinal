using System;
using System.ComponentModel.DataAnnotations;

namespace VSCode.Models.osiagniecie
{
    public class OsiagniecieGracza {

        [Key]
        public int Id { get; set; }

        public int GraczId { get; set; }
        private Gracz _Gracz;
        public Gracz Gracz {
            get
            {
                return _Gracz;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Gracz reference not set to an instance of an object");
                _Gracz = value;
                value.AddOsiagniecieGracza(this);
            }
        }

        public int OsiagniecieId { get; set; }
        private Osiagniecie _Osiagniecie;
        public Osiagniecie Osiagniecie {
            get
            {
                return _Osiagniecie;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Osiagniecie reference not set to an instance of an object");
                _Osiagniecie = value;
                value.AddOsiagniecieGracza(this);
            }
        }

        private int _aktualnyStatus;
        public int AktualnyStatus {
            get
            {
                return _aktualnyStatus;
            }
            set
            {
                if (value < _aktualnyStatus)
                    throw new ArgumentException("Argument lower than the current one");
                _aktualnyStatus = value;
            }
        }

        private OsiagniecieGracza(){}
        public OsiagniecieGracza(Gracz gracz, Osiagniecie osiagniecie){
            Gracz = gracz;
            Osiagniecie = osiagniecie;
            _aktualnyStatus = 0;
        }

        public void WyzerujStatus(){
            _aktualnyStatus = 0;
        }

    }
}