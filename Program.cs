using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] student = new Student[100];
            Lecturer[] lecturer = new Lecturer[100];
            int n = 0;
            int m = 0;
            StudentManagement studentManagement = new StudentManagement(); 
            LecturerManagement lecturerManagement = new LecturerManagement();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("============Chose Menu==============");
                Console.WriteLine("1. Student Manage");
                Console.WriteLine("2. Lecturer Manage");
                Console.WriteLine("3. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        do
                        {

                            Console.WriteLine("\n***Student Manage***\nChoose function from 1 to 6:");
                            Console.WriteLine("1.	Add new student ");
                            Console.WriteLine("2.	View all students");
                            Console.WriteLine("3.	Search students");
                            Console.WriteLine("4.	Delete students");
                            Console.WriteLine("5.	Update student");
                            Console.WriteLine("6.	Back to main menu\n");
                            choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    student[n] = studentManagement.AddNew();
                                    n = n + 1;
                                    break;
                                case 2:
                                    studentManagement.View(student, n);
                                    break;
                                case 3:

                                    studentManagement.Search(student, n);
                                    break;
                                case 4:
                                    studentManagement.Delete(student, n);
                                    n = n - 1;
                                    break;
                                case 5:
                                    studentManagement.Update(student, n);
                                    break;
                                case 6:
                                    break;
                                default:
                                    Console.WriteLine("Fail - Choose 1 - 6 ");
                                    break;
                            }
                        }
                        while (choice != 6);
                        break;

                    case 2:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("============= Manage Lecturers =============");
                            Console.WriteLine("1.	Add new lecturer");
                            Console.WriteLine("2.	View all lecturers");
                            Console.WriteLine("3.	Search lecturers");
                            Console.WriteLine("4.	Delete lecturers");
                            Console.WriteLine("5.	Update lecturer");
                            Console.WriteLine("6.	Back to main menu");

                            choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    lecturer[m] = lecturerManagement.AddNew();
                                    m = m + 1;

                                    break;
                                case 2:
                                    lecturerManagement.View(lecturer,m);

                                    break;
                                case 3:
                                    lecturerManagement.Search(lecturer, m);
                              
                                    break;
                                case 4:
                                    lecturerManagement.Delete(lecturer, m);
                                    m = m - 1;
                                    break;
                                case 5:
                                    lecturerManagement.Update(lecturer, m);
                                    break;
                                case 6:
                                    break;
                                default:
                                    Console.WriteLine("You must choose function from 1 to 6");
                                    break;
                            }
                        }
                        while (choice != 6);
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nYou must choose function from 1 to 3");
                        break;
                }

            }
        }
    }
}
