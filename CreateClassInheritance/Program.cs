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
            Employee Kovacs = new Employee("géza", DateTime.Now, 1000, "léhűtő");
            Kovacs.Room = new Room(111);
            Employee Kovacs2 = (Employee)Kovacs.Clone();
            Kovacs2.Room.Number = 112;
            Console.WriteLine(Kovacs.ToString());
            Console.WriteLine(Kovacs2.ToString());
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
            return string.Format("Name: {0} \nBirth Date: {1} \nAge: {2} \nGender: {3}",
                this.Name, this.BirthDate, this.Age, this.Gender);
        }
    }

    class Employee : Person, ICloneable
    {
        public string Profession { get; set; }
        public int Salary { get; set; }
        public Room Room { get; set; }
        public int RoomNumber { get; set; }

        public Employee(string name, DateTime birthday, int salary, string profession)
        {
            this.Name = name;
            this.BirthDate = birthday;
            this.Salary = salary;
            this.Profession = profession;
        }

        public Employee(string name, string birthday, Genders gender, string profession, int salary, Room room)
        {
            this.Name = name;
            this.BirthDate = DateTime.Parse(birthday);
            this.Gender = gender;
            this.Profession = profession;
            this.Salary = salary;
            this.Room = room;
            this.RoomNumber = room.Number;
            this.Age = (DateTime.Now.DayOfYear >= this.BirthDate.DayOfYear) 
                ? DateTime.Now.Year - this.BirthDate.Year : (DateTime.Now.Year - this.BirthDate.Year) - 1;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} \nBirth Date: {1} \nAge: {2} \nGender: {3} \nProfession: {4} \nSalary: {5} \nRoom number: {6}"
                , this.Name, this.BirthDate, this.Age, this.Gender, this.Profession, this.Salary, this.Room.Number);
        }

        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}

        public object Clone()
        {
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.Room = new Room(Room.Number);
            return newEmployee;
        }
    }

    class Room
    {
        public int Number { get; set; }

        public Room(int number)
        {
            this.Number = number;
        }
    }
}
