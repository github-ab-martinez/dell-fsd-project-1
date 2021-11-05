using System;
using System.Collections.Generic;

namespace dell_fsd_project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            RunApp();
        }
        public enum Actions
        {
            list,
            search,
            update,
            exit
        }
        public static void RunApp()
        {
            Teacher classTeacher = new Teacher("Marti", "Martinez", "Class 1", "Section 1");
            Teacher classTeacher2 = new Teacher("Isaac", "Newton", "Physics", "Section 2");

            TeacherList teachers = new TeacherList();
            teachers.Teachers = new List<Teacher> { classTeacher, classTeacher2 };

            for (int i = 0; i < teachers.Teachers.Count; i++)
            {
                Console.WriteLine(teachers.Teachers[i].FirstName);
            }

            bool run = true;

            do
            {
                Console.WriteLine("Which of the following actions would you like to perform?");
                Console.WriteLine("List | Search | Update | Exit");
                string input = Console.ReadLine();
                
                if (System.Enum.TryParse<Actions>(input, true, out Actions action))
                {
                    string actionName = action.ToString();

                    if (actionName == "list")
                    {
                        PrintTeachersList(teachers);
                    }
                    else if (actionName == "search")
                    {
                        SearchForTeacher(teachers);
                    }
                    else if (actionName == "update")
                    {
                        UpdateTeacher(teachers);
                    }
                    else if (actionName == "exit")
                    {
                        Console.WriteLine("Exiting application. Goodbye.");
                        run = false;
                    }
                } else { 
                    Console.WriteLine("Invalid input.");
                }

            } while (run);
        }

        public static void PrintTeachersList(TeacherList teacherList) {
            teacherList.PrintList();
        }

        public static void SearchForTeacher(TeacherList teacherList)
        {
            int teacherId;
            bool validInput;

            do
            {
                Console.WriteLine("Please enter a valid id to search by:");
                string idInput = Console.ReadLine();
                validInput = int.TryParse(idInput, out teacherId);
            } while (!validInput);


            Teacher teacher = teacherList.GetTeacher(teacherId);

            if (teacher != null)
            {
                teacher.PrintTeacher();
            }
            else
            {
                Console.WriteLine("No teacher found with that Id.");
            }
        }

        public static void UpdateTeacher(TeacherList teacherList)
        {
            int teacherId;
            bool validInput;

            do
            {
                Console.WriteLine("Please enter the id of the teacher you'd like to update:");
                string idInput = Console.ReadLine();
                validInput = int.TryParse(idInput, out teacherId);
            } while (!validInput);


            Teacher teacher = teacherList.GetTeacher(teacherId);

            if (teacher != null)
            {   
                Console.WriteLine("Updating the following teacher information:");
                teacher.PrintTeacher();
                Console.WriteLine("Enter new info for the following prompts to update the respective field.\nLeave the field empty to keep current information as is.");
                Console.WriteLine("First Name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Last Name:");
                string lastName = Console.ReadLine();

                Console.WriteLine("Class:");
                string className = Console.ReadLine();

                Console.WriteLine("Section:");
                string section = Console.ReadLine();

                teacher.UpdateTeacher(firstName, lastName, className, section);

                Console.WriteLine("Teacher information successfully updated.");
                teacher.PrintTeacher();
            }
            else
            {
                Console.WriteLine("No teacher found with that Id.");
            }
        }
        
    }
}
