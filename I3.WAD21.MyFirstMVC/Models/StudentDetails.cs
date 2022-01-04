using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Models
{
    public class StudentDetails
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Prénom")]
        public string Prenom { get; set; }
        [DisplayName("Nom de famille")]
        public string Nom { get; set; }
        [DisplayName("Identifiant de la Section")]
        public int Section { get; set; }
        [DisplayName("Identifiant du cours")]
        public string Course { get; set; }
        [DisplayName("Resultat annuel")]
        public int YearResult { get; set; }
        [DisplayName("Date de naissance")]
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
    }
}
