namespace Lecture_11
{
    internal class Program
    {
        // Declare the arrays at the class scope 
        static string[] firstNames = { "Alice", "Bob", "Charlie", "David", "Eva" };
        static string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown" };
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Display All Students");
                Console.WriteLine("2. Check if a Student is Enrolled");
                Console.WriteLine("3. Display Full Student Information");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllStudents();
                        break;
                    case "2":
                        Console.Write("Enter the last name to check enrollment: ");
                        string? lastName = Console.ReadLine();
                        if (EnrolledInClassByLastName(lastName))
                        {
                            Console.WriteLine("Yes, the student is enrolled");
                        }
                        else
                        {
                            Console.WriteLine("No, the student is not enrolled");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter the last name to find the student: ");
                        string? studentLastName = Console.ReadLine();
                        int index = FindStudentIdByLastName(studentLastName);
                        if (index != -1)
                        {
                            DisplayStudentInformation(index);
                        }
                        else
                        {
                            Console.WriteLine("Student is not enrolled");
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine(); // Add an additional blank line
            }
        }

        static string FullName(int studentIndex)
        {
            return $"{firstNames[studentIndex]} {lastNames[studentIndex]}";
        }

        static void DisplayStudentInformation(int studentIndex)
        {
            Console.WriteLine($"Student Id: {studentIndex}");
            Console.WriteLine($"Full Name: {FullName(studentIndex)}");
            Console.WriteLine($"First Name: {firstNames[studentIndex]}");
            Console.WriteLine($"Last Name: {lastNames[studentIndex]}");
            Console.WriteLine(); // Add an additional blank line
        }

        static void DisplayAllStudents()
        {
            for (int i = 0; i < firstNames.Length; i++)
            {
                DisplayStudentInformation(i);
            }
        }

        static bool EnrolledInClassByLastName(string studentsLastName)
        {
            foreach (string lastName in lastNames)
            {
                if (lastName.Equals(studentsLastName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        static int FindStudentIdByLastName(string studentLastName)
        {
            for (int i = 0; i < lastNames.Length; i++)
            {
                if (lastNames[i].Equals(studentLastName, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
