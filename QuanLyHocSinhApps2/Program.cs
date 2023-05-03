using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net.WebSockets;
using System.Reflection;

namespace QuanLyHocSinhApps2
{
    public class HocSinh
    {
        public string Hoten;
        public double DiemToan;
        public double DiemVan;
        public double DiemAnhVan;
        public double DiemTB;
        public int GioiTinh;
    }
    internal class Program
    {

        //Ham nhap
        public HocSinh NhapThongTinHocSinh()
        {
            HocSinh hs = new HocSinh();
            Console.Write("Nhap ho ten hoc sinh: ");
            hs.Hoten = Console.ReadLine();
            Console.Write("Nhap gioi Tinh (1.Nam/ 2.Nu):  ");          
            hs.GioiTinh = int.Parse(Console.ReadLine());
            Console.Write("Nhap diem Toan: ");
            hs.DiemToan = double.Parse(Console.ReadLine());
            Console.Write("Nhap diem Van: ");
            hs.DiemVan = double.Parse(Console.ReadLine());
            Console.Write("Nhap diem Anh Van: ");
            hs.DiemAnhVan = double.Parse(Console.ReadLine());
            hs.DiemTB = (hs.DiemToan + hs.DiemVan + hs.DiemAnhVan) / 3;
            Console.WriteLine("Diem trung binh cua hoc sinh la: " + hs.DiemTB);
            Console.WriteLine("-------------------------");
            return hs;
        }

        //Ham xuat
        public void XuatDanhSachHocSinh(List<HocSinh> hs)
        {
            for (int i = 0; i < hs.Count; i++)
            {
                Console.WriteLine("Thong tin hoc sinh thu " + (i + 1));
                Console.WriteLine("Ho ten: " + hs[i].Hoten);
                if (hs[i].GioiTinh == 1)
                {
                    Console.WriteLine("Gioi tinh: Nam");
                }
                else
                {
                    Console.WriteLine("Gioi tinh: Nu");
                }
                Console.WriteLine("Diem Toan: " + hs[i].DiemToan);
                Console.WriteLine("Diem Van: " + hs[i].DiemVan);
                Console.WriteLine("Diem Anh Van: " + hs[i].DiemAnhVan);
                Console.WriteLine("Diem Trung Binh: " + hs[i].DiemTB);
                Console.WriteLine("-------------------------");
             
            }
        }

            //Ham tim kiem
        public void TimKiem(List<HocSinh> listhocsinh)
        {
            Console.Write("Nhap ten hoc sinh can tim: ");
            string searchname = Console.ReadLine();
            bool isCheck = false;
            HocSinh hs = new HocSinh();
            for (int i = 0; i < listhocsinh.Count; i++)
            { 
                if (listhocsinh[i].Hoten.Contains(searchname))
                {
                    isCheck = true;
                    hs = listhocsinh[i];
                    break;
                }
            }
            if (isCheck == false)
            {
                Console.WriteLine("Hoc sinh {0} khong co trong danh sach", searchname);
            }
            else
            {
                Console.WriteLine("Hoc sinh {0} trong danh sach", searchname);
                XuatHocSinh(hs);
                bool check = true;
                while (check)
                {
                    Console.WriteLine("Moi ban chon:");
                    Console.WriteLine("1.Sua hoc sinh");
                    Console.WriteLine("2.Xoa hoc sinh");
                    int n = int.Parse(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            SuaThongTinTrongTimKiem(hs);
                            break;
                        case 2:
                            XoaHocSinhTrongTimKiem(listhocsinh, hs);
                            break;
                        default:
                            check = false;
                            break;
                    }
                }
            }

        }

       
        //Ham them hoc sinh
        public void ThemHocSinh(List<HocSinh> lisths)
        {
            HocSinh hs = new HocSinh();
            Console.Write("Nhap ho ten hoc sinh: ");
            hs.Hoten = Console.ReadLine();
            Console.Write("Nhap gioi Tinh (1.Nam/2.Nu): ");
            hs.GioiTinh = int.Parse(Console.ReadLine());
            Console.Write("Nhap diem Toan: ");
            hs.DiemToan = double.Parse(Console.ReadLine());
            Console.Write("Nhap diem Van: ");
            hs.DiemVan = double.Parse(Console.ReadLine());
            Console.Write("Nhap diem Anh Van: ");
            hs.DiemAnhVan = double.Parse(Console.ReadLine());
            hs.DiemTB = (hs.DiemToan + hs.DiemVan + hs.DiemAnhVan) / 3;
            Console.WriteLine("Diem trung binh cua hoc sinh la: " + hs.DiemTB);
            Console.WriteLine("-------------------------");
         lisths.Add(hs);
        }

        //Tinh nang xem danh sach
        public void XemDanhSach(List<HocSinh> listhocsinh)
        {
            XuatDanhSachHocSinh(listhocsinh);
            bool isCheck = true;
            while (isCheck)
            {
                Console.WriteLine("Moi ban chon:");
                Console.WriteLine("1.Sap xep hoc sinh");
                Console.WriteLine("2.Phan loai hoc sinh");
                Console.WriteLine("3.Sua thong tin hoc sinh");
                Console.WriteLine("4.Xoa hoc sinh");
                Console.WriteLine("0.Thoat.");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        SapXep(listhocsinh);
                        break;
                    case 2:
                        PhanLoai(listhocsinh);
                        break;
                    case 3:
                        ChinhSuaThongTinHocSinh(listhocsinh);
                        break;
                    case 4:
                        XoaHocSinh(listhocsinh);
                        break;
                    default:
                        isCheck = false;
                        break;
                }
            }

        }

        public void SapXep(List<HocSinh> listHocSinh)
        {
            bool isCheck = true;
            while (isCheck)
            {
                Console.WriteLine("Moi ban chon:");
                Console.WriteLine("1.Sap xep theo diem");
                Console.WriteLine("2.Sap xep theo ten");
                Console.WriteLine("0.Thoat.");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        SapXepHocSinhTheoDiem(listHocSinh);
                        break;
                    case 2:
                        SapXepHocSinhTheoTen(listHocSinh);
                        break;
                    default:
                        isCheck = false;
                        break;
                }
            }
        }
        
        public void SapXepHocSinhTheoDiem(List<HocSinh> listhocsinh)
        {
            bool isCheck = true;
            while (isCheck)
            {
                Console.WriteLine("Moi ban chon:");
                Console.WriteLine("1.Sap xep theo diem tu cao den thap");
                Console.WriteLine("2.Sap xep theo diem tu thap den cao ");
                Console.WriteLine("0.Thoat.");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        SapXepHocSinhTheoDiemTuCaoDenThap(listhocsinh);
                        break;
                    case 2:
                        SapXepHocSinhTheoDiemTuThapDenCao(listhocsinh);
                        break;
                    default:
                        isCheck = false;
                        break;
                }
            }
        }

        public void SapXepHocSinhTheoDiemTuCaoDenThap(List<HocSinh> listhocsinh) 
        {
            for (int i = 0; i < listhocsinh.Count; i++) 
            {   
                for (int j = i + 1; j < listhocsinh.Count; j++)
                {
                    if (listhocsinh[j].DiemTB > listhocsinh[i].DiemTB)
                    {
                        HocSinh temp = listhocsinh[j];
                        listhocsinh[j] = listhocsinh[i];
                        listhocsinh[i] = temp;
                    }
                }
            }
            XuatDanhSachHocSinh(listhocsinh);
        }
        public void SapXepHocSinhTheoDiemTuThapDenCao(List<HocSinh> listhocsinh)
        {
            for (int i = 0; i < listhocsinh.Count; i++)
            {
                for (int j = i + 1; j < listhocsinh.Count; j++)
                {
                    if (listhocsinh[j].DiemTB < listhocsinh[i].DiemTB)
                    {
                        HocSinh temp = listhocsinh[j];
                        listhocsinh[j] = listhocsinh[i];
                        listhocsinh[i] = temp;
                    }
                }
            }
            XuatDanhSachHocSinh(listhocsinh);
        }

        //Sap xep theo ten
        public void SapXepHocSinhTheoTen(List<HocSinh> listhocsinh)
        {
            listhocsinh.Sort(
                (x1, x2) =>
                x1.Hoten.CompareTo(x2.Hoten));

            XuatDanhSachHocSinh(listhocsinh);
        }

        //Ham phan loai nam nu
        public void PhanLoai(List<HocSinh> listHocSinh) 
        {
            bool isCheck = true;
            while (isCheck)
            {
                Console.WriteLine("Moi ban chon:");
                Console.WriteLine("1.Phan loai theo nam");
                Console.WriteLine("2.Phan loai theo nu");
                Console.WriteLine("0.Thoat.");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        HocSinhNam(listHocSinh);
                        break;
                   case 2:
                       HocSinhNu(listHocSinh);
                        break;
                    default:
                        isCheck = false;
                        break;
                }
            }
        }

        //Phan loai theo nam
        public void HocSinhNam(List<HocSinh> listhocsinh) 
        {
            for (int  i = 0; i < listhocsinh.Count; i++)
            {
                if (listhocsinh[i].GioiTinh == 1)
                {
                    Console.WriteLine("Danh sach hoc sinh Nam");
                    XuatHocSinh(listhocsinh[i]);
                }
            }    
        }

        //Phan loai theo nu
        public void HocSinhNu(List<HocSinh> listhocsinh)
        {
            for (int i = 0; i < listhocsinh.Count; i++)
            {
                if (listhocsinh[i].GioiTinh != 1)
                {
                    Console.WriteLine("Danh sach hoc sinh Nu");
                    XuatHocSinh(listhocsinh[i]);
                }
            }
        }

        public void XuatHocSinh(HocSinh hs)
        {
                Console.WriteLine("Thong tin hoc sinh ");
                Console.WriteLine("Ho ten: " + hs.Hoten);
                Console.WriteLine("Diem Toan: " + hs.DiemToan);
                Console.WriteLine("Diem Van: " + hs.DiemVan);
                Console.WriteLine("Diem Anh Van: " + hs.DiemAnhVan);
                Console.WriteLine("Diem Trung Binh: " + hs.DiemTB);
                Console.WriteLine("-------------------------");
        }

        //Sua thong tin hoc sinh trong xem danh sach

        public void ChinhSuaThongTinHocSinh(List<HocSinh> listHocSinh) 
        {
            Console.WriteLine("Chon hoc sinh muon chinh sua thong tin");
            XuatDanhSachHocSinh(listHocSinh);
            int index = int.Parse(Console.ReadLine()) - 1;
            HocSinh select = listHocSinh[index];
            Console.WriteLine("Hoc sinh da chon la:");
            XuatHocSinh(select);
            bool isCheck = true;
            while (isCheck == true)
            {
                Console.WriteLine("Moi ban chon:");
                Console.WriteLine("1.Chinh sua ten");
                Console.WriteLine("2.Chinh sua diem Toan");
                Console.WriteLine("3.Chinh sua diem Van");
                Console.WriteLine("4.Chinh sua diem Anh Van");
                Console.WriteLine("0.Thoat");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        ChinhSuaTenHocSinh(select);
                        break;
                    case 2:
                        ChinhSuaDiemToan(select);
                        break;
                    case 3:
                        ChinhSuaDiemVan(select);
                        break;
                    case 4:
                        ChinhSuaDiemAnhVan(select);
                        break;
                    default:
                        isCheck = false;
                        break;
                }
            }
        }

        //Chinh sua Ho ten
        public void ChinhSuaTenHocSinh(HocSinh hs)
        {
            Console.Write("Vui long nhap ten moi cho {0}:\t",hs.Hoten);
            hs.Hoten = Console.ReadLine();
        }

        //Chinh sua Diem Toan
        public void ChinhSuaDiemToan(HocSinh hs)
        {
            Console.Write("Vui long nhap diem Toan moi cho {0} :\t",hs.Hoten);
            hs.DiemToan = double.Parse(Console.ReadLine());
        }

        //Chinh sua Diem Van
        public void ChinhSuaDiemVan(HocSinh hs)
        {
            Console.Write("Vui long nhap diem Van moi cho {0} :\t", hs.Hoten);          
            hs.DiemVan = double.Parse(Console.ReadLine());
        }

        //Chinh sua Diem AnhVan 
        public void ChinhSuaDiemAnhVan(HocSinh hs)
        {
            Console.Write("Vui long nhap diem Anh Van moi cho {0} :\t", hs.Hoten);           
            hs.DiemAnhVan = double.Parse(Console.ReadLine());
        }


        //Ham xoa hoc sinh
        public void XoaHocSinh(List<HocSinh> listHocSinh)
        {
            Console.WriteLine("Chon hoc sinh muon xoa");
            int index = int.Parse(Console.ReadLine()) - 1;
            listHocSinh.RemoveAt(index);
            Console.WriteLine("Danh sach sau khi xoa hoc sinh");
            XuatDanhSachHocSinh(listHocSinh);
        }

        //Sua thong tin hoc sinh trong tim kiem
        public void SuaThongTinTrongTimKiem(HocSinh hocSinh) 
        {
            bool isCheck = true;
            while (isCheck == true)
            {
                Console.WriteLine("Moi ban chon:");
                Console.WriteLine("1.Chinh sua ten");
                Console.WriteLine("2.Chinh sua diem Toan");
                Console.WriteLine("3.Chinh sua diem Van");
                Console.WriteLine("4.Chinh sua diem Anh Van");
                Console.WriteLine("0.Thoat");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        ChinhSuaTenHocSinh(hocSinh);
                        break;
                    case 2:
                        ChinhSuaDiemToan(hocSinh);
                        break;
                    case 3:
                        ChinhSuaDiemVan(hocSinh);
                        break;
                    case 4:
                        ChinhSuaDiemAnhVan(hocSinh);
                        break;
                    default:
                        isCheck = false;
                        break;
                }
            }
        }


        //Xoa thong tin hoc sinh trong tim kiem
        public void XoaHocSinhTrongTimKiem(List<HocSinh> listHocSinh,HocSinh hs)
        {
            listHocSinh.Remove(hs);
            Console.WriteLine("Danh sach sau khi xoa hoc sinh");
            XuatDanhSachHocSinh(listHocSinh);
        }

        //Ham chon hoc sinh thi hoc sinh gioi
        public void ThiHocSinhGioi(List<HocSinh> listHocSinh)
        {
            bool isCheck = true;
            while (isCheck == true)
            {
                Console.WriteLine("Moi ban chon mon thi hoc sinh gioi:");
                Console.WriteLine("1.Mon toan");
                Console.WriteLine("2.Mon Van");
                Console.WriteLine("3.Mon Anh Van");
                Console.WriteLine("0.Thoat");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        SapXepDiemToan(listHocSinh);
                        break;
                    case 2:
                        SapXepDiemVan(listHocSinh);
                        break;
                    case 3:
                        SapXepDiemAnhVan(listHocSinh);
                        break;
                    default:
                        isCheck = false;
                        break;

                }
            }
        }
        //Sap xep diem toan tu cao toi thap
        public void SapXepDiemToan(List<HocSinh> listHocSinh)
        {
            for (int i = 0; i < listHocSinh.Count; i++)
            {
                for (int j = i + 1; j < listHocSinh.Count; j++)
                {
                    if (listHocSinh[j].DiemToan > listHocSinh[i].DiemToan)
                    {
                        HocSinh temp = listHocSinh[j];
                        listHocSinh[j] = listHocSinh[i];
                        listHocSinh[i] = temp;
                    }
                }
            }
            XuatDanhSachHocSinh(listHocSinh);
        }
        //Sap xep diem Van tu cao toi thap
        public void SapXepDiemVan(List<HocSinh> listHocSinh)
        {
            for (int i = 0; i < listHocSinh.Count; i++)
            {
                for (int j = i + 1; j < listHocSinh.Count; j++)
                {
                    if (listHocSinh[j].DiemVan > listHocSinh[i].DiemVan)
                    {
                        HocSinh temp = listHocSinh[j];
                        listHocSinh[j] = listHocSinh[i];
                        listHocSinh[i] = temp;
                    }
                }
            }
            XuatDanhSachHocSinh(listHocSinh);
        }

        //Sap xep diem Anh van từ cao tới th
        public void SapXepDiemAnhVan(List<HocSinh> listHocSinh)
        {
            for (int i = 0; i < listHocSinh.Count; i++)
            {
                for (int j = i + 1; j < listHocSinh.Count; j++)
                {
                    if (listHocSinh[j].DiemAnhVan > listHocSinh[i].DiemAnhVan)
                    {
                        HocSinh temp = listHocSinh[j];
                        listHocSinh[j] = listHocSinh[i];
                        listHocSinh[i] = temp;
                    }
                }
            }
            XuatDanhSachHocSinh(listHocSinh);
        }

        static void Main(string[] args)
        {
            //Khởi tạo danh sách học sinh
            List<HocSinh> mylist = new List<HocSinh>();
            Console.Write("Nhap so luong hoc sinh: ");
            string nReadline = Console.ReadLine();

            // Kiểm tra chữ số nhập vào có phải số nguyên hay k
            int nNumber = int.Parse(nReadline);

            HocSinh hs = new HocSinh();
            Program program = new Program();

            //Thực hiện vòng lặp để nhập thông tin học sinh
            for (int i = 0; i < nNumber; i++)
            {
                Console.WriteLine("Thong tin hoc sinh thu " + (i + 1));

                hs = program.NhapThongTinHocSinh();
                mylist.Add(hs);
            }


            bool isCheck = true;
            while (isCheck)
            {
                Console.WriteLine("Moi ban chon:");
                Console.WriteLine("1.Xem danh sach");
                Console.WriteLine("2.Tim kiem hoc sinh");
                Console.WriteLine("3.Them hoc sinh");
                Console.WriteLine("4.Chon hoc sinh thi hoc sinh gioi");
                Console.WriteLine("5.Thoat");
                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        program.XemDanhSach(mylist);
                        break;
                    case 2:
                        program.TimKiem(mylist);
                        break;
                    case 3:
                        program.ThemHocSinh(mylist);
                        break;
                    case 4:
                        program.ThiHocSinhGioi(mylist);
                        break;
                    default:
                        isCheck = false;
                        break;
                }
            } 
            
        }

    }
}
