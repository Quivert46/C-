using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhập số thứ nhất a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhập số thứ hai b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhập phép toán (+, -, *, /, %): ");
        char op = char.Parse(Console.ReadLine());

        try
        {
            double result = op switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,

                // Pattern matching để kiểm tra b = 0
                '/' when b is 0 => throw new DivideByZeroException(),
                '%' when b is 0 => throw new DivideByZeroException(),

                '/' => a / b,
                '%' => a % b,

                _ => throw new InvalidOperationException("Phép toán không hợp lệ!")
            };

            Console.WriteLine($"Kết quả: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Lỗi: Không thể chia hoặc lấy phần dư cho 0.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
    }
}