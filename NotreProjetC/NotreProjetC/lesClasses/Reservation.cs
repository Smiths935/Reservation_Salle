using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreProjetC
{
    class Reservation
    {
        public string DateR { get; set; }
        public string HeureD { get; set; }
        public string HeureF { get; set; }
        public string IDE { get; set; }
        public string IDS { get; set; }
        public string numSalle { get; set; }
        public string NommEnse { get; set; }
        public string Matiere { get; set; }

        public Reservation(string dater, string heured, string heuref, string ide,string ids, string numsalle, string nomense, string matiere)
        {
            DateR = dater;
            HeureD = heured;
            HeureF= heuref;
            IDE = ide;
            IDS = ids;
            numSalle = numsalle;
            NommEnse = nomense;
            Matiere = matiere;
        }
    }
}
