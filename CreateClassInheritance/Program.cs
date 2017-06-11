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

            Room myRoom = new Room() { RoomNumber = 1 };

            Employee adam = new Employee("Adam", "1987.11.16", Person.Genders.Man, "Programmer", 3000000, myRoom);
            Console.WriteLine(adam.ToString());

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

    class Employee : Person
    {
        public string Profession { get; set; }
        public int Salary { get; set; }
        public int RoomNumber { get; set; }

        public Employee(string name, string birthday, Genders gender, string profession, int salary, Room room)
        {
            this.Name = name;
            this.BirthDate = DateTime.Parse(birthday);
            this.Gender = gender;
            this.Profession = profession;
            this.Salary = salary;
            this.RoomNumber = room.RoomNumber;
            this.Age = (DateTime.Now.DayOfYear >= this.BirthDate.DayOfYear) 
                ? DateTime.Now.Year - this.BirthDate.Year : (DateTime.Now.Year - this.BirthDate.Year) - 1;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} \nBirth Date: {1} \nAge: {2} \nGender: {3} \nProfession: {4} \nSalary: {5} \nRoom number: {6}"
                , this.Name, this.BirthDate, this.Age, this.Gender, this.Profession, this.Salary, this.RoomNumber);
        }
    }

    class Room
    {
        public int RoomNumber { get; set; }
    }
}
