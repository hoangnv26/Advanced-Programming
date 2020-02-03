using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Code
{
    class StudentManagement
    {
        public Student AddNew()
        {
            Student student = new Student();
            string studentid = "";
            do
            {
                Console.WriteLine("Please Enter Student ID: ");
                studentid = Console.ReadLine();
                if (studentid.Length == 0)
                {
                    Console.WriteLine("Please Enter ID Again: ");
                }
            } while (studentid.Length == 0);
            student.stdId = studentid;

            string studentname = "";
            do
            {
                Console.WriteLine("Please Enter Student Name: ");
                studentname = Console.ReadLine();
                if (studentname.Length == 0)
                {
                    Console.WriteLine("Please Enter Name Again: ");
                }
            } while (studentname.Length == 0);
            student.stdName = studentname;

            string studentdob = "";
            do
            {
                Console.WriteLine("Please Enter Student Date Of Birth: ");
                studentdob = Console.ReadLine();
                if (studentdob.Length == 0)
                {
                    Console.WriteLine("Please Enter Date Of Birth Again: ");
                }
            } while (studentdob.Length == 0);
            student.stdDateofbirth = studentdob;

            string studentemail = "";
            do
            {
                Console.WriteLine("Please Enter Student Email: ");
                studentemail = Console.ReadLine();
                if (studentemail.Length == 0)
                {
                    Console.WriteLine("Please Enter  Email Again: ");
                }
            }
            while (studentemail.Length == 0);
            student.stdEmail = studentemail;

            string studentaddress = "";
            do
            {
                Console.WriteLine("Please Enter Student Address: ");
                studentaddress = Console.ReadLine();
                if (studentaddress.Length == 0)
                {
                    Console.WriteLine("Please Enter  Address Again: ");
                }
            }
            while (studentaddress.Length == 0);
            student.stdAddress = studentaddress;

            string studentbatcht = "";
            do
            {
                Console.WriteLine("Please Enter Student Batch: ");
                studentbatcht = Console.ReadLine();
                if (studentbatcht.Length == 0)
                {
                    Console.WriteLine("Please Enter Batch Again: ");
                }
            }
            while (studentbatcht.Length == 0);
            student.stdClassbatch = studentbatcht;

            return student;
        }
        public void View(Student[] student, int n)
        {
            Console.WriteLine("*************************************************LIST STUDENT*************************************************");
            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", new Object[] { "ID", "NAME", "EMAIL", "ADDRESS", "DOB", "CLASS" });
            for (int i = 0; i < n; i++)
            {
                Student temp = student[i];
                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", temp.stdId, temp.stdName, temp.stdEmail, temp.stdAddress, temp.stdDateofbirth,  temp.stdClassbatch);
            }
        }

        public void Search(Student[] student, int n)
        {
            bool searchName = false;
            do
            {
                Console.WriteLine("Enter Student ID: ");
                string a = Console.ReadLine();
                for (int i = 0; i < n; i++)
                {
                    Student temp = student[i];
                    if (temp.stdId.StartsWith(a))
                    {
                        searchName = true;
                        Console.WriteLine("******************************STUDENT FOUND******************************");
                        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", new Object[] { "ID", "NAME", "EMAIL", "ADDRESS", "DOB", "CLASS" });
                        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", temp.stdId, temp.stdName, temp.stdEmail, temp.stdAddress, temp.stdDateofbirth, temp.stdClassbatch);
                    }
                    if (searchName == false)
                    {
                        Console.WriteLine("It does not exist");
                    }
                }
            } while (searchName == false);
        }

        public int Check(Student[] student, int n, string StudentID)
        {
            for (int i = 0; i < n; i++)
            {
                Student temp = student[i];
                if (StudentID.Equals(temp.stdId))
                {
                    return i;
                }
            }
            return -1;
        }
        public Student[] Delete(Student[] student, int n)
        {
            Console.WriteLine("Enter Student ID Delete: ");
            string StudentID = Console.ReadLine();
            int Result = Check(student, n, StudentID);
            if (Result < 0)
            {
                Console.WriteLine("Student ID does not exist");
            }
            else
            {
                for (int i = Result; i < n - 1; i++)
                {
                    student[i] = student[i + 1];
                }
                Console.WriteLine("Delete Success!!");
            }
            return student;
        }
        public Student[] Update(Student[] student, int n)
        {
            Console.WriteLine("Enter Student ID Update");
            string productID = Console.ReadLine();
            int Result = Check(student, n, productID);
            if (Result < 0)
            {
                Console.WriteLine("Student ID does not exist");
            }
            else
            {
                Console.WriteLine("");
                Student newstudent = new Student();
                Console.WriteLine("Enter new Student Name: ");
                newstudent.stdName = Console.ReadLine();
                Console.WriteLine("Enter new Student Date Of Birth: ");
                newstudent.stdDateofbirth = Console.ReadLine();
                Console.WriteLine("Enter new Student Email: ");
                newstudent.stdEmail = Console.ReadLine();
                Console.WriteLine("Enter new Student Address");
                newstudent.stdAddress = Console.ReadLine();
                student[Result] = newstudent;
                Console.WriteLine("Update Success!");
            }
            return student;
        }

        public Student ReadFromFile(string PatchStudent, int i)
        {
            string[] lines = File.ReadAllLines(PatchStudent);
            Student temp = new Student();
            string[] items = lines[i].Split('#');
            temp.stdId = items[0];
            temp.stdName = items[1];
            temp.stdDateofbirth = items[2];
            temp.stdDateofbirth = items[3];
            temp.stdAddress = items[4];
            temp.stdClassbatch = items[5];
            return temp;
        }
        public void Write2File(string PatchStudent, Student[] student, int n, int numOfLines)
        {
            File.WriteAllText(PatchStudent, string.Empty);
            for (int i = 0; i < n; i++)
            {
                StreamWriter writer = new StreamWriter(PatchStudent, true);
                writer.WriteLine(student[i].ToString());
                writer.Close();
            }
        }
    }
}
