using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Validation
    {
        public static int ValidateInteger(string Input)
        {
            int Answer;
            Input = Console.ReadLine();
            while (int.TryParse(Input, out int Result) != true)
            {
                Console.WriteLine("You did not enter a valid number choice. Please try again.");
                Input = Console.ReadLine();
            }
            Answer = int.Parse(Input);
            return Answer;
        }

        public static int ValidateString(string Input)
        {
            int Answer = -1;

            if (string.Compare(Input, "First Name", true) == 0)
            {
                Answer = 0;
            }
            else if (string.Compare(Input, "Last Name", true) == 0)
            {
                Answer = 1;
            }
            else if (string.Compare(Input, "Favorite Food", true) == 0)
            {
                Answer = 2;
            }
            else if (string.Compare(Input, "Hometown", true) == 0)
            {
                Answer = 3;
            }
            else if (string.Compare(Input, "Favorite Color", true) == 0)
            {
                Answer = 4;
            }
            else
            {
                Console.WriteLine("You may enter 'First Name', 'Last Name', 'Favorite Food', 'Hometown', or 'Favorite Color'.");
                Input = Console.ReadLine();
                ValidateString(Input);
            }
            return Answer;
        }

    }

    class Students
    {
        public static string GiveStudentData(int Row, int Column, string[,] Students)
        {
            string StudentSentence = "";
            string StudentName, StudentDataType, StudentData = Students[Row, Column];
            IndexOutOfRangeException error1 = new IndexOutOfRangeException();

            if (Row <= Students.GetUpperBound(0))
            {
                StudentName = Students[Row, 0];
            }
            else
            {
                throw error1;
            }

            switch (Column)
            {
                case 0:
                    StudentDataType = "first name";
                    break;
                case 1:
                    StudentDataType = "last name";
                    break;
                case 2:
                    StudentDataType = "favorite food";
                    break;
                case 3:
                    StudentDataType = "hometown";
                    break;
                case 4:
                    StudentDataType = "favorite color";
                    break;
                default:
                    throw error1;
            }

            Console.WriteLine($"{0}'s {1} is {3}", StudentName, StudentDataType, StudentData);
            return StudentSentence;
        }

        public static string[,] DataRecords()
        {
            string[,] StudentData = new string[6, 5];
            StudentData[0, 0] = "Johnny";
            StudentData[0, 1] = "Smith";
            StudentData[0, 2] = "Mac & Cheese";
            StudentData[0, 3] = "Warren, Michigan";
            StudentData[0, 4] = "Blue";
            StudentData[1, 0] = "Susie";
            StudentData[1, 1] = "Bennett";
            StudentData[1, 2] = "Chicken Alfredo";
            StudentData[1, 3] = "Livonia, Michigan";
            StudentData[1, 4] = "Orange";
            StudentData[2, 0] = "James";
            StudentData[2, 1] = "Brown";
            StudentData[2, 2] = "Fish 'n Chips";
            StudentData[2, 3] = "Toledo, Ohio";
            StudentData[2, 4] = "Green";
            StudentData[3, 0] = "Michelle";
            StudentData[3, 1] = "O'Grady";
            StudentData[3, 2] = "Chicken Pot Pie";
            StudentData[3, 3] = "Woodhaven, Michigan";
            StudentData[3, 4] = "Purple";
            StudentData[4, 0] = "Patrick";
            StudentData[4, 1] = "Williams";
            StudentData[4, 2] = "Pierogis";
            StudentData[4, 3] = "Hamtramck, Michigan";
            StudentData[4, 4] = "Gray";
            StudentData[5, 0] = "Belinda";
            StudentData[5, 1] = "Swann";
            StudentData[5, 2] = "Chicken Picatta";
            StudentData[5, 3] = "Royal Oak, Michigan";
            StudentData[5, 4] = "Pink";
            return StudentData;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Validation MyValidation = new Validation();
            Students MyStudents = new Students();

            int Selection1, Selection2;
            string GetSelection1 = "", GetSelection2 = "", MoreAbout = "", AnotherStudent = "";
            bool Repeat1, Repeat2 = true;
            

            string[,] MyStudentArray = Students.DataRecords();


            Console.WriteLine("Welcome to the class information lookup. You can ask me about different students in the class.");

            while (Repeat2 == true)
            {
                Repeat1 = true;
                Console.WriteLine("\nWhich student would you like to learn about? Please enter a number based on the following list:");
                for (int i = 0; i <= MyStudentArray.GetUpperBound(0); i++)
                {
                    Console.WriteLine($"{i + 1}: {MyStudentArray[i, 0]}");
                }
                Selection1 = Validation.ValidateInteger(GetSelection1);
                Console.WriteLine($"Student {Selection1} is {MyStudentArray[Selection1 - 1, 0]} {MyStudentArray[Selection1 - 1, 1]}.");

                while (Repeat1 == true)
                {
                    Console.WriteLine($"What would you like to know about {MyStudentArray[Selection1 - 1, 0]}?");
                    Console.WriteLine("You may enter 'First Name', 'Last Name', 'Favorite Food', 'Hometown', or 'Favorite Color'.");

                    GetSelection2 = Console.ReadLine();
                    Selection2 = Validation.ValidateString(GetSelection2);
                    Console.WriteLine($"{MyStudentArray[Selection1 - 1, 0]}'s {GetSelection2} is {MyStudentArray[Selection1 - 1, Selection2]}.");
                    Console.WriteLine($"Would you like to know more about {MyStudentArray[Selection1 - 1, 0]}? (Y or N)");
                    MoreAbout = Console.ReadLine();
                    if (string.Compare(MoreAbout, "N", true) == 0)
                    {
                        Repeat1 = false;
                    }
                }
                Console.WriteLine("Would you like to learn about another student? (Y or N)");
                AnotherStudent = Console.ReadLine();
                if (string.Compare(AnotherStudent, "N", true) == 0)
                {
                    Console.WriteLine("Press enter to end the program. Goodbye!");
                    Repeat2 = false;
                    Console.Read();
                }

            }
            
        }
    }
}


    