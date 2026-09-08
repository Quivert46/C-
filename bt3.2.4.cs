using System;

interface IPayable
{
    bool ProcessPayment(decimal amount);
}

interface IRefundable
{
    bool ProcessRefund(decimal amount, string reason);
}

abstract class PaymentGateway
{
    public string TransactionId { get; init; }

    public DateTime CreationDate { get; init; }

    public string Status { get; protected set; }

    protected PaymentGateway(string transactionId)
    {
        TransactionId = transactionId;
        CreationDate = DateTime.Now;
        Status = "Pending";
    }

    public abstract void ValidateConnection();

    public virtual void LogTransaction(string message)
    {
        Console.WriteLine(
            "[Transaction " + TransactionId + "] " + message
        );
    }
}

class MomoPayment : PaymentGateway, IPayable, IRefundable
{
    public string PhoneNumber { get; init; }

    public MomoPayment(string transactionId, string phoneNumber)
        : base(transactionId)
    {
        PhoneNumber = phoneNumber;
    }

    public override void ValidateConnection()
    {
        Console.WriteLine("Dang kiem tra ket noi API MoMo...");
        Console.WriteLine("Ket noi API MoMo thanh cong.");
    }

    public bool ProcessPayment(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("So tien thanh toan phai lon hon 0");
            return false;
        }

        if (string.IsNullOrWhiteSpace(PhoneNumber))
        {
            Console.WriteLine("So dien thoai khong hop le");
            return false;
        }

        Status = "Success";

        LogTransaction(
            "Thanh toan thanh cong " + amount + " VND"
        );

        return true;
    }

    public bool ProcessRefund(decimal amount, string reason)
    {
        if (amount <= 0)
        {
            Console.WriteLine("So tien hoan phai lon hon 0");
            return false;
        }

        if (string.IsNullOrWhiteSpace(reason))
        {
            Console.WriteLine("Ly do hoan tien khong duoc de trong");
            return false;
        }

        Status = "Refunded";

        LogTransaction(
            "Hoan tien " + amount
            + " VND. Ly do: " + reason
        );

        return true;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("===== CONG THANH TOAN DA PHUONG THUC =====");

        MomoPayment momo = new MomoPayment(
            "TXN001",
            "0912345678"
        );

        Console.WriteLine("\n--- THONG TIN GIAO DICH ---");
        Console.WriteLine("Ma giao dich: " + momo.TransactionId);
        Console.WriteLine("So dien thoai: " + momo.PhoneNumber);
        Console.WriteLine("Thoi gian tao: " + momo.CreationDate);
        Console.WriteLine("Trang thai: " + momo.Status);

        Console.WriteLine("\n--- KIEM TRA KET NOI ---");

        momo.ValidateConnection();

        Console.WriteLine("\n--- THANH TOAN ---");

        IPayable payable = (IPayable)momo;

        bool paymentResult = payable.ProcessPayment(500000);

        if (paymentResult)
        {
            Console.WriteLine("Ket qua: Thanh toan thanh cong");
        }
        else
        {
            Console.WriteLine("Ket qua: Thanh toan that bai");
        }

        Console.WriteLine("Trang thai: " + momo.Status);

        Console.WriteLine("\n--- HOAN TIEN ---");

        IRefundable refundable = (IRefundable)momo;

        bool refundResult = refundable.ProcessRefund(
            500000,
            "Khach hang yeu cau hoan tien"
        );

        if (refundResult)
        {
            Console.WriteLine("Ket qua: Hoan tien thanh cong");
        }
        else
        {
            Console.WriteLine("Ket qua: Hoan tien that bai");
        }

        Console.WriteLine("Trang thai: " + momo.Status);
    }
}