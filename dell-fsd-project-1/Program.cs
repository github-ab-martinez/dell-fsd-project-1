using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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

        public enum SortTypes
        {
            id,
            firstName,
            las
        }

        public static void RunApp()
        {
            Teacher classTeacher = new Teacher("Isaac", "Newton", "Intro to Physics", "Section 1");
            Teacher classTeacher2 = new Teacher("Galileo", "Galilei", "Astronomy", "Section 1");
            Teacher classTeacher3 = new Teacher("Albert", "Einstein", "Advanced Physics", "Section 2");


            TeacherList teachers = new TeacherList();
            teachers.Teachers = new List<Teacher> { classTeacher, classTeacher2, classTeacher3 };

            updateTxtFile(teachers);

            bool run = true;
            HashSet<string> validActions = new HashSet<string>() { "list", "search", "update", "exit" };

            do
            {
                Console.WriteLine("Which of the following actions would you like to perform?");
                Console.WriteLine("List | Search | Update | Exit");
                string input = Console.ReadLine();
                string actionName = input.ToString().ToLower();
                
                if (validActions.Contains(actionName))
                {
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
            bool validInput = false;
            HashSet<string> validSorts = new HashSet<string>() { "id", "first name", "last name" };

            do
            {
                Console.WriteLine("How would you like to sort the list?\nId | First Name | Last Name");
                string input = Console.ReadLine();
                string sortType = input.ToString().ToLower();

                if (validSorts.Contains(sortType))
                {
                    if (sortType == "id")
                    {
                        teacherList.Teachers.Sort();
                    } else if (sortType == "first name")
                    {
                        teacherList.Teachers.Sort(new FirstNameComparer());
                    }
                    else if (sortType == "last name")
                    {
                        teacherList.Teachers.Sort(new LastNameComparer());
                    }
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            } while (!validInput);
            
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
                updateTxtFile(teacherList);
            }
            else
            {
                Console.WriteLine("No teacher found with that Id.");
            }
        }
        
        public static void updateTxtFile(TeacherList teacherList)
        {

            string path = "App_Data/teachers.txt";

            if (File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLine("{\n\"teachers\": [\n");
                    foreach(Teacher teacher in teacherList.Teachers) {
                        sw.WriteLine("{\n");
                        sw.WriteLine("\"id\": " + teacher.Id + ",\n");
                        sw.WriteLine("\"firstName\": \"" + teacher.FirstName + "\",\n");
                        sw.WriteLine("lastName: \"" + teacher.LastName + "\",\n");
                        sw.WriteLine("class: \"" + teacher.Class + "\",\n");
                        sw.WriteLine("section: \"" + teacher.Section + "\",\n");
                        sw.WriteLine("},\n");
                    }
                    sw.WriteLine("]\n}");
                }
             }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }
}
