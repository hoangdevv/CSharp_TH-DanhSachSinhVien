using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_01
{
    internal class Student
    {
        private string studentID;
        private string fullName;
        private float averageScore;
        private string faculty;
        //constructor  
        public Student() {}
        public Student(string studentID, string fullName, float averageScore, string faculty)
        {
            this.StudentID = studentID;
            this.FullName = fullName;
            this.AverageScore = averageScore;
            this.Faculty = faculty;
        }
        //property
        public string StudentID { get => studentID; set => studentID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        //nhap 
        public void inPut()
        {
            Console.WriteLine("Nhap MSSV: ");
            studentID = Console.ReadLine();
            Console.WriteLine("Nhap ho ten sinh vien: ");
            fullName = Console.ReadLine();
            bool result;
            float kq;
            do
            {
                Console.WriteLine("Nhap diem trung binh: ");
                string test = Console.ReadLine();
                result = float.TryParse(test, out kq);
                if (!result)
                {
                    Console.WriteLine("Error! Nhap lai diem trung binh: ");
                }

            } while(!result);
            averageScore = kq;
            Console.WriteLine("Nhap khoa: ");
            faculty = Console.ReadLine();
        }

        //xuat xuat
        public void outPut()
        {      
            Console.WriteLine($"|{this.studentID,-14}|{this.fullName,-17}|{this.averageScore,-6}|{this.faculty,-9}|");
        }
    }   
}
