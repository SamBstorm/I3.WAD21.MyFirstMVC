using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Models
{
    public class StudentListItem
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int Section { get; set; }
    }
}
