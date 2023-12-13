using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreProjetC
{
    class SalleDeClasse
    {
      //  public string ID { get; set; }
        public string Capacite { get; set; }
        public string Disponibilite { get; set; }

        public SalleDeClasse( string capacite, string dispo)
        {
         //   ID = id;
            Capacite =capacite;
            Disponibilite = dispo;

        }
    }
}
