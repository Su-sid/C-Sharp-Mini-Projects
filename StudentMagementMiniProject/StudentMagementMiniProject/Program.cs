// Nullable references -- they help handle scenarios where a reference type can be a null 

using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace StudentManagement
{
    //1. Nullable References
    class Student
    {
        private string FirstName;

        private string? MiddleName;

        private string LastName;

        public Student (string firstName, string? middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
        
        public void PrintFullName()
        {
            if (MiddleName is null) {
                Console.WriteLine(@$"{FirstName} {LastName}");

            }
            else
            {
                Console.WriteLine(@$"{FirstName}{MiddleName}{LastName}");
            }
        }
        //END OF CLASS STUDENT

    }
    //2. Iterators and the yield Keyword
    //START OF STUDENTCOLLECTION CLASS
    class StudentCollection
    {
        List<string> Students= new List<string>();

        public IEnumerator<string> GetStudentsStartingWith (char letter)
        {
            foreach (var student in Students )
            {
                if (student.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    yield return student;
                }
            }

        }
        // END OF CLASS STUDENTCOLLECTION
        
        // 3. Casting and Type Conversions
        //START OF PERSON CLASS
        class Person
        {
            private string name;
            public string Name
            {
                get => name;
                set => name = value;
            }

            //END OF PERSON CLASS

        }
        //START OF STUDENT CLASS
        class Student :Person

        {
            private int grade;
            public int Grade { get; set; }

            public void printDetails()
            {
                Console.WriteLine(@$"NAME:{Name} GRADE:{Grade}");

            }
        }

        public void DemoCasting()
        {
            Student std1 = new Student();
            std1.Name = "John Doe";
            std1.Grade = 89;

            Console.WriteLine($@"my name is {std1.Name} and my grade is {std1.Grade}");


            //casting from student to person 
            Person prsn1 = std1;
            prsn1.Name = "Jacob Jones";

            Console.WriteLine($@"my name is {prsn1.Name} ");

            //explicit casting back to students to access grade
            Student std1Again = (Student)prsn1;
            std1Again.printDetails();

        }
        //4. Classes and Structs: Override and new Keyword
        // START OF THE STUDENTID CLASS
        class StudentID
        {
            public int ID;
            public virtual string ToString()
            {
                return $"ID: {ID.ToString()}";
            }
        }
        class SpecialStudentID: StudentID
        {
            public override string ToString()
            {
                return $@"Special ID:{ID.ToString()}";
            }
        }
        //5. Classes and Structs: Members


    }


    // END OF NAMESPACE
}