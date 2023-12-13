using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreProjetC
{
    class Matiere
    {
        public string Libelle { get; set; }
        public string MatriculeEns { get; set; }
        public string NbreHeure { get; set; }

        public Matiere(string libelle, string matriculeE, string nbreH)
        {
            Libelle = libelle;
            MatriculeEns = matriculeE;
            NbreHeure = nbreH;
        }
    }
}
