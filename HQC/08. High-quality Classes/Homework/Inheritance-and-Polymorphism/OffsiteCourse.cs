namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
           this.Town = town;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, null)
        {
        }

        public OffsiteCourse(string courseName)
            : this(courseName, null)
        {
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                this.town = value;
            }
        }

        public override string ToString()
        {
            if (this.Town != null)
            {
                return base.ToString() + "; Town = " + this.Town + " }";
            }
            else
            {
                return base.ToString() + " }";
            }
        }

        private string GetStudentsAsString()
        {
            if (this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
