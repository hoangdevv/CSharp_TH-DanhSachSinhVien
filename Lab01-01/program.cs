using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_01
{
    internal class program
    {
        static void Main(string[] args)
        {
            List<Student> listStudents = nhapDSSV();

            var menu = false;
            do
            {
                Console.WriteLine("\n\n--------------------MENU------------------");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Hien thi ds sinh vien");
                Console.WriteLine("3. Xuat ra thong tin cac sv thuoc khoa CNTT");
                Console.WriteLine("4. Xuat ra thong tin sv co diem TB lon hon bang 5");
                Console.WriteLine("5. Xuat ra ds sv duoc sap xep theo diem TB tang dan");
                Console.WriteLine("6. Xuat ra ds sv cos diem TB lon hon bang 5 va thuoc khoa CNTT");
                Console.WriteLine("7. Xuat ra ds sv co diem TB cao nhat va thuoc khoa CNTT");
                Console.WriteLine("8. Xuat ra so luong cua tung xep loai trong danh sach");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("--------------------------------------------\n");
                Console.WriteLine("Chon chuc nang: "); var chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {
                            addSinhVien(listStudents);
                            break;
                        }
                    case 2:
                        {
                            xuatDSSV(listStudents);
                            break;
                        }
                    case 3:
                        {
                            SVKhoaCNTT(listStudents);
                            break;
                        }
                    case 4:
                        {
                            diemTBLonHon5(listStudents);
                            break;
                        }
                    case 5:
                        {
                            DTBSortByAscending(listStudents);
                            break;
                        }
                    case 6:
                        {   
                            DTBlon5_CNTT(listStudents);
                            break;
                        }
                    case 7:
                        {  
                            DTBMax_CNTT(listStudents);
                            break;
                        }
                    case 8:
                        {
                            countRank(listStudents);
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Thoat chuong trinh");
                            break;
                        }
                    default:
                        Console.WriteLine("Chon chuc nang khong hop le!");
                        break;
                }
            } while (!menu);

            Console.ReadKey();
        }

        //ham tao san
        private static List<Student> nhapDSSV()
        {
            List<Student> listStudents = new List<Student>();
            listStudents.Add(new Student("21A", "Hoang",    8.8f,  "CNTT"));
            listStudents.Add(new Student("21B", "Thanh",    9.8f,  "CNTT"));
            listStudents.Add(new Student("21C", "Tri",      5.8f,  "NNA"));
            listStudents.Add(new Student("21D", "Linh",     6.8f,   "CNTT"));
            listStudents.Add(new Student("21F", "Hoa",      7.8f,   "CNTP"));
            listStudents.Add(new Student("21F", "Thu",      3.4f,   "CNTP"));
            listStudents.Add(new Student("21F", "Hang",     3.4f, "CNTP"));
            listStudents.Add(new Student("21F", "Dinh",     5.4f, "CNTP"));


            return listStudents;
        }

        //xuat
        private static void xuatDSSV(List<Student> listStudents)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("| Mã sinh viên |      HoTen      | DTB  |   Khoa  |");
            Console.WriteLine("----------------------------------------------------");
            foreach (var item in listStudents)
            {
                item.outPut();
            }
            Console.WriteLine("----------------------------------------------------");
        }

        //them sinh vien
        private static void addSinhVien(List<Student> listStudents)
        {
            Console.WriteLine("Nhap so luong sinh vien muon them: ");
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Student student = new Student();
                Console.WriteLine($"Nhap sinh vien thu {i + 1} : ");
                student.inPut();
                listStudents.Add(student);
                Console.WriteLine("Them sinh vien thanh cong!");
            }
        }

        //Ham SV thuoc khoa CNTT
        private static void SVKhoaCNTT(List<Student> listStudents)
        {

            var result = listStudents.Where(p => p.Faculty == "CNTT").ToList();
            if(result.Count != 0)
            {
                Console.WriteLine("Danh sach SV thuoc khoa CNTT");
                xuatDSSV(result);
            }
            else
            {
                Console.WriteLine("Khong co sinh vien thuoc khoa CNTT!");
            }
        }
        
        //Ham xuat ra SV co diem TB lon hon bang 5
        private static void diemTBLonHon5(List<Student> listStudents)
        {
            var result = listStudents.Where(p => p.AverageScore >= 5).ToList();
            if (result.Count != 0)
            {
                Console.WriteLine("Danh sach SV co diem >= 5");
                xuatDSSV(result);
            }
            else
            {
                Console.WriteLine("Khong co sinh vien co diem TB lon hon hoac bang 5!");
            }
        }

        //Ham DSSV duoc sap xep theo DTB tang dan
        private static void DTBSortByAscending(List<Student> listStudents)
        {
            var SortByAverage= listStudents.OrderBy(p => p.AverageScore).ToList();
            if (SortByAverage.Count != 0)
            {
                Console.WriteLine("Danh sach SV theo DTB tang dan");
                xuatDSSV(SortByAverage);
            }
            else
            {
                Console.WriteLine("Khong co DS SV theo DTB tang dan!");
            }
        }

        //Ham DS SV co diem TB >= 5 va thuoc khoa CNTT
        private static void DTBlon5_CNTT(List<Student> listStudents)
        {
            var results = listStudents.Where(p => (p.AverageScore >= 5) && (p.Faculty == "CNTT")).ToList();
            Console.WriteLine("Danh sach SV co DTB lon hon bang 5 va thuoc khoa CNTT");
            xuatDSSV(results);
        }
        //Ham DS SV co DTB cao nhat va thuoc khoa CNTT
        private static void DTBMax_CNTT(List<Student> listStudents)
        {
            var maxDTB = listStudents.Where(p => p.Faculty == "CNTT").Max(p => p.AverageScore);
            var results = listStudents.Where(p => (p.Faculty == "CNTT") && (p.AverageScore == maxDTB)).ToList();
            Console.WriteLine("Danh sach SV co DTB cao nhat va thuoc khoa CNTT");
            xuatDSSV(results);
        }

        //So luong cua tung xep loai trong DS
        private static void countRank(List<Student> listStudents)
        {
            //xep loai thang diem 10
            var rank = listStudents.Select(p =>
            {
                if (p.AverageScore >= 9)
                {
                    return "Xuat sac";
                }
                else if (p.AverageScore >= 8 && p.AverageScore < 9)
                {
                    return "Gioi";
                }
                else if (p.AverageScore >= 7 && p.AverageScore < 8)
                {
                    return "Kha";
                }
                else if (p.AverageScore >= 5 && p.AverageScore < 7)
                {
                    return "Trung binh";
                }
                else if (p.AverageScore >= 4 && p.AverageScore < 5)
                {
                    return "Yeu";
                }
                else if (p.AverageScore < 4)
                {
                    return "Kem";
                }
                else
                {
                    return "HocLai";
                }
            });
            //Nhom sinh vien theo rank va dem so luong trong tung nhom
            var countXepLoai = rank.GroupBy(p => p).Select(p => new { xepLoai = p.Key, SL = p.Count() });
            foreach(var count in countXepLoai)
            {
                Console.WriteLine($"Xep loai: {count.xepLoai} , So luong: {count.SL}");
            }
        }
    }
}

