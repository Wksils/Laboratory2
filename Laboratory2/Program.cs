using System.Reflection.Metadata.Ecma335;
Console.Write("enter x: ");
double x = double.Parse(Console.ReadLine()!);
Console.Write("enter e1: ");
double e1 = double.Parse(Console.ReadLine()!);
Console.Write("enter e2: ");
double e2 = double.Parse(Console.ReadLine()!);

FazzyNumber fazzyNumber = new FazzyNumber(x, e1, e2);

Console.Write("enter x: ");
double x1 = double.Parse(Console.ReadLine()!);
Console.Write("enter e1: ");
double e11 = double.Parse(Console.ReadLine()!);
Console.Write("enter e2: ");
double e22 = double.Parse(Console.ReadLine()!);
FazzyNumber fazzyNumber1 = new FazzyNumber(x1, e11, e22);

Console.WriteLine($"{x},{e1},{e2} + {x1},{e11},{e22} = {fazzyNumber.Plus(fazzyNumber1)}");
Console.WriteLine($"{x},{e1},{e2} - {x1},{e11},{e22} = {fazzyNumber.Minus(fazzyNumber1)}");
Console.WriteLine($"{x},{e1},{e2} * {x1},{e11},{e22} = {fazzyNumber.Multiply(fazzyNumber1)}");
Console.WriteLine($"{x},{e1},{e2} : {x1},{e11},{e22} = {fazzyNumber.Division(fazzyNumber1)}");
Console.WriteLine($"{x},{e1},{e2} -обратное число- {fazzyNumber.Return()}");

Console.Write("введите целую часть: ");
int a = int.Parse(Console.ReadLine()!);
Console.Write("введите дробную часть: ");
int b = int.Parse(Console.ReadLine()!);
Fraction fraction = new Fraction(a, b);

Console.Write("введите целую часть: ");
int a1 = int.Parse(Console.ReadLine()!);
Console.Write("введите дробную часть: ");
int b1 = int.Parse(Console.ReadLine()!);
Fraction fraction1 = new Fraction(a1, b1);

Console.WriteLine($"{fraction.d} + {fraction1.d} = {fraction.Plus(fraction1)}");
Console.WriteLine($"{fraction.d} - {fraction1.d} = {fraction.Minus(fraction1)}");
Console.WriteLine($"{fraction.d} + {fraction1.d} = {fraction.Multiply(fraction1)}");
Console.WriteLine(fraction.Comparision(fraction, fraction1));

abstract class Pair
{
    public abstract Pair Plus(Pair pair);
    public abstract Pair Minus(Pair pair);
    public abstract Pair Multiply(Pair pair);
}
class FazzyNumber : Pair
{
    public double x {  get; set; }
    public double e1 { get; set; }
    public double e2 { get; set; }

    public FazzyNumber(double x, double e1, double e2)
    {
        this.x = x;
        this.e1 = e1;
        this.e2 = e2;
    }

    public override Pair Plus(Pair pair)
    {
        double ee1=this.x+(pair as FazzyNumber)!.x-this.e1-(pair as FazzyNumber)!.e1;
        double ee2 = this.x + (pair as FazzyNumber)!.x;
        double ee3 = this.x + (pair as FazzyNumber)!.x + this.e2 + (pair as FazzyNumber)!.e2;
        return new FazzyNumber(ee1,ee2,ee3) as Pair;
    }

    public override Pair Minus(Pair pair)
    {
        double ee1 = this.x - (pair as FazzyNumber)!.x - this.e1 - (pair as FazzyNumber)!.e1;
        double ee2 = this.x - (pair as FazzyNumber)!.x;
        double ee3 = this.x - (pair as FazzyNumber)!.x + this.e2 + (pair as FazzyNumber)!.e2;
        return new FazzyNumber(ee1, ee2, ee3) as Pair;
    }

    public override Pair Multiply(Pair pair)
    {
        double ee1 = this.x * (pair as FazzyNumber)!.x - (pair as FazzyNumber)!.x * this.e1 - this.x * (pair as FazzyNumber)!.e1 + this.e1 * (pair as FazzyNumber)!.e1;
        double ee2 = this.x * (pair as FazzyNumber)!.x;
        double ee3 = this.x * (pair as FazzyNumber)!.x + (pair as FazzyNumber)!.x * this.e1 + this.x * (pair as FazzyNumber)!.e1 + this.e1 * (pair as FazzyNumber)!.e1;
        return new FazzyNumber(ee1, ee2, ee3) as Pair;
    }
    public FazzyNumber Return()
    {
        if (this.x > 0)
        {
            double ee1 = 1 / (this.x + this.e2);
            double ee2 = 1 / this.x;
            double ee3 = 1 / (this.x - this.e1);
            return new FazzyNumber(ee1, ee2, ee3);
        }
        else return new FazzyNumber(0,0, 0);
    }
    public FazzyNumber Division(FazzyNumber number)
    {
        if (number.x > 0)
        {
            double ee1 = (this.x - this.e1)/(number.x - number.e2);
            double ee2 = this.x / number.x;
            double ee3 = (this.x - this.e2)/(number.x - number.e1);
            return new FazzyNumber(ee1,ee2,ee3);
        }
        else return new FazzyNumber(0, 0, 0);
    }

    public override string? ToString()
    {
        return $"{x}, {e1}, {e2}";
    }
}
class Fraction : Pair
{
    public double d;

    private Fraction(double d)
    {
        this.d = d;
    }

    public Fraction(int a, int b)
    {
        d = double.Parse($"{a},{b}");   
    }

    public override Pair Minus(Pair pair)
    {
        return new Fraction(this.d - (pair as Fraction)!.d) as Pair ;
    }

    public override Pair Multiply(Pair pair)
    {
        return new Fraction(this.d * (pair as Fraction)!.d) as Pair;
    }

    public override Pair Plus(Pair pair)
    {
        return new Fraction(this.d + (pair as Fraction)!.d) as Pair;
    }
    public string Comparision(Fraction a, Fraction b)
    {
        if (a.d == b.d) return $"{a.d} = {b.d}";
        if (a.d > b.d) return $"{a.d} больше чем {b.d}";
        return $"{b.d} больше чем {a.d}"; 
    }
}