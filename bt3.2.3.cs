using System;
using System.Collections.Generic;

class DiscountCalculator
{
    public decimal ApplyDiscount(decimal totalAmount)
    {
        return totalAmount * 0.95m;
    }

    public decimal ApplyDiscount(decimal totalAmount, double percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new ArgumentException("Phan tram giam phai tu 0 den 100");
        }

        decimal discount = totalAmount * (decimal)percentage / 100;

        return totalAmount - discount;
    }

    public decimal ApplyDiscount(
        decimal totalAmount,
        decimal fixedVoucher,
        decimal minimumOrder)
    {
        if (fixedVoucher < 0)
        {
            throw new ArgumentException("Gia tri voucher khong duoc am");
        }

        if (totalAmount >= minimumOrder)
        {
            return totalAmount - fixedVoucher;
        }

        return totalAmount;
    }
}


class DeliveryService
{
    public string OrderId { get; init; }
    public double DistanceKm { get; init; }

    public DeliveryService(string orderId, double distanceKm)
    {
        OrderId = orderId;
        DistanceKm = distanceKm;
    }

    public virtual decimal CalculateShippingFee()
    {
        return (decimal)DistanceKm * 5000;
    }
}


class ExpressDelivery : DeliveryService
{
    public ExpressDelivery(string orderId, double distanceKm)
        : base(orderId, distanceKm)
    {
    }

    public override decimal CalculateShippingFee()
    {
        decimal basicFee = base.CalculateShippingFee();

        return basicFee * 1.5m + 20000;
    }
}


class EcoDelivery : DeliveryService
{
    public EcoDelivery(string orderId, double distanceKm)
        : base(orderId, distanceKm)
    {
    }

    public override decimal CalculateShippingFee()
    {
        decimal basicFee = base.CalculateShippingFee();

        if (DistanceKm > 10)
        {
            return basicFee * 0.9m;
        }

        return basicFee;
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("===== MO PHONG HE THONG XU LY DON HANG =====");

        DiscountCalculator calculator = new DiscountCalculator();

        Console.WriteLine("\n--- TEST METHOD OVERLOADING ---");

        decimal totalAmount = 1000000;

        decimal result1 = calculator.ApplyDiscount(totalAmount);

        Console.WriteLine("Tong don hang: " + totalAmount + " VND");
        Console.WriteLine("Sau khi giam mac dinh 5%: "
            + result1 + " VND");

        decimal result2 = calculator.ApplyDiscount(
            totalAmount,
            20
        );

        Console.WriteLine("Sau khi giam 20%: "
            + result2 + " VND");

        decimal result3 = calculator.ApplyDiscount(
            totalAmount,
            100000,
            500000
        );

        Console.WriteLine("Sau khi ap dung voucher 100000 VND: "
            + result3 + " VND");


        Console.WriteLine("\n--- TEST RUNTIME POLYMORPHISM ---");

        List<DeliveryService> deliveries = new List<DeliveryService>();

        ExpressDelivery express = new ExpressDelivery(
            "DH001",
            5
        );

        EcoDelivery eco = new EcoDelivery(
            "DH002",
            15
        );

        deliveries.Add(express);
        deliveries.Add(eco);

        foreach (DeliveryService delivery in deliveries)
        {
            Console.WriteLine("\nMa don hang: " + delivery.OrderId);
            Console.WriteLine("Quang duong: " + delivery.DistanceKm + " km");
            Console.WriteLine(
                "Phi van chuyen: "
                + delivery.CalculateShippingFee()
                + " VND"
            );
        }
    }
}