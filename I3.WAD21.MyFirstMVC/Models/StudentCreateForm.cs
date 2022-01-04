using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Models
{
    public class StudentCreateForm
    {
        [Required]
        [DisplayName("Prénom")]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de naissance")]
        public DateTime BirthDate { get; set; }
        [Required]
        [DisplayName("Identifiant du Cours")]
        public string Course { get; set; }
        [Required]
        [DisplayName("Identifiant de Section")]
        public int Section { get; set; }
    }
}
