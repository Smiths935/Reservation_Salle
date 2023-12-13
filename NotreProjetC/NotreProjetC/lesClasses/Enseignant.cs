using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreProjetC
{
    class Enseignant
    {
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Tel { get; set; }

        public Enseignant(string matricule, string nom,string tel)
        {
            Matricule = matricule;
            Nom = nom;
            Tel = tel;
        }
    }
    
}
