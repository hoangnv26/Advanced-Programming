using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Code
{
    class LecturerManagement
    {
        public Lecturer AddNew()
        {
            Lecturer lecturer = new Lecturer();
            string lecturerid = "";
            do
            {
                Console.WriteLine("Please Enter Lecturer ID: ");
                lecturerid = Console.ReadLine();
                if (lecturerid.Length == 0)
                {
                    Console.WriteLine("Please Enter ID Again: ");
                }
            } while (lecturerid.Length == 0);
            lecturer.lecId = lecturerid;

            string lecturername = "";
            do
            {
                Console.WriteLine("Please Enter Lecturer Name: ");
                lecturername = Console.ReadLine();
                if (lecturername.Length == 0)
                {
                    Console.WriteLine("Please Enter Name Again: ");
                }
            } while (lecturername.Length == 0);
            lecturer.lecName = lecturername;

            string lecturerdob = "";
            do
            {
                Console.WriteLine("Please Enter Lecturer Date Of Birth: ");
                lecturerdob = Console.ReadLine();
                if (lecturerdob.Length == 0)
                {
                    Console.WriteLine("Please Enter Date Of Birth Again: ");
                }
            } while (lecturerdob.Length == 0);
            lecturer.lecDob = lecturerdob;

            string lectureremail = "";
            do
            {
                Console.WriteLine("Please Enter Lecturer Email: ");
                lectureremail = Console.ReadLine();
                if (lectureremail.Length == 0)
                {
                    Console.WriteLine("Please Enter  Email Again: ");
                }
            }
            while (lectureremail.Length == 0);
            lecturer.lecEmail = lectureremail;

            string lectureraddress = "";
            do
            {
                Console.WriteLine("Please Enter Lecturer Address: ");
                lectureraddress = Console.ReadLine();
                if (lectureraddress.Length == 0)
                {
                    Console.WriteLine("Please Enter  Address Again: ");
                }
            }
            while (lectureraddress.Length == 0);
            lecturer.lecAddress = lectureraddress;

            string lecturerdept = "";
            do
            {
                Console.WriteLine("Please Enter Lecturer Department: ");
                lecturerdept = Console.ReadLine();
                if (lecturerdept.Length == 0)
                {
                    Console.WriteLine("Please Enter Department Again: ");
                }
            }
            while (lecturerdept.Length == 0);
            lecturer.lecDept = lecturerdept;

            return lecturer;
        }
        public void View(Lecturer[] lecturer, int m)
        {
            Console.WriteLine("*************************************************LIST LECTURER*************************************************");
            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", new Object[] { "ID", "NAME", "EMAIL", "ADDRESS", "DOB", "DEPT" });
            for (int i = 0; i < m; i++)
            {
                Lecturer temp = lecturer[i];
                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", temp.lecId, temp.lecName, temp.lecEmail, temp.lecAddress, temp.lecDob, temp.lecDept);
            }
        }

        public void Search(Lecturer[] lecturer, int m)
        {
            bool searchName = false;
            do
            {
                Console.WriteLine("Enter Lecturer ID: ");
                string a = Console.ReadLine();
                for (int i = 0; i < m; i++)
                {
                    Lecturer temp = lecturer[i];
                    if (temp.lecId.StartsWith(a))
                    {
                        searchName = true;
                        Console.WriteLine("******************************LECTURER FOUND******************************");
                        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", new Object[] { "ID", "NAME", "EMAIL", "ADDRESS", "DOB", "CLASS" });
                        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", temp.lecId, temp.lecName, temp.lecEmail, temp.lecAddress, temp.lecDob, temp.lecDept);
                    }
                    if (searchName == false)
                    {
                        Console.WriteLine("It does not exist");
                    }
                }
            } while (searchName == false);
        }

        public int Check(Lecturer[] lecturer, int m, string LecturerID)
        {
            for (int i = 0; i < m; i++)
            {
                Lecturer temp = lecturer[i];
                if (LecturerID.Equals(temp.lecId))
                {
                    return i;
                }
            }
            return -1;
        }
        public Lecturer[] Delete(Lecturer[] lecturer, int m)
        {
            Console.WriteLine("Enter Lecturer ID Delete: ");
            string LecturerID = Console.ReadLine();
            int Result = Check(lecturer, m, LecturerID);
            if (Result < 0)
            {
                Console.WriteLine("Student ID does not exist");
            }
            else
            {
                for (int i = Result; i < m - 1; i++)
                {
                    lecturer[i] = lecturer[i + 1];
                }
                Console.WriteLine("Delete Success!!");
            }
            return lecturer;
        }
        public Lecturer[] Update(Lecturer[] lecturer, int m)
        {
            Console.WriteLine("Enter Lecturer ID Update");
            string productID = Console.ReadLine();
            int Result = Check(lecturer, m, productID);
            if (Result < 0)
            {
                Console.WriteLine("Student ID does not exist");
            }
            else
            {
                Console.WriteLine("");
                Lecturer newlecturer = new Lecturer();
                Console.WriteLine("Enter new Lecturer Name: ");
                newlecturer.lecName = Console.ReadLine();
                Console.WriteLine("Enter new Lecturer Date Of Birth: ");
                newlecturer.lecDob = Console.ReadLine();
                Console.WriteLine("Enter new Lecturer Email: ");
                newlecturer.lecEmail = Console.ReadLine();
                Console.WriteLine("Enter new Lecturer Address");
                newlecturer.lecAddress = Console.ReadLine();
                lecturer[Result] = newlecturer;
                Console.WriteLine("Update Success!");
            }
            return lecturer;
        }

        public Lecturer ReadFromFile(string PatchLecturer, int i)
        {
            string[] lines = File.ReadAllLines(PatchLecturer);
            Lecturer temp = new Lecturer();
            string[] items = lines[i].Split('#');
            temp.lecId = items[0];
            temp.lecName = items[1];
            temp.lecDob = items[2];
            temp.lecEmail = items[3];
            temp.lecAddress = items[4];
            temp.lecDept = items[5];
            return temp;
        }
        public void Write2File(string PatchLecturer, Lecturer[] lecturer, int m, int numOfLines)
        {
            File.WriteAllText(PatchLecturer, string.Empty);
            for (int i = 0; i < m; i++)
            {
                StreamWriter writer = new StreamWriter(PatchLecturer, true);
                writer.WriteLine(lecturer[i].ToString());
                writer.Close();
            }
        }
    }
}
