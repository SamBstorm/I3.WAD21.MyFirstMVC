using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Models
{
    public class LoginForm
    {
        [Required(ErrorMessage = "L'adresse email est obligatoire.")]
        [EmailAddress(ErrorMessage ="L'adresse n'est au bon format.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Adresse électronique : ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$",ErrorMessage = "Le mot de passe doit au minimum un nombre, une minuscule, une majuscule, un caractère parmis '@#$%^&-+=()', aucun espace blanc, compris entre 8 et 20 caractères.")]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe : ")]
        public string Passwd { get; set; }
        
        // Si notre formulaire contient une liste de checkbox, et que ces dernières ont une valeur : alors chaque valeur cochée seront stocké dans un tableau
        //public string[] Checkboxes { get; set; }
    }
}
