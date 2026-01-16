using System.Reflection.Metadata.Ecma335;

abstract class Pair
{
    public abstract double Plus();
    public abstract double Minus();
    public abstract double Multiply();
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

    public override FazzyNumber Minus()
    {
        //double x = fazzy.x - number.x - fazzy.e1 - number.e1;
        //double e1 = fazzy.x - number.x;
        //double e2 = fazzy.x - number.x + fazzy.e2 + number.e2;
        //return new FazzyNumber(x, e1, e2);
    }

    public override double Multiply()
    {
        throw new NotImplementedException();
    }

    public override double Plus()
    {
        throw new NotImplementedException();
    }
}
class Fraction : Pair
{
    public int d;
    public Fraction()
    {
    }

    public override double Minus()
    {
        throw new NotImplementedException();
    }

    public override double Multiply()
    {
        throw new NotImplementedException();
    }

    public override double Plus()
    {
        throw new NotImplementedException();
    }
}