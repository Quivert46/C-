using System;

class BankAccount
{
    private const decimal minBalance = 50000;

    private static long nextAccountNumber = 1000000001;

    private decimal balance;

    public long AccountNumber { get; init; }
    public string AccountHolder { get; init;}

    public decimal Balance
    {
        get { return balance; }
    }

    public BankAccount(string AccountHolder, decimal initialBalance)
    {
        if(string.IsNullOrWhiteSpace(AccountHolder))
        {
            throw new ArgumentException("Ten chu tai khoan khong duoc de trong");
        }

        if(initialBalance < minBalance)
        {
            throw new ArgumentException("So du ban dau phai lon hon hoac bang " + minBalance + "VND");
        }

        AccountNumber = nextAccountNumber++;

        AccountHolder = AccountHolder;

        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if(amount <= 0)
        {
            throw new ArgumentException("So tien nap phai lon hon 0");
        }
        balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if(amount <= 0)
        {
            throw new ArgumentException("So tien rut phai lon hon 0");
        }

        if(balance - amount < minBalance)
        {
            return false;
        }

        balance -= amount;
        return true;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("So tai khoan: " + AccountNumber);
        Console.WriteLine("Chu tai khoan: " + AccountHolder);
        Console.WriteLine("So du: " + balance + "VND");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("===== QUAN LY TAI KHOAN NGAN HANG =====");

        BankAccount acc1 = new BankAccount("Nguyen Van A", 1000000);
        BankAccount acc2 = new BankAccount("Tran Thi B", 2000000);

        Console.WriteLine("\n--- Tai khoan 1 ---");
        acc1.DisplayInfo();

        Console.WriteLine("\n--- Tai khoan 2 ---");
        acc2.DisplayInfo();

        Console.WriteLine("\n--- KIEM TRA TAI KHOAN KHONG HOP LE ---");
        try
        {
            BankAccount invalidAccount = new BankAccount("Le Van C", 10000);
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine("Loi: " + ex.Message);
        }

        Console.WriteLine("\n--- NAP TIEN CHO TAI KHOAN 1 ---");
        acc1.Deposit(500000);

        Console.WriteLine("Da nap 500000 VND");
        acc1.DisplayInfo();

        Console.WriteLine("\n--- RUT TIEN HOP LE ---");
        bool result = acc1.Withdraw(300000);

        if(result)
        {
            Console.WriteLine("Rut tien thanh cong");
        }
        else
        {
            Console.WriteLine("So du khong du");
        }

        acc1.DisplayInfo();

        Console.WriteLine("\n--- RUT TIEN VUOT QUA HAN MUC ---");
        result = acc1.Withdraw(1500000);

        if(result)
        {
            Console.WriteLine("Rut tien thanh cong");
        }
        else
        {
            Console.WriteLine("Rut tien khong thanh cong. So du khong du de duy tri so du toi thieu ");
        }
        acc1.DisplayInfo();

        Console.WriteLine("\n--- KIEM TRA SO TAI KHOAN TU TANG ---");
        Console.WriteLine("Tai khoan 1: " + acc1.AccountNumber);
        Console.WriteLine("Tai khoan 2: " + acc2.AccountNumber);
    }
}
