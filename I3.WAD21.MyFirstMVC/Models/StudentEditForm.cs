using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Models
{
    public class StudentEditForm
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        [Required]
        [DisplayName("Identifiant du Cours")]
        public string Course { get; set; }
        [Required]
        [DisplayName("Identifiant de la Section")]
        public int Section { get; set; }
        [DisplayName("Resultat Annuel")]
        [Required]
        [Range(0,20)]
        public int YearResult { get; set; }
    }
}
