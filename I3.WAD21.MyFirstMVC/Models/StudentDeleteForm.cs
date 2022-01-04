using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Models
{
    public class StudentDeleteForm
    {
        [DisplayName("Nom de famille")]
        public string Nom { get; set; }
        [DisplayName("Prénom")]
        public string Prenom { get; set; }
        public string Login { get; set; }
        [Required]
        [DisplayName("Êtes-vous sûr de vouloir supprimer cet étudiant?")]
        public bool Validate { get; set; }
    }
}
