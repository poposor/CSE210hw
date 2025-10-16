using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac = new Fraction();
        Fraction frac1 = new Fraction(5);
        Fraction frac2 = new Fraction(3, 4);
        Fraction frac3 = new Fraction(1, 3);

        Console.WriteLine(frac.GetFractionString());
        Console.WriteLine(frac.GetBottom());

        Console.WriteLine(frac1.GetFractionString());
        Console.WriteLine(frac1.GetTop());

        Console.WriteLine(frac2.GetFractionString());
        Console.WriteLine(frac2.GetDecimalValue());

        Console.WriteLine(frac3.GetFractionString());
        Console.WriteLine(frac3.GetDecimalValue());
    }
}