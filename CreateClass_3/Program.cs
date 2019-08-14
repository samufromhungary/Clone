using System;

namespace CreateClass_3
{
    class Program
    {
        public class Person
        {
            public string name;
            public DateTime birthDate;
            public enum Gender { Male, Female };
            public Gender gender;

            public Person(string name, DateTime birthDate, Gender gender)
            {
                this.name = name;
                this.birthDate = birthDate;
                this.gender = gender;
            }

            public override string ToString()
            {
                return "Name: " + name + " | Birth: " + birthDate + " | Gender: " + gender + " |";
            }
        }

        public class Room
        {
            public int roomNumber;

            public Room(int roomNumber)
            {
                this.roomNumber = roomNumber;
            }

            public override string ToString()
            {
                return roomNumber.ToString();
            }
        }

        public class Employee : Person, ICloneable
        {
            public int Salary;
            public string Profession;
            public Room Room;

            public Employee(string name, DateTime birthDate, Gender gender, int Salary, string Profession, Room room) : base(name, birthDate, gender)
            {
                this.Salary = Salary;
                this.Profession = Profession;
                Room = room;
            }

            public object Clone()
            {
                Employee newEmployee = (Employee)this.MemberwiseClone();
                newEmployee.Room = new Room(Room.roomNumber);
                return newEmployee;
            }

            public override string ToString()
            {
                return "Name: " + name + " | Birth: " + birthDate + " | Gender: " + gender + " | Salary: " + Salary + " | Profession: " + Profession + " | In Room: " + Room + " |";
            }
        }
        static void Main(string[] args)
        {
            Employee Kovacs = new Employee("Géza", DateTime.Now, Person.Gender.Male, 1000, "léhűtő", null);
            Kovacs.Room = new Room(111);
            Employee Kovacs2 = (Employee)Kovacs.Clone();
            Kovacs2.Room.roomNumber = 112;
            Console.WriteLine(Kovacs.ToString());
            Console.WriteLine(Kovacs2.ToString());
            Console.ReadKey();
        }
    }
}
