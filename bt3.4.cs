using System;

class Program
{
    static void BaiTap1()
    {
        Console.Clear();
        Console.WriteLine("===== BAI TAP 1: CALCULATOR =====");

        Console.Write("Nhap so thu nhat: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhap phep toan (+, -, *, /): ");
        char op = char.Parse(Console.ReadLine());

        Console.Write("Nhap so thu hai: ");
        double b = double.Parse(Console.ReadLine());

        double result = 0;

        switch (op)
        {
            case '+':
                result = a + b;
                break;

            case '-':
                result = a - b;
                break;

            case '*':
                result = a * b;
                break;

            case '/':
                if (b == 0)
                {
                    Console.WriteLine("Khong the chia cho 0!");
                    return;
                }

                result = a / b;
                break;

            default:
                Console.WriteLine("Phep toan khong hop le!");
                return;
        }

        Console.WriteLine($"Ket qua: {a} {op} {b} = {result}");
    }


    static void BaiTap2()
    {
        Console.Clear();
        Console.WriteLine("===== BAI TAP 2: PHUONG TRINH BAC 2 =====");

        Console.Write("Nhap a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhap b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhap c: ");
        double c = double.Parse(Console.ReadLine());

        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                    Console.WriteLine("Phuong trinh co vo so nghiem.");
                else
                    Console.WriteLine("Phuong trinh vo nghiem.");
            }
            else
            {
                double x = -c / b;
                Console.WriteLine($"Phuong trinh co nghiem x = {x}");
            }

            return;
        }


        double delta = b * b - 4 * a * c;

        if (delta < 0)
        {
            Console.WriteLine("Phuong trinh vo nghiem.");
        }
        else if (delta == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Phuong trinh co nghiem kep x = {x}");
        }
        else
        {
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);

            Console.WriteLine($"x1 = {x1}");
            Console.WriteLine($"x2 = {x2}");
        }
    }


    static bool IsPrime(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }


    static bool IsPerfectNumber(int n)
    {
        if (n <= 1)
            return false;

        int sum = 1;

        for (int i = 2; i <= n / 2; i++)
        {
            if (n % i == 0)
                sum += i;
        }

        return sum == n;
    }

    static void BaiTap3()
    {
        Console.Clear();
        Console.WriteLine("===== BAI TAP 3: SO NGUYEN TO & FIBONACCI =====");

        int N;

        do
        {
            Console.Write("Nhap so nguyen duong N: ");
            N = int.Parse(Console.ReadLine());
        } while (N <= 0);


        if (IsPrime(N))
            Console.WriteLine($"{N} la so nguyen to.");
        else
            Console.WriteLine($"{N} khong phai la so nguyen to.");


        if (IsPerfectNumber(N))
            Console.WriteLine($"{N} la so hoan hao.");
        else
            Console.WriteLine($"{N} khong phai la so hoan hao.");


        Console.WriteLine($"\n{N} so dau tien cua day Fibonacci:");

        int a = 0;
        int b = 1;

        for (int i = 0; i < N; i++)
        {
            Console.Write(a + " ");

            int next = a + b;
            a = b;
            b = next;
        }

        Console.WriteLine();
    }


    static void ShowMenu()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("             CONSOLE MENU");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Chay Bai tap 1 (Calculator)");
        Console.WriteLine("2. Chay Bai tap 2 (Phuong trinh bac 2)");
        Console.WriteLine("3. Chay Bai tap 3 (So nguyen to & Fibonacci)");
        Console.WriteLine("0. Thoat chuong trinh");
        Console.WriteLine("========================================");
        Console.Write("Nhap lua chon: ");
    }



    static void Main()
    {
        int choice;

        do
        {
            Console.Clear();

            ShowMenu();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1;
            }

            switch (choice)
            {
                case 1:
                    BaiTap1();
                    break;

                case 2:
                    BaiTap2();
                    break;

                case 3:
                    BaiTap3();
                    break;

                case 0:
                    Console.Clear();
                    Console.WriteLine("Cam on ban da su dung chuong trinh!");
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }

  
            if (choice != 0)
            {
                Console.WriteLine("\nNhan phim bat ky de quay lai Menu...");
                Console.ReadKey();
            }

        } while (choice != 0);
    }
}