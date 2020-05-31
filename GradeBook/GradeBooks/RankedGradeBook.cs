using GradeBook.GradeBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count<5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            int X = (int)Math.Round(Students.Count * 20.0 / 100,0);
            var orderedGrades = Students.OrderBy(s => s.AverageGrade).Select(s => s.AverageGrade).Reverse();
            var aGradeStudents = orderedGrades.Take(X);
            var bGradeStudents = orderedGrades.Skip(X).Take(X);
            var cGradeStudents = orderedGrades.Skip(X * 2).Take(X);
            var dGradeStudents = orderedGrades.Skip(X * 3).Take(X);
            if (averageGrade >= aGradeStudents.Min()) return 'A';
            if (averageGrade >= bGradeStudents.Min()) return 'B';
            if (averageGrade >= cGradeStudents.Min()) return 'C';
            if (averageGrade >= dGradeStudents.Min()) return 'D';
            return 'F';
        }
    }
}
