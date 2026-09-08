using System;

public class Person
{
    public string Id { get; init; }
    public string FullName { get; init; }
    public int BirthYear { get; init; }

    public Person(string id, string fullName, int birthYear)
    {
        Id = id;
        FullName = fullName;
        BirthYear = birthYear;
    }

    public int GetAge(int currentYear)
    {
        return currentYear - BirthYear;
    }
}

public class Employee : Person
{
    public decimal BaseSalary { get; init; }

    public Employee(string id, string fullName, int birthYear, decimal baseSalary)
        : base(id, fullName, birthYear)
    {
        BaseSalary = baseSalary;
    }

    public virtual decimal CalculateIncome()
    {
        return BaseSalary;
    }
}

public sealed class Manager : Employee
{
    public decimal ResponsibilityAllowance { get; init; }

    public Manager(
        string id,
        string fullName,
        int birthYear,
        decimal baseSalary,
        decimal allowance)
        : base(id, fullName, birthYear, baseSalary)
    {
        ResponsibilityAllowance = allowance;
    }

    public override decimal CalculateIncome()
    {
        return BaseSalary + ResponsibilityAllowance;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("===== HE THONG QUAN LY NHAN VIEN =====");

        int currentYear = 2026;

        Employee employee = new Employee(
            "NV001",
            "Nguyen Van A",
            2003,
            8000000
        );

        Manager manager = new Manager(
            "QL001",
            "Tran Thi B",
            1995,
            15000000,
            3000000
        );

        Console.WriteLine("\n--- PHIEU LUONG NHAN VIEN ---");
        Console.WriteLine("Ho ten: " + employee.FullName);
        Console.WriteLine("Tuoi: " + employee.GetAge(currentYear));
        Console.WriteLine("Luong co ban: " + employee.BaseSalary + " VND");
        Console.WriteLine("Thu nhap thuc linh: " + employee.CalculateIncome() + " VND");

        Console.WriteLine("\n--- PHIEU LUONG QUAN LY ---");
        Console.WriteLine("Ho ten: " + manager.FullName);
        Console.WriteLine("Tuoi: " + manager.GetAge(currentYear));
        Console.WriteLine("Luong co ban: " + manager.BaseSalary + " VND");
        Console.WriteLine("Thu nhap thuc linh: " + manager.CalculateIncome() + " VND");

        // Khong the tao mot class moi ke thua tu Manager
        // vi Manager duoc danh dau la sealed.
        // Tu khoa sealed dung de ngan khong cho cac class khac ke thua Manager.
    }
}
