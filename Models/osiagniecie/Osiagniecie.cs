using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSCode.Models.osiagniecie
{

    public abstract class Osiagniecie
    {
        [Key]
        public int Id { get; set; }
        
        private List<OsiagniecieGracza> _OsiagnieciaGraczy = new List<OsiagniecieGracza>();
        public List<OsiagniecieGracza> OsiagnieciaGraczy {
            get
            {
                return _OsiagnieciaGraczy;
            }
            private set
            {
                if(value == null)
                    throw new ArgumentException("Value cannot be null");
                _OsiagnieciaGraczy = value;
            }
        }
        public void AddOsiagniecieGracza(OsiagniecieGracza og){
            if(og != null && !OsiagnieciaGraczy.Contains(og)){
                if(og.Osiagniecie == this)
                    OsiagnieciaGraczy.Add(og); // do sprawdzenia !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
        }

        private String _Nazwa;
        public String Nazwa {
            get
            { 
                return _Nazwa;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Value cannot be null nor 0 length");
                _Nazwa = value;
            }
        }

        public Osiagniecie(){}
        public Osiagniecie(String nazwa){
            Nazwa = nazwa;
        }

    }

}