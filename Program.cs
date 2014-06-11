using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassHW
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creates an Array of Student[] and populates it with 5 entries
            Student[] stArray = new Student[] {
                new Student("Albin", "Huskanovic", "anhc1219@aubih.edu.ba", "Gracanica"),
                new Student("Bernes", "Cimpo", "hnco1312@aubih.edu.ba", "TZ"),
                new Student("Nerman", "Avdic", "nermanavdic1231@hotmail.com", "SA"),
                new Student("Mirza", "Djulic", "Mirzadjulic291@gmail.com", "Gracanica"),
                new Student("Rijad", "Haluidovic", "RijadHalidovic1337@live.com", "GR"),
            };

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
        }
    }

    class Person
    {
        protected string name, lastName;

        protected Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        protected string getPersonInfo()
        {
            return name + ", " + lastName;
        }
    }

    class Student : Person, IComparable<Student>
    {
        public string email { get; set; }
        private string Location;
        public string location
        {
            get
            {
                // Compares user's input and returns location string
                if (Location == "SA")
                {
                    return "Sarajevo";
                }
                else if (Location == "TZ")
                {
                    return "Tuzla";
                }
                else if (Location == "GR")
                {
                    return "Gracanica";
                }
                else
                {
                    return "Other";
                }
            }
            set
            {
                if (value == "SA" || value == "SARAJEVO" || value == "Sarajevo")
                {
                    Location = "SA";
                }
                else if (value == "TZ" || value == "TUZLA" || value == "Tuzla")
                {
                    Location = "TZ";
                }
                else if (value == "GR" || value == "GRACANICA" || value == "Gracanica")
                {
                    Location = "GR";
                }
                else
                {
                    Location = "NA";
                }
            }
        }

        public Student()
            : base("Albin", "Huskanovic")
        {
            // Returns parameters to Student() if no parameters were provided by the user
            this.email = "Anhc1219@aubih.edu.ba";
            this.location = "Gracanica";
        }

        // Student() destructor
        ~Student()
        {
            Console.WriteLine("Error. Student() destructor has been called.");
        }

        public Student(string name, string lastname, string email, string location)
            : base(name, lastname)
        {
            // Validates name and lastName
            // If true - prints data to screen
            if (setName(name) == true && setName(lastName) == true)
            {
                this.email = email;
                this.location = location;

                // Uses ToString() function to return/print student information
                Console.WriteLine(ToString());
            }
        }

        public bool setName(string input)
        {
            if (input.Length <= 2)
            {
                Console.WriteLine("Name must be at least two characters long");
                return false;
            }

            char[] cArray = input.ToCharArray();
            foreach (char c in cArray)
            {
                if (!char.IsLetter(c))
                {
                    Console.WriteLine("Name can only have letters");
                    return false;
                }
            }

            if (!char.IsUpper(cArray[0]))
            {
                Console.WriteLine("Name must start with an uppercase letter");
                return false;
            }

            return true;
        }

        public string getStudentInfo()
        {
            return base.getPersonInfo() + ", " + this.email + ", " + this.location;
        }

        public override string ToString()
        {
            return getStudentInfo();
        }

        public int CompareTo(Student student)
        {
            return this.email.CompareTo(student.email);
        }
    }
}