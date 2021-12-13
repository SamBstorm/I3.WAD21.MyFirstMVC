using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int Minutes { get; set; }
        public DateTime RealeaseDate { get; set; }
    }
}
