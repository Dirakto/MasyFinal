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
        
        private List<OsiagniecieGracza> OsiagnieciaGraczy = new List<OsiagniecieGracza>();
        public List<OsiagniecieGracza> GetOsiagnieciaGraczy(){ return new List<OsiagniecieGracza>(OsiagnieciaGraczy); }
        public void AddOsiagniecieGracza(OsiagniecieGracza og){
            if(og != null && !OsiagnieciaGraczy.Contains(og))
                OsiagnieciaGraczy.Add(og);
        }

        public String Nazwa { 
            get
            { 
                return Nazwa;
            }
            set
            {
                if(value == null || value.Length == 0)
                    throw new ArgumentException("Incorrect argument");
                Nazwa = value;
            }
        }

        public Osiagniecie(){}
        public Osiagniecie(String nazwa){
            Nazwa = nazwa;
        }

    }

}