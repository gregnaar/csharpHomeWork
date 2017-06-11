using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Person me = new Person();
            me.BirthDate = DateTime.Parse("1987.11.16");
            me.Name = "Adam";
            me.Age = (DateTime.Now.DayOfYear >= me.BirthDate.DayOfYear) ? DateTime.Now.Year - me.BirthDate.Year : (DateTime.Now.Year - me.BirthDate.Year) - 1;
            me.Gender = Person.Genders.Man;
            Console.WriteLine(me.ToString());

            Console.ReadLine();
        }
    }
    class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public Genders Gender { get; set; }


        public enum Genders
        {
            Man,
            Woman
        };

        public override string ToString()
        {
            return string.Format("Name: {0} \nBirth Date: {1} \nAge: {2} \nGender: {3}", this.Name, this.BirthDate, this.Age, this.Gender);
        }

        public static void IHateGit()
        {
            Console.WriteLine("I really do hate it right now. :(");
        }
    }
}
