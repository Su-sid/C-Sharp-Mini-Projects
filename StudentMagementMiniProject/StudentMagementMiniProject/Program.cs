

using StudentManagement;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace StudentManagement
{
    //1. Nullable References
    class PersonName
    {
        private string firstname;
        public string FirstName { get; set; }

        private string?middlename;
        public string? MiddleName {  get; set; }    

        private string lastname;
        public string LastName {  get; set; }

        public PersonName(string firstName, string? middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }


        public string PrintFullName()
        {
            if (MiddleName is null) {
                return @$"{FirstName} {LastName}";
                //Console.WriteLine(@$"{FirstName} {LastName}");

            }
            else
            {
                return @$"{FirstName}{MiddleName}{LastName}";
                //Console.WriteLine(@$"{FirstName}{MiddleName}{LastName}");
            }
        }
        public string ReturnFirstName() {
            return FirstName;
        }
        public string ReturnLastName() { return LastName; }

        
        //END OF CLASS STUDENT

    }
    //2. Iterators and the yield Keyword
    //START OF STUDENTCOLLECTION CLASS
    class StudentCollection
    {
        List<Student> Students = new List<Student>();
       //public StudentCollection( string Firstname, string? middlename, string lastname) 
       // { 

        
       // }  
        public void AddNewStudent(string studentId, string studentFirstName, string? studentMiddleName, string studentLastName)
        {

            var AStudent = new Student(studentFirstName, studentMiddleName, studentLastName);
            //AStudent.Add ( studentId);
            //AStudent.Add ( studentName);

            Students.Add(AStudent);

        }
        public List<Student> GetStudentList()
        {
            return Students;
        }

        public IEnumerator<string> GetStudentsStartingWith(char letter)
        {
            foreach (var student in GetStudentList())
            {
                if (student.FirstName.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    yield return student.FirstName;
                }
            }

        }
        //10. LINQ AND COLLECTIONS 
        // IMAGINE: query a list of students to get those above a certain grade. 
        public List<Student> GetTopStudents()
        {
            var listOfStudents = GetStudentList(); // Assuming this method returns a list of lists (e.g., List<List<string>>)

            // Create a list to store the top students
            var topStudents = new List<Student>();

            foreach (var student in listOfStudents)
            {

                //var studentGrade = student.Grade;

                // Check if the student's grade is greater than 75
                if (student.Grade > 75)
                {

                    topStudents.Add(student);
                }
            }

            return topStudents;
        }
    }
    // 3. Casting and Type Conversions
    //START OF PERSON CLASS
    class Person : PersonName
    {
        private string name;

        //public Person(string firstName, string? middleName, string lastName) : base(firstName, middleName, lastName)
        //{
        //}

        public Person(string firstName, string? middleName, string lastName) : base(firstName, middleName, lastName)
        {
            name = PrintFullName();
        }


        public string Name { get => name; } 
        //END OF PERSON CLASS

    }
    //START OF STUDENT CLASS
    class Student : Person
    {
        private int grade;
        private int id;

        public Student(string firstName, string? middleName, string lastName) : base(firstName, middleName, lastName)
        {
        }
        public int ID 
        { 
            get => id;  
            set =>id = value; 
        } 
        public int Grade { get; set; }
        public void printDetails()
        {
            Console.WriteLine(@$"NAME:{Name} GRADE:{Grade}");

        }


    }
    
    class demoCasting
    {
        public void DemoCasting()
        {
            Student std1 = new Student("John","", "Doe");
           

            Console.WriteLine($@"my name is {std1.Name} and my grade is {std1.Grade}");


            //casting from student to person 
            Person prsn1 = std1;
            //prsn1.Name = "Jacob Jones";

            Console.WriteLine($@"my name is {prsn1.Name} ");

            //explicit casting back to students to access grade
            Student std1Again = (Student)prsn1;
            std1Again.printDetails();

        }
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
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentCollection = new StudentCollection();

            // Menu loop for user interaction
            while (true)
            {
                Console.WriteLine("\nStudent Management System Menu");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Get Student List");
                Console.WriteLine("3. Find Students by Initial");
                Console.WriteLine("4. Get Top Students (Above 75 Grade - Placeholder)");
                Console.WriteLine("5. Demo Casting (Student to Person)");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentCollection);
                        break;
                    case "2":
                        GetStudentList(studentCollection);
                        break;
                    case "3":
                        FindStudentsByInitial(studentCollection);
                        break;
                    case "4":
                        Console.WriteLine("Get Top Students functionality is not yet implemented (placeholder).");
                        break;
                    case "5":
                        DemoCasting();
                        break;
                    case "6":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddStudent(StudentCollection
 studentCollection)
        {
            Console.Write("Enter student's first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter student's middle name (optional): ");
            string? middleName = Console.ReadLine();

            Console.Write("Enter student's last name: ");
            string lastName = Console.ReadLine();

            studentCollection.AddNewStudent("", firstName, middleName, lastName); // Replace "" with student ID generation logic
            Console.WriteLine("Student added successfully.");
        }

        static void GetStudentList(StudentCollection studentCollection)
        {
            List<Student> students = studentCollection.GetStudentList();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found in the list.");
                return;
            }

            Console.WriteLine("List of Students:");
            foreach (Student student in students)
            {
                student.printDetails();
            }
        }

        static void FindStudentsByInitial(StudentCollection studentCollection)
        {
            Console.Write("Enter the initial to search for: ");
            char initial = Console.ReadKey().KeyChar;

            Console.WriteLine(); // New line after user input

            IEnumerator<string> studentNames = studentCollection.GetStudentsStartingWith(initial);

            if (studentNames == null)
            {
                Console.WriteLine($"No students found starting with the initial '{initial}'.");
                return;
            }

            //Console.WriteLine($"Students starting with '{initial}':");
            //else 
            //{
            //    foreach (string name in studentNames)
            //    {
            //        Console.WriteLine(name);
            //    }

            //} 
        }

        static void DemoCasting()
        {
            Student std1 = new Student("John", "", "Doe");
            Console.WriteLine($"My name is {std1.Name} and my grade is {std1.Grade}"); // Assuming a default grade value

            Person prsn1 = std1;
            Console.WriteLine($"My name is {prsn1.Name}");

            Student std1Again = (Student)prsn1;
            std1Again.printDetails();
        }
    }


}


// END OF NAMESPACE
//}