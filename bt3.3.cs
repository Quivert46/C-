using System;

class Program
{

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

    static void Main()
    {
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

        Console.WriteLine($"Day Fibonacci gom {N} so dau tien:");

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
}