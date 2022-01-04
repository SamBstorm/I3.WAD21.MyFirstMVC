using DBSlideDataContext.DTO;
using I3.WAD21.MyFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Handlers
{
    public static class Mapper
    {
        public static StudentListItem ToListItem(this Student student)
        {
            if (student is null) return null;
            return new StudentListItem
            {
                Id = student.Student_ID,
                Nom = student.Last_Name,
                Prenom = student.First_Name,
                Section = student.Section_ID
            };
        }

        public static StudentDetails ToDetails(this Student student)
        {
            if (student is null) return null;
            return new StudentDetails
            {
                Id = student.Student_ID,
                Prenom = student.First_Name,
                Nom = student.Last_Name,
                Section = student.Section_ID,
                Course = student.Course_ID,
                Login = student.Login,
                BirthDate = student.BirthDate,
                YearResult = student.Year_Result
            };
        }

    }
}
